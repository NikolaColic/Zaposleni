using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZaposleniMVC.Models;
using ZaposleniMVC.ModelsFunction;

namespace ZaposleniMVC.Controllers
{
    
    public class ZaposleniController : Controller
    {
        private readonly ApplicationDbContext _db;
       

        public ZaposleniController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(new Administrator());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Index(string email, string sifra, string administrator)
        {
            if (!(administrator is null) &&  administrator.Equals("DA"))
            {
                Administrator a = new Administrator()
                {
                    Email = email,
                    Sifra = sifra
                };
                var admin = _db.Administratori.SingleOrDefault((a1) => a1.Email == a.Email && a1.Sifra == a.Sifra);
                if ( admin is null) return View(null);
                Sesija.Instance.Administrator = admin;
                return RedirectToAction("IndexAdministrator");
                
               
            }
            else
            {
                Zaposleni z = new Zaposleni()
                {
                    Email = email,
                    Sifra = sifra
                };
                var zapos = _db.Zaposleni.SingleOrDefault((a1) => a1.Email == z.Email && a1.Sifra == z.Sifra);
                if ( zapos is null) return View(null);
                Sesija.Instance.Zaposlen = zapos;
                return RedirectToAction("Index","Radnik");

            }

        }
        public IActionResult IndexAdministrator()
        {

            return View(_db.Zaposleni);
        }

        public IActionResult Create(int? id)
        {
            Odgovor o = new Odgovor();
            o.Zap = new Zaposleni();
            return View(o);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Odgovor o)
        {
            
           
            if(_db.Zaposleni.SingleOrDefault((za) => za.Email.Equals(o.Zap.Email)) is null)
            {
                List<string> lista = ProveraOpste(o.Zap);
                if (lista.Count > 0)
                {
                    Odgovor o1 = new Odgovor();
                    o1.Zap = o.Zap;
                    o1.Validacija = lista;
                    o1.Poruka = "Greska";
                    return View(o1);
                }
                o.Zap.Sifra = o.Zap.Ime.ToLower().Substring(0, 3) + o.Zap.Prezime.ToLower().Substring(0, 3);
                _db.Add(o.Zap);
                await _db.SaveChangesAsync();
                return RedirectToAction("IndexAdministrator");
            }
            return View(null);
           
        }
        public IActionResult Kreiraj(int? id)
        {
            Zaposleni zap = (Zaposleni)_db.Zaposleni.Include((z)=> z.Kompanija).Single((a) => a.OsobaID == id);
            int broj =PDF(zap);
            if (broj == -1) return NotFound();
            return RedirectToAction("IndexAdministrator");
        }

        private int  PDF(Zaposleni zaposleni)
        {
            Document doc = new Document(iTextSharp.text.PageSize.A4);
            string s1 = $"Datum izdavanja: {DateTime.Today.AddMonths(-1)} - {DateTime.Today} \n" +
                $"Ime: {zaposleni.Ime}\nPrezime: {zaposleni.Prezime}\nEmail: {zaposleni.Email}\nAdresa: {zaposleni.Adresa}\nBroj telefona: {zaposleni.BrojTelefona}\n" +
                $"Naziv firme: {zaposleni.Kompanija.Naziv}";
            try
            {
                Random random = new Random();
                int num = random.Next(1000);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream($"{zaposleni.Ime}{zaposleni.Prezime}{num}.pdf", FileMode.Create));
                doc.Open();
                doc.PageCount = 2;
                Paragraph title = new Paragraph();
                title.Alignment = Element.ALIGN_CENTER;
                title.Font = FontFactory.GetFont("Arial", 32);
                title.Add($"{zaposleni.Ime}{zaposleni.Prezime}- izvestaj\n\n");
                doc.Add(title);
                doc.Add(KreirajParagraf(s1));
                var rasporedi = _db.Raspored.Include((r) => r.Zaposleni).Where((r) => r.Zaposleni.OsobaID == zaposleni.OsobaID).ToList() ;
                rasporedi.OrderByDescending((r) => r.Datum);
                
                doc.Add(KreirajParagraf("______________________________________________________________________________"));
                foreach (var i in rasporedi)
                {
                    string s2 = $"\nDatum: {i.Datum} \t\t\t\t\tSmena: {i.Smena}\n" +
                        $"Obavestenje: {i.Obavestenje} \t\t\t\t\t VremePrijave: {i.VremePrijave}";
                    
                    doc.Add(KreirajParagraf(s2));
                   
                    doc.Add(KreirajParagraf("______________________________________________________________________________"));

                   


                }
                return num;
            }
            catch (Exception e)
            {
                throw;
                return -1;
            }
            finally
            {
                doc.Close();
            }
        }

