using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZaposleniMVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<Administrator> Administratori { get; set; }
        public DbSet<Zaposleni> Zaposleni { get; set; }
        public DbSet<Raspored> Raspored { get; set; }
        public DbSet<Kompanija> Kompanija { get; set; }
        public DbSet<Obavestenja> Obavestenja { get; set; }


    }
}
