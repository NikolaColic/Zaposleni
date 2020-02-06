using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZaposleniMVC.Models
{
    public class Obavestenja
    {
        [Key]
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public int BrojSmena { get; set; }
        public string Smena { get; set; }
    }
}
