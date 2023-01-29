using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace TestProject1
{
    [TestClass]
    public class TestObuhvataOdluka // Testiramo odluke u metodi Glasaj(int s, List<int> k) u klasi Izbori
    {
        [TestMethod]
        public void TestObuhvataOdluka1() // Testiramo odluku kada glasac glasa za određenu stranku i njene kadnidate
        {
            Izbori izbori = new Izbori(2022, 10, 5);

            Stranka stranka1 = new Stranka("Stranka1");

            DateTime datum = new DateTime(2001, 11, 17);
            Kandidat k1 = new Kandidat("Nejra", "Dedovic", 1, datum, "Srednja elektrotehnicka skola", false, stranka1);
            Kandidat k2 = new Kandidat("Neko", "Nekic", 2, datum, "Srednja masinska skola", false, stranka1);
            Kandidat k3 = new Kandidat("Huso", "Husic", 3, datum, "Treca gimnazija", false, stranka1);
            izbori.stranke.Add(stranka1);

            DateTime datum1 = new DateTime(2001, 2, 7);
            Kandidat k4 = new Kandidat("Ana", "Anic", 1, datum1, "Druga gimnazija", true, null);
            Kandidat k5 = new Kandidat("Kemo", "Kemic", 2, datum1, "Srednja elektrotehnicka skola za energetiku", true, null);
            Kandidat k6 = new Kandidat("Dino", "Dinic", 3, datum1, "Peta gimnazija", true, null);
            izbori.nezavisniKandidati.Add(k4); izbori.nezavisniKandidati.Add(k5); izbori.nezavisniKandidati.Add(k6);

            DateTime datum6 = new DateTime(1995, 6, 3);
            Glasac g1 = new Glasac("Nejra", "Helac", "Zmaja od Bosne bb", datum6, "123E456", "0306995123456");
            List<int> lista1 = new List<int> { 1 };
            izbori.Glasaj(0, lista1);

            Assert.AreEqual(1, izbori.nezavisniKandidati[0].brojGlasova);
        }

        [TestMethod]
        public void TestObuhvataOdluka2() // Testiramo odluku kada glasač glasa za nezavisne kandidate
        {
            Izbori izbori = new Izbori(2022, 10, 5);

            Stranka stranka1 = new Stranka("Stranka1");
            Stranka stranka2 = new Stranka("Stranka2");

            DateTime datum = new DateTime(2001, 11, 17);
            Kandidat k1 = new Kandidat("Nejra", "Dedovic", 1, datum, "Srednja elektrotehnicka skola", false, stranka1);
            Kandidat k2 = new Kandidat("Neko", "Nekic", 2, datum, "Srednja masinska skola", false, stranka1);
            Kandidat k3 = new Kandidat("Huso", "Husic", 3, datum, "Treca gimnazija", false, stranka1);
            izbori.stranke.Add(stranka1);

            DateTime datum1 = new DateTime(2001, 2, 7);
            Kandidat k4 = new Kandidat("Ana", "Anic", 1, datum1, "Druga gimnazija", false, stranka2);
            Kandidat k5 = new Kandidat("Kemo", "Kemic", 2, datum1, "Srednja elektrotehnicka skola za energetiku", false, stranka2);
            Kandidat k6 = new Kandidat("Dino", "Dinic", 3, datum1, "Peta gimnazija", false, stranka2);
            izbori.stranke.Add(stranka2);

            DateTime datum6 = new DateTime(1995, 6, 3);
            Glasac g1 = new Glasac("Nejra", "Helac", "Zmaja od Bosne bb", datum6, "123E456", "0306995123456");
            List<int> lista1 = new List<int> { 1, 2 };
            izbori.Glasaj(2, lista1);

            Assert.AreEqual(1, izbori.stranke[1].brojGlasova);
            Assert.AreEqual(1, izbori.stranke[1].kandidati[0].brojGlasova);
        }
    }
}
