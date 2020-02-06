using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZaposleniMVC.Models
{
    public class Odgovor
    {
        public List<Zaposleni> Zaposleni { get; set; }
        public List<Raspored> Rasporedi { get; set; }
        public Zaposleni Zap { get; set; }
        public string Poruka { get; set; }
        public Raspored Ras { get; set; }
        public Kompanija Kompanija { get; set; }
        public List<string> Validacija { get; set; }
       
    }
}
