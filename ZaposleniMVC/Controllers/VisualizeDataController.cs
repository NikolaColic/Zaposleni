using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZaposleniMVC.Models;

namespace ZaposleniMVC.Controllers
{
    public class VisualizeDataController : Controller
    {
        private readonly ApplicationDbContext _db;


        public VisualizeDataController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult ColumnChart()
        {
            return View();
        }
        public ActionResult PodaciZaposleni()
        {
            return Json(Rezultati("Prva"));
        }
        public List<Obavestenja> Rezultati(string smena)
        {
            List<Obavestenja> obav = new List<Obavestenja>();
            var zaposleni = _db.Zaposleni;
            foreach(var i in zaposleni)
            {
                int brojac = 0;
                var rasporedi = _db.Raspored.Where((r) => r.Zaposleni.OsobaID == i.OsobaID).ToList();
                rasporedi.ForEach((r) =>
                {
                    if (r.Smena == smena) brojac++;

                });
                Obavestenja o = new Obavestenja();
                o.ImePrezime = i.Ime + " " + i.Prezime;
                o.Smena = "Prva";
                o.BrojSmena = brojac;
                obav.Add(o);
            }
            return obav;
        }
        public ActionResult PodaciZaposleni2()
        {
            return Json(Rezultati("Druga"));
        }
        public ActionResult PodaciZaposleni3()
        {
            return Json(Rezultati("Ne radi"));
        }
    }
}