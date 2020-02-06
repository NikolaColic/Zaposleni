using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZaposleniMVC.Models;
using ZaposleniMVC.ModelsFunction;

namespace ZaposleniMVC.Controllers
{
    public class RadnikController : Controller
    {
        private readonly ApplicationDbContext _db;


        public RadnikController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            Odgovor o = new Odgovor();
            if(Sesija.Instance.Zaposlen is null)
            {
                return NotFound();
            }
            var zaposlen = Sesija.Instance.Zaposlen.Ime+Sesija.Instance.Zaposlen.Prezime;
            
            var rasporedi = _db.Raspored.Include((r) => r.Zaposleni);
            var listaRasporeda = rasporedi.Where((r) => (r.Zaposleni.Ime + r.Zaposleni.Prezime).Equals(zaposlen)).ToList();
            if (listaRasporeda.Count() == 0)
            {
                
            }
           
            listaRasporeda.OrderByDescending((r) => r.Datum);
            o.Rasporedi = listaRasporeda;
            o.Zap = Sesija.Instance.Zaposlen;
            
            return View(o);
        }

        public IActionResult Prijava(string datum, string zaposleni)
        {
            DateTime dat = Convert.ToDateTime(datum);
            var zaposlen = _db.Zaposleni.ToList();
            var raspo = _db.Raspored.Single((r) => r.Datum == dat && (r.Zaposleni.Ime + r.Zaposleni.Prezime).Equals(zaposleni));
            raspo.VremePrijave = DateTime.Now;
            if (ProveraKasni(raspo) == false) raspo.Kasni = true;
            _db.Update(raspo);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search([FromForm]DateTime datum)
        {
            Odgovor o = new Odgovor();
            var raspored = _db.Raspored.Include((r)=> r.Zaposleni).Where((r) => r.Datum.Date == datum && r.Zaposleni.OsobaID == Sesija.Instance.Zaposlen.OsobaID);
            
            if (raspored.Count()==0)
            {
                return RedirectToAction("Index");
            }
            o.Rasporedi = raspored.ToList();
            return View(o);
        }

        [HttpGet]
        public async Task< IActionResult> Create(Raspored r)
        {
           
            r.Datum = DateTime.Now;
            r.VremePrijave = DateTime.Now;
            r.Zaposleni = _db.Zaposleni.Single((z) => z.OsobaID == Sesija.Instance.Zaposlen.OsobaID);
            r.Administrator = _db.Administratori.Single((a) => a.AdministratorID == 5);
            r.Smena = "";
            r.Obavestenje = "";
            
            r.Kasni = false;
            _db.Add(r);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
            

        }

        [HttpPost]
        public IActionResult Vrati(string datum)
        {
            DateTime da = Convert.ToDateTime(datum);
            var raspored = _db.Raspored.Include((r) => r.Zaposleni).Where((r) => r.Datum.Date == da && r.Zaposleni.OsobaID == Sesija.Instance.Zaposlen.OsobaID);
            Odgovor o = new Odgovor();
            o.Rasporedi = raspored.ToList();
            return PartialView(o);
        }

        private bool ProveraKasni(Raspored r)
        {
            if(r.Smena == "Prva")
            {
                if(r.VremePrijave.Hour <= 8)
                {
                    return true;
                }
            }
            else
            {
                if (r.VremePrijave.Hour <= 15) return true;
            }
            return false;
        }

        private Raspored KreirajRaspored()
        {
            Raspored r = new Raspored();
            r.Datum = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
            
            r.Smena = "";

            r.Zaposleni = Sesija.Instance.Zaposlen;
            r.Administrator = _db.Administratori.Single((a) => a.AdministratorID == 5);
            r.Obavestenje = "";
            r.Kasni = false;
            r.VremePrijave = new DateTime(1389, 06, 28);
            return r;

        }

        public IActionResult Profil()
        {
            var zaposlen = Sesija.Instance.Zaposlen;
            zaposlen = _db.Zaposleni.Single((z) => z.OsobaID == zaposlen.OsobaID);
            Odgovor o = new Odgovor();
            o.Zap = zaposlen;
            return View(o);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profil([FromForm]Odgovor z)
        {
            
            
            try
            {
               

                _db.Update(z.Zap);
                _db.SaveChanges();
                
                z.Poruka = "Ok";
            }
            catch (Exception)
            {

                z.Poruka = "Greska";
            }
            return View(z);
            
        }
    }
}