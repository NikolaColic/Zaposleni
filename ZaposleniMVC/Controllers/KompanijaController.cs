using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZaposleniMVC.Models;

namespace ZaposleniMVC.Controllers
{
    public class KompanijaController : Controller
    {
        private readonly ApplicationDbContext _db;


        public KompanijaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            Odgovor o = new Odgovor();
            if (_db.Kompanija.Count() == 0)
            {
                o.Kompanija = new Kompanija();

                return View(o);
            }

            return RedirectToAction("Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Kompanija kompanija)
        {
            Odgovor o = new Odgovor();
            o.Kompanija = new Kompanija();
            try
            {
                _db.Add(kompanija);
                _db.SaveChanges();
                return RedirectToAction("Edit");

            }
            catch (Exception)
            {

                o.Poruka = "Greska";
            }
            return View(o);
        }

        public IActionResult Edit()
        {
            Odgovor o = new Odgovor();
            o.Kompanija = _db.Kompanija.First();

            return View(o);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Kompanija kompanija)
        {
            Odgovor o = new Odgovor();
            o.Kompanija = kompanija;

            try
            {
                List<string> lista = ProveraOpste(o.Kompanija);
                if (lista.Count > 0)
                {
                    o.Validacija = lista;
                    o.Poruka = "Greska";
                    return View(o);
                }
                _db.Update(kompanija);
                _db.SaveChanges();
                o.Poruka = "Ok";

            }
            catch (Exception)
            {

                o.Poruka = "Greska";
            }
            return View(o);
        }

        private List<string> ProveraOpste(Kompanija kompanija)
        {
            List<string> lista = new List<string>();
            if (!ProveraNaziv(kompanija.Naziv)) lista.Add("naziv");
            if (!ProveraMaticni(kompanija.MaticniBroj)) lista.Add("maticni");
            if (!ProveraDelatnost(kompanija.Delatnost)) lista.Add("delatnost");
            if (!ProveraAdresa(kompanija.Adresa)) lista.Add("adresa");


            return lista;

        }

        private bool ProveraNaziv(string naziv)
        {
            if (naziv is null || naziv.Length <= 2) return false;
            return true;
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
        private bool ProveraMaticni(string maticni)
        {

            if ((maticni.Length == 8 || maticni.Length == 9) && Regex.IsMatch(maticni, @"^[0-9]+$")
                && !maticni.StartsWith("0") && !maticni.Equals("10000000")) return true;
            return false;
        }
        private bool ProveraDelatnost(string ime)
        {
            if (!(ime is null) && (ime.Length >= 2 && Regex.IsMatch(ime, @"^[a-z A-Z]+$"))) return true;
            return false;
        }
    }
}

