using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZaposleniMVC.Models;

namespace ZaposleniMVC.ModelsFunction
{
    public class Sesija
    {
        private static Sesija instance; 
        private Sesija()
        {

        }
        public static Sesija Instance
        {
            get
            {
                if (instance is null) instance = new Sesija();
                return instance;
            }
        }

        public Zaposleni Zaposlen { get; set; }
        public Administrator Administrator { get; set; }
    }
}
