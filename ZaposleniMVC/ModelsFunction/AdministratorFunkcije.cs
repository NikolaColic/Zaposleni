using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZaposleniMVC.Models;

namespace ZaposleniMVC.ModelsFunction
{
    public class AdministratorFunkcije
    {
        private static AdministratorFunkcije instance;
        private AdministratorFunkcije()
        {
            _db = new ApplicationDbContext(options);
        }
        public static AdministratorFunkcije Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new AdministratorFunkcije();
                }
                return instance;
            }
        }

        
        private DbContextOptions<ApplicationDbContext> options = new DbContextOptions<ApplicationDbContext>();
        private ApplicationDbContext _db;
       
        public IEnumerable<Administrator> VratiSve()
        {
            return _db.Administratori;
        }
        public async Task<Administrator> VratiJedan(int? ID)
        {
            return await _db.Administratori.SingleAsync((a) => a.AdministratorID == ID);
        }
        public async Task<string> VratiAtribut(int? ID,string properti)
        {
            var admin = await _db.Administratori.SingleAsync((a) => a.AdministratorID == ID);
            return null;
        }
        public async Task<Administrator> Insert(Administrator a)
        {
            _db.Add(a);
            await _db.SaveChangesAsync();
            return a;
        }
        public async Task<Administrator> Update(Administrator a)
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
        public IEnumerable<Administrator> Search(string kriterijum)
        {
            var administratori = _db.Administratori.Where((a) => a.Ime.Contains(kriterijum) || a.Prezime.Contains(kriterijum)
            || a.Email.Contains(kriterijum));
            return administratori;
        }
        public IEnumerable <Administrator> Sort(string kriterijum)
        {
            List<Administrator> lista = _db.Administratori.ToList();
            if (kriterijum.Equals("Ime")) return lista.OrderBy((a) => a.Ime);
            else if (kriterijum.Equals("Prezime")) return lista.OrderBy((a) => a.Prezime);
            else if (kriterijum.Equals("Email")) return lista.OrderBy((a) => a.Email);
            else return lista;

        }
        public bool ProveraLogin(Administrator a)
        {
            if ((_db.Administratori.SingleOrDefault((a1) => a1.Email == a.Email && a1.Sifra == a.Sifra)) is null) return false;
            return true;
        }



    }
}
