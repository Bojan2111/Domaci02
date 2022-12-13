using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci02
{
    internal class Program
    {
        static void Main()
        {
            string vozilaTxt = "1,SO 123 456,Petar,Petrovic\n" +
                "2,NS 222 333,Mitar,Mitrovic\n" +
                "3,BG 777 111,Jovan,Jovanovic\n" +
                "4,SU 444 999,Mitar,Mitra Mitar\n" +
                "5,SU 444 123,Dordje,Djordjevic";
            // splitovati string sa \n, pa kroz for petlju sa Split(',')..
            // kreirati vozila

            string parkingKarteTxt = "1,1,0699999999,2012-12-31 11:30:45,crvena\n" +
                "2,1,0699999999,2013-01-20 11:30:45,plava\n" +
                "3,1,0600000000,2014-10-10 11:30:45,bela\n" +
                "4,2,0644444444,2013-04-04 11:30:45,plava\n" +
                "5,2,0644444444,2013-04-04 12:30:45,plava";

            // Napraviti array tipa string sa vozilima, odnosno kartama. Dobije se niz od 5 elemenata u svakom slucaju
            string[] vozilaNiz = vozilaTxt.Split('\n');
            string[] karteNiz = parkingKarteTxt.Split('\n');

            // Zatim se naprave nizovi tipa <ImeKlase>, tj. Vozilo i Karta, koje su definisane u zasebnim fajlovima
            // nizovi imaju onoliko elemenata koliko ima i odgovarajuci niz tipa string
            // Kreirace se nizovi sa praznim elementima, koji ce se u daljem toku programa popunjavati
            Vozilo[] vozila = new Vozilo[vozilaNiz.Length];
            Karta[] karte = new Karta[karteNiz.Length];

            // Preko for petlje obradjujemo svaku stavku iz odgovarajuceg niza
            for (int i = 0; i < vozilaNiz.Length; i++)
            {
                // Potrebno je napraviti privremeni niz koji ce sadrzati stavke u svakom od elemenata.
                // shvati to kao niz nizova
                // Posto su podaci podeljeni sa znakom ',' to koristimo kao argument u metodi Split
                string[] tempVozilo = vozilaNiz[i].Split(',');

                // U privremenu promenljivu tipa Vozilo smestamo podatke dobijene prilikom iteracije i splitovanja
                // Jedino se prva stavka parsuje u int, jer je tako definisano u klasi
                Vozilo vozilo = new Vozilo(int.Parse(tempVozilo[0]), tempVozilo[1], tempVozilo[2], tempVozilo[3]);

                // Zatim u niz tipa Vozilo smestamo novokreirani objekat
                vozila[i] = vozilo;
            }

            // ista petlja, ali za karte
            for (int i = 0; i < karteNiz.Length; i++)
            {
                string[] tempKarta = karteNiz[i].Split(',');
                // Mora se odrediti prazni objekat tipa Vozilo, kako bi se popunilo iz vec kreiranog niza tipa Vozilo iz
                // gornjeg for loop-a
                Vozilo parkiranoVozilo = null;

                // Iterisemo kroz sva vozila da dobijemo ono na koje se poziva drugi element iz niza karata
                foreach(Vozilo vozilo in vozila)
                {
                    if (vozilo.SifraVozila == int.Parse(tempKarta[1]))
                    {
                        // Dobili smo odgovarajuci objekat tipa Vozilo i smestili ga u promenljivu
                        parkiranoVozilo = vozilo;
                    }
                }

                // Kreiranje karte je onda vrlo lako
                Karta karta = new Karta(int.Parse(tempKarta[0]), parkiranoVozilo, tempKarta[2], tempKarta[3], tempKarta[4]);
                karte[i] = karta;
            }
            // Posto sam override-ovao ToString metod u klasama, konzolni ispis je lak zadatak.
            foreach(var i in vozila)
            {
                Console.WriteLine(i);
            }
            foreach (var i in karte)
            {
                Console.WriteLine(i);
            }
            
            Console.ReadKey();
        }
    }
}
