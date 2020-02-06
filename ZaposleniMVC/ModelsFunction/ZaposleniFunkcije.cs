using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZaposleniMVC.Models;

namespace ZaposleniMVC.ModelsFunction
{
    public class ZaposleniFunkcije
    {
        private static ZaposleniFunkcije instance;
        private ZaposleniFunkcije()
        {

        }
        public static ZaposleniFunkcije Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new ZaposleniFunkcije();
                }
                return instance;
            }
        }
        private ApplicationDbContext _db;
        public ZaposleniFunkcije(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Zaposleni> VratiSve()
        {
            return _db.Zaposleni;
        }
        public async Task<Zaposleni> VratiJedan(int? ID)
        {
            return await _db.Zaposleni.SingleAsync((a) => a.OsobaID == ID);
        }
        public async Task<string> VratiAtribut(int? ID, string properti)
        {
            var admin = await _db.Zaposleni.SingleAsync((a) => a.OsobaID == ID);
            return null;
        }
        public async Task<Zaposleni> Insert(Zaposleni a)
        {
            _db.Add(a);
            await _db.SaveChangesAsync();
            return a;
        }
        public async Task<Zaposleni> Update(Zaposleni a)
        {
            _db.Update(a);
            await _db.SaveChangesAsync();
            return a;
        }
        public async void Delete(int? id)
        {
            _db.Remove(VratiJedan(id));
            await _db.SaveChangesAsync();

        }
        public IEnumerable<Zaposleni> Search(string kriterijum)
        {
            var administratori = _db.Zaposleni.Where((a) => a.Ime.Contains(kriterijum) || a.Prezime.Contains(kriterijum)
            || a.Email.Contains(kriterijum) || a.Adresa.Contains(kriterijum));
            return administratori;
        }
        public IEnumerable<Zaposleni> Sort(string kriterijum)
        {
            List<Zaposleni> lista = _db.Zaposleni.ToList();
            if (kriterijum.Equals("Ime")) return lista.OrderBy((a) => a.Ime);
            else if (kriterijum.Equals("Prezime")) return lista.OrderBy((a) => a.Prezime);
            else if (kriterijum.Equals("Email")) return lista.OrderBy((a) => a.Email);
            else return lista;

        }
        public bool ProveraLogin(Zaposleni a)
        {
            if ((_db.Zaposleni.SingleOrDefault((a1) => a1.Email == a.Email && a1.Sifra == a.Sifra)) is null) return false;
            return true;
        }

    }
}
