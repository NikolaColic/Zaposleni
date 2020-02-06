using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZaposleniMVC.Models
{
    public class Raspored
    {
        
        [Key]
        public int RasporedID { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        
        public Administrator Administrator { get; set; }
        
        public Zaposleni Zaposleni { get; set; }
        [Required]
        public string Smena { get; set; }
        public DateTime VremePrijave { get; set; }

        public bool Kasni { get; set; } = false;
        public string Obavestenje { get; set; }
    }
}
