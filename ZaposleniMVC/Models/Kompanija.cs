using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZaposleniMVC.Models
{
    public class Kompanija
    {
        [Key]
        public int KompanijaID { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string MaticniBroj { get; set; }
        public string Adresa { get; set; }
        public string Delatnost { get; set; }

        
    }
}
