using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZaposleniMVC.Models
{
    public class Administrator
    {
        [Key]
        public int AdministratorID { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        
        public string BrojTelefona { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Sifra { get; set; }
        public Kompanija Kompanija { get; set; }

    }
}
