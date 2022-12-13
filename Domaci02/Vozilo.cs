using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Domaci02
{
    internal class Vozilo
    {
        public int SifraVozila { get; set; }
        public string Registracija { get; set; }
        public string ImeVlasnika { get; set; }
        public string PrezimeVlasnika { get; set; }

        public Vozilo(int sifraVozila, string registracija, string imeVlasnika, string prezimeVlasnika)
        {
            SifraVozila = sifraVozila;
            Registracija = registracija;
            ImeVlasnika = imeVlasnika;
            PrezimeVlasnika = prezimeVlasnika;
        }

        public override string ToString()
        {
            return $"{SifraVozila},{Registracija},{ImeVlasnika},{PrezimeVlasnika}";
        }
    }
}
