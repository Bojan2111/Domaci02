using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci02
{
    internal class Karta
    {
        public int SifraKarte { get; set; }
        public Vozilo ParkiranoVozilo { get; set; }
        public string Telefon { get; set; }
        public string VremeParkiranja { get; set; }
        public string Zona { get; set; }

        public Karta(int sifraKarte, Vozilo parkiranoVozilo, string telefon, string vremeParkiranja, string zona)
        {
            SifraKarte = sifraKarte;
            ParkiranoVozilo = parkiranoVozilo;
            Telefon = telefon;
            VremeParkiranja = vremeParkiranja;
            Zona = zona;
        }

        public override string ToString()
        {
            return $"{SifraKarte},{ParkiranoVozilo},{Telefon},{VremeParkiranja},{Zona}";
        }
    }
}
