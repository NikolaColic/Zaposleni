using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZaposleniMVC.Models;

namespace ZaposleniMVC.Controllers
{
    public class RasporedController : Controller
    {
        private readonly ApplicationDbContext _db;


        public RasporedController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var zaposleni = _db.Zaposleni.ToList();

            var rasp = _db.Raspored.Include((r) => r.Zaposleni).OrderByDescending((r)=> r.Datum);
             ;


            Odgovor o = new Odgovor()
            {
                Zaposleni = zaposleni,
                Rasporedi = rasp.ToList()
            };
            return View(o);
        }

        public IActionResult Create()
        {
            var zaposleni = _db.Zaposleni.ToList();
            Odgovor o = new Odgovor()
            {
                Zaposleni = zaposleni,
                Ras = new Raspored()
            };
            return View(o);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]DateTime datum,[FromForm] string smena,[FromForm] string zaposlen,[FromForm]string obavestenje)
        {
            Odgovor o = new Odgovor();
            o.Zaposleni = _db.Zaposleni.ToList();
            o.Ras = new Raspored();
            if (!(_db.Raspored.SingleOrDefault((r) => r.Datum == datum && (r.Zaposleni.Ime + r.Zaposleni.Prezime).Equals(zaposlen)) is null))
            {
                o.Poruka = "Ima";
                return View(o);
            }
            try
            {
                _db.Add(KreirajRaspored(datum, smena, zaposlen, obavestenje));
                _db.SaveChanges();
                
                o.Poruka = "Uspesno";
            }
            catch (Exception)
            {
                o.Poruka = "Ne";
                throw;
                
            }
            return View(o);
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string zaposlen)
        {
            Odgovor o = new Odgovor();
            o.Zaposleni = _db.Zaposleni.ToList();
            var rasporedi = _db.Raspored.Where((r) => (r.Zaposleni.Ime+r.Zaposleni.Prezime).Equals(zaposlen));
           
            if ((rasporedi is null) || rasporedi.Count() == 0 )
            {
                o.Rasporedi = _db.Raspored.ToList();
                
                o.Poruka = "Nema";
                return View(o);
            }
            o.Poruka = "Ima";
            o.Rasporedi = rasporedi.OrderByDescending(r => r.Datum).ToList() ;
            return View(o);
        }

        private Raspored KreirajRaspored(DateTime datum, string smena, string zaposlen, string obavestenje)
        {
            Raspored r = new Raspored();
            r.Datum = datum;
            r.Smena = smena;

            r.Zaposleni = _db.Zaposleni.Single((z) => (z.Ime + z.Prezime).Equals(zaposlen));
            r.Administrator = _db.Administratori.Single((a) => a.AdministratorID == 5);
            r.Obavestenje = obavestenje;
            r.Kasni = false;
            r.VremePrijave = new DateTime(1389,06,28);
            return r;
        }

        public IActionResult Edit(string datum,string zaposleni)
        {
            DateTime dat = Convert.ToDateTime(datum);
            var zaposlen = _db.Zaposleni.ToList();
            var raspo = _db.Raspored.Single((r) => r.Datum.Date == dat.Date && (r.Zaposleni.Ime + r.Zaposleni.Prezime).Equals(zaposleni));
            Odgovor o = new Odgovor()
            {
                Zaposleni = zaposlen,
                Ras = raspo
            };
            return View(o);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm]Raspored ras)
        {
            ras.Administrator = _db.Administratori.Single((a) => a.AdministratorID == 5);
            var r = _db.Raspored.Single((ra) => ra.RasporedID == ras.RasporedID);
            r.Smena = ras.Smena;
            r.Obavestenje = ras.Obavestenje;
            try
            {
                _db.Update(r);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index");
        }

       
        
        public IActionResult Delete(string datum, string zaposleni)
        {
            DateTime dat = Convert.ToDateTime(datum);
            var zaposlen = _db.Zaposleni.ToList();
            var raspo = _db.Raspored.Single((r) => r.Datum.Date == dat.Date && (r.Zaposleni.Ime + r.Zaposleni.Prezime).Equals(zaposleni));
            _db.Entry(raspo).State = EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}