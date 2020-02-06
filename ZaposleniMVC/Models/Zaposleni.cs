
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZaposleniMVC.Models
{
    public class Zaposleni
    {
        public string Pozicija { get; set; }
        [Key]
        public int OsobaID { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Sifra { get; set; }
        public Kompanija Kompanija { get; set; }

       

    }
}
