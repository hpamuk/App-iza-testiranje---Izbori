using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Izbori izbori = new Izbori(2022, 50, 28);

            Stranka stranka1 = new Stranka("ND");
            Stranka stranka2 = new Stranka("NH");
            Stranka stranka3 = new Stranka("NK");
            Stranka stranka4 = new Stranka("EZ");
            Stranka stranka5 = new Stranka("HP");

            DateTime datum = new DateTime(2001, 11, 17);
            Kandidat k1 = new Kandidat("Nejra", "Dedovic", 1, datum, "Srednja elektrotehnicka skola", false, stranka1);
            Kandidat k2 = new Kandidat("Neko", "Nekic", 2, datum, "Srednja masinska skola", false, stranka1);
            Kandidat k3 = new Kandidat("Huso", "Husic", 3, datum, "Treca gimnazija", false, stranka1);
            izbori.stranke.Add(stranka1);

            DateTime datum1 = new DateTime(2001, 2, 7);
            Kandidat k4 = new Kandidat("Nedzla", "Helac", 1, datum1, "Srednja elektrotehnicka skola", false, stranka2);
            Kandidat k5 = new Kandidat("Suljo", "Suljic", 2, datum1, "Prva gimnazija", false, stranka2);
            Kandidat k6 = new Kandidat("Mujo", "Mujic", 3, datum1, "Srednja ekonomska skola", false, stranka2);
            izbori.stranke.Add(stranka2);

            /*k1.dodajBivsuStanku(stranka2, datum, datum1);
            k1.dodajBivsuStanku(stranka1, datum, datum1);
            k1.ispisiBivseStranke();*/


            DateTime datum2 = new DateTime(2001, 4, 29);
            Kandidat k7 = new Kandidat("Nadir", "Karaman", 1, datum2, "Cetvrta gimnazija", false, stranka3);
            Kandidat k8 = new Kandidat("Meho", "Mehic", 2, datum2, "Srednja elektrotehnicka skola", false, stranka3);
            Kandidat k9 = new Kandidat("Sejo", "Sejic", 3, datum2, "Srednja ekonomska skola", false, stranka3);
            izbori.stranke.Add(stranka3);

            DateTime datum3 = new DateTime(2001, 9, 2);
            Kandidat k10 = new Kandidat("Emina", "Zolota", 1, datum3, "Cetvrta gimnazija", false, stranka4);
            Kandidat k11 = new Kandidat("Ena", "Enic", 2, datum3, "Prva bosnjacka gimnazija", false, stranka4);
            Kandidat k12 = new Kandidat("Hana", "Hanic", 3, datum3, "Srednja elektrotehnicka skola za energetiku", false, stranka4);
            izbori.stranke.Add(stranka4);

            DateTime datum4 = new DateTime(2000, 5, 28);
            Kandidat k13 = new Kandidat("Hena", "Pamuk", 1, datum4, "Treca gimnazija", false, stranka5);
            Kandidat k14 = new Kandidat("Mira", "Miric", 2, datum4, "Srednja elektrotehnicka skola", false, stranka5);
            Kandidat k15 = new Kandidat("Ilda", "Ildic", 3, datum4, "Druga gimnazija", false, stranka5);
            izbori.stranke.Add(stranka5);

            DateTime datum5 = new DateTime(2000, 5, 5);
            Kandidat k16 = new Kandidat("Ana", "Anic", 1, datum5, "Druga gimnazija", true, null);
            Kandidat k17 = new Kandidat("Kemo", "Kemic", 2, datum5, "Srednja elektrotehnicka skola za energetiku", true, null);
            Kandidat k18 = new Kandidat("Dino", "Dinic", 3, datum5, "Peta gimnazija", true, null);
            izbori.nezavisniKandidati.Add(k16); izbori.nezavisniKandidati.Add(k17); izbori.nezavisniKandidati.Add(k18);

            DateTime datum6 = new DateTime(1995, 6, 3);
            Glasac g1 = new Glasac("Nejra", "Helac", "Zmaja od Bosne bb", datum6, "123E456", "0306995123456");
            izbori.Glasaci.Add(g1);
            DateTime datum7 = new DateTime(1994, 6, 3);
            Glasac g2 = new Glasac("Nejra", "Pamuk", "Zmaja od Bosne ab", datum7, "123E457", "0306994123456");
            izbori.Glasaci.Add(g2);
            DateTime datum8 = new DateTime(1994, 5, 3);
            Glasac g3 = new Glasac("Nejra", "Kemic", "Zmaja od Bosne ba", datum8, "123E458", "0305994123456");
            izbori.Glasaci.Add(g3);
            DateTime datum9 = new DateTime(1994, 5, 2);
            Glasac g4 = new Glasac("Nejra", "Zolota", "Zmaja od Bosne ac", datum9, "123E459", "0205994123456");
            izbori.Glasaci.Add(g4);

            DateTime datum10 = new DateTime(1992, 6, 3);
            Glasac g5 = new Glasac("Nejra", "Karaman", "Zmaja od Bosne aa", datum10, "123E456", "0306992123456");
            izbori.Glasaci.Add(g5);
            DateTime datum11 = new DateTime(1984, 6, 3);
            Glasac g6 = new Glasac("Nejra", "Nekic", "Zmaja od Bosne ca", datum11, "123E456", "0306984123456");
            izbori.Glasaci.Add(g6);
            DateTime datum12 = new DateTime(1994, 5, 1);
            Glasac g7 = new Glasac("Nejra", "Mehic", "Zmaja od Bosne cc", datum12, "123E456", "0105994123456");
            izbori.Glasaci.Add(g7);
            DateTime datum13 = new DateTime(1976, 5, 2);
            Glasac g8 = new Glasac("Nejra", "Suljic", "Zmaja od Bosne bc", datum13, "123E456", "0205976123456");
            izbori.Glasaci.Add(g8);

            DateTime datum14 = new DateTime(1996, 8, 5);
            Glasac g9 = new Glasac("Hena", "Helac", "Zmaja od Bosne de", datum14, "123E456", "0508996123456");
            izbori.Glasaci.Add(g9);
            DateTime datum15 = new DateTime(1996, 8, 7);
            Glasac g10 = new Glasac("Hena", "Dedovic", "Zmaja od Bosne df", datum15, "123E456", "0708996123456");
            izbori.Glasaci.Add(g10);
            DateTime datum16 = new DateTime(1996, 8, 8);
            Glasac g11 = new Glasac("Hena", "Zolota", "Zmaja od Bosne dg", datum16, "123E456", "0808996123456");
            izbori.Glasaci.Add(g11);
            DateTime datum17 = new DateTime(1996, 8, 9);
            Glasac g12 = new Glasac("Hena", "Karaman", "Zmaja od Bosne dh", datum17, "123E456", "0908996123456");
            izbori.Glasaci.Add(g12);

            DateTime datum18 = new DateTime(1996, 8, 10);
            Glasac g13 = new Glasac("Emina", "Helac", "Zmaja od Bosne di", datum18, "123E456", "1008996123456");
            izbori.Glasaci.Add(g13);
            DateTime datum19 = new DateTime(1996, 8, 11);
            Glasac g14 = new Glasac("Emina", "Dedovic", "Zmaja od Bosne dj", datum19, "123E456", "1108996123456");
            izbori.Glasaci.Add(g14);
            DateTime datum20 = new DateTime(1996, 8, 12);
            Glasac g15 = new Glasac("Emina", "Zolota", "Zmaja od Bosne dk", datum20, "123E456", "1208996123456");
            izbori.Glasaci.Add(g15);
            DateTime datum21 = new DateTime(1996, 8, 13);
            Glasac g16 = new Glasac("Emina", "Karaman", "Zmaja od Bosne dl", datum21, "123E456", "1308996123456");
            izbori.Glasaci.Add(g16);

            DateTime datum22 = new DateTime(1999, 1, 1);
            Glasac g17 = new Glasac("Nedzla", "Pamuk", "Zmaja od Bosne fa", datum22, "123E456", "0101999123456");
            izbori.Glasaci.Add(g17);
            DateTime datum23 = new DateTime(1996, 8, 7);
            Glasac g18 = new Glasac("Nedzla", "Dedovic", "Zmaja od Bosne fb", datum23, "123E456", "0708996124456");
            izbori.Glasaci.Add(g18);
            DateTime datum24 = new DateTime(1972, 11, 1);
            Glasac g19 = new Glasac("Nedzla", "Zolota", "Zmaja od Bosne fc", datum24, "123E456", "0111972123456");
            izbori.Glasaci.Add(g19);
            DateTime datum25 = new DateTime(1996, 9, 9);
            Glasac g20 = new Glasac("Nedzla", "Karaman", "Zmaja od Bosne fd", datum25, "123E456", "0909996123456");
            izbori.Glasaci.Add(g20);

            DateTime datum26 = new DateTime(1996, 8, 14);
            Glasac g21 = new Glasac("Nadir", "Helac", "Zmaja od Bosne dm", datum26, "123E456", "1408996123456");
            izbori.Glasaci.Add(g21);
            DateTime datum27 = new DateTime(1996, 8, 15);
            Glasac g22 = new Glasac("Nadir", "Dedovic", "Zmaja od Bosne dn", datum27, "123E456", "1508996123456");
            izbori.Glasaci.Add(g22);
            DateTime datum28 = new DateTime(1996, 8, 16);
            Glasac g23 = new Glasac("Nadir", "Zolota", "Zmaja od Bosne do", datum28, "123E456", "1608996123456");
            izbori.Glasaci.Add(g23);
            DateTime datum29 = new DateTime(1996, 8, 17);
            Glasac g24 = new Glasac("Nadir", "Karaman", "Zmaja od Bosne dp", datum29, "123E456", "1708996123456");
            izbori.Glasaci.Add(g24);

            DateTime datum30 = new DateTime(1998, 1, 1);
            Glasac g25 = new Glasac("Nedzla", "Nekic", "Zmaja od Bosne rt", datum30, "123E456", "0101998123456");
            izbori.Glasaci.Add(g25);
            DateTime datum31 = new DateTime(1996, 8, 7);
            Glasac g26 = new Glasac("Nedzla", "Mehic", "Zmaja od Bosne oi", datum31, "123E456", "0708996123456");
            izbori.Glasaci.Add(g26);
            DateTime datum32 = new DateTime(1972, 11, 6);
            Glasac g27 = new Glasac("Nedzla", "Suljic", "Zmaja od Bosne wt", datum32, "123E456", "0611972123456");
            izbori.Glasaci.Add(g27);
            DateTime datum33 = new DateTime(2000, 9, 9);
            Glasac g28 = new Glasac("Nedzla", "Sejic", "Zmaja od Bosne vv", datum33, "123E456", "0909000123456");
            izbori.Glasaci.Add(g28);

            Console.WriteLine("Pocinje glasanje!");
            int i = 1;
            foreach (Glasac glasac in izbori.Glasaci)
            {
                Console.WriteLine("Na redu je " + i + ". glasac: ");
                izbori.Glasaj(glasac);
                if (i % 10 == 0)
                {
                    string trenutniIspis = izbori.TrenutniRezultati();
                    Console.WriteLine("Presjek glasova nakon " + i + ". glasaca: \n" + trenutniIspis);
                }
                i++;
            }

            string konacniIspis = izbori.KonacniRezultati();
            Console.WriteLine("Konacni rezultati izbora:\n" + konacniIspis);
        }
    }
}