        private Paragraph KreirajParagraf(string tekst)
        {
            Paragraph paragraph = new Paragraph(tekst);
            paragraph.SpacingAfter = 10;
            paragraph.Alignment = Element.ALIGN_LEFT;
            paragraph.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.GREEN);
            return paragraph;
        }


        private List<string> ProveraOpste(Zaposleni z)
        {
            List<string> lista = new List<string>();
            if (!ProveraIme(z.Ime)) lista.Add("ime");
            if (!ProveraPrezime(z.Prezime)) lista.Add("prezime");
            if (!ProveraEmail(z.Email)) lista.Add("email");
            if (!ProveraAdresa(z.Adresa)) lista.Add("adresa");
            
            return lista;
        }

        
        private bool ProveraAdresa(string adresa)
        {
            if (adresa is null) return false;
            string[] niz = adresa.Split(' ');
            int brojReci = 0;
            int brojUlice = 0;
            foreach (string s in niz)
            {
                if (Regex.IsMatch(s, @"^[a-zA-Z]+$")) brojReci++;
                if (Regex.IsMatch(s, @"^[0-9]+$")) brojUlice++;
            }
            if (brojUlice == 1 && brojReci + brojUlice == niz.Length) return true;
            return false;
           
        }

        private bool ProveraIme(string ime)
        {
            if (!(ime is null) && (ime.Length >= 2 && Regex.IsMatch(ime, @"^[a-zA-Z]+$"))) return true;
            return false;
        }
        private bool ProveraPrezime(string prezime)
        {
            if (!(prezime is null) && prezime.Length >= 2 && Regex.IsMatch(prezime, @"^[a-zA-Z]+$")) return true;
            return false;
        }
        private bool ProveraEmail(string txtEmail)
        {
            if (!(txtEmail is null) && (txtEmail.EndsWith("@gmail.com") || txtEmail.EndsWith("@hotmail.com"))
                && txtEmail.IndexOf('@') == txtEmail.LastIndexOf('@') && txtEmail.IndexOf('@') != 0) return true;
            return false;
        }
        private bool ProveraSifra(string sifra)
        {
            if (sifra.Length >= 6) return true;
            return false;
        }

        public async Task< IActionResult> Edit(int? id)
        {
            Odgovor o = new Odgovor();
            o.Zap = await _db.Zaposleni.SingleAsync((a) => a.OsobaID == id);
            return View(o);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Odgovor o)
        {
             
                List<string> lista = ProveraOpste(o.Zap);
                if (lista.Count > 0)
                {
                    Odgovor o1 = new Odgovor();
                    o1.Zap = o.Zap;
                    o1.Validacija = lista;
                    o1.Poruka = "Greska";
                    return View(o1);
                }
                 o.Zap.Sifra = o.Zap.Ime.ToLower().Substring(0, 3) + o.Zap.Prezime.ToLower().Substring(0, 3);
                _db.Update(o.Zap);
                await _db.SaveChangesAsync();
                return RedirectToAction("IndexAdministrator");
            
          
        }

        public List<Zaposleni> VratiZaposlene()
        {
            var zaposleni = _db.Zaposleni.ToList();
            return zaposleni;
        }
        
        public  IActionResult Delete(int? id)
        {
            var zasosleni = _db.Zaposleni.Single((a) => a.OsobaID == id);
            List<Raspored> rasporedi =  _db.Raspored.Where((r) => r.Zaposleni.OsobaID == id).ToList();
            rasporedi.ForEach((r) => {
                _db.Entry(r).State = EntityState.Deleted;
                });

            _db.Entry(zasosleni).State = EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction("IndexAdministrator");
        }
        public IActionResult Search()
        {
            Odgovor o = new Odgovor();
            o.Zaposleni = _db.Zaposleni.ToList();
            return View(o);
        }

        
        public IActionResult Pretraga(string pretraga)
        {
            Odgovor o = new Odgovor();
            var zaposleni = _db.Zaposleni.Where((a) => a.Ime.Contains(pretraga) || a.Prezime.Contains(pretraga) || a.Adresa.Contains(pretraga));
            if (zaposleni.Count() == 0)
            {
                o.Zaposleni = _db.Zaposleni.ToList();
                o.Poruka = "Ne";
                return View(o);
            }
            o.Poruka = "Da";
            o.Zaposleni = zaposleni.ToList();
            return PartialView(o);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search([FromForm] string pretraga)
        {
            Odgovor o = new Odgovor();
            var zaposleni = _db.Zaposleni.Where((a) => a.Ime.Contains(pretraga) || a.Prezime.Contains(pretraga) || a.Adresa.Contains(pretraga));
            if (zaposleni.Count() == 0)
            {
                o.Zaposleni = _db.Zaposleni.ToList();
                o.Poruka = "Ne";
                return View(o);
            }
            o.Poruka = "Da";
            o.Zaposleni = zaposleni.ToList();
            return View(o);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sort([FromForm]string sort)
        {
            
            List<Zaposleni> zaposleni = new List<Zaposleni>();

            if (sort.Equals("Ime")) zaposleni = _db.Zaposleni.OrderBy((a) => a.Ime).ToList();
            else if (sort.Equals("Prezime")) zaposleni = _db.Zaposleni.OrderBy((a) => a.Prezime).ToList();
            else zaposleni = _db.Zaposleni.OrderBy((a) => a.Email).ToList() ;
            return View(zaposleni);
            
        }

        
        
        public IActionResult Sortiraj(string sort)
        {

            List<Zaposleni> zaposleni = new List<Zaposleni>();

            if (sort.Equals("Ime")) zaposleni = _db.Zaposleni.OrderBy((a) => a.Ime).ToList();
            else if (sort.Equals("Prezime")) zaposleni = _db.Zaposleni.OrderBy((a) => a.Prezime).ToList();
            else zaposleni = _db.Zaposleni.OrderBy((a) => a.Email).ToList();
            return View(zaposleni);

        }

        //------------------------------------------------------------------------------------------

        public IActionResult Logout()
        {
            Sesija.Instance.Administrator = null;
            return RedirectToAction("Index");
        }
       
    }
}