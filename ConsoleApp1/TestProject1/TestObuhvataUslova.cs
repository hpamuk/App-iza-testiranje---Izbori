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
    public class TestObuhvataUslova
    {
        [TestMethod]
        public void TestObuhvataUslova1() // Testiramo uslov kada je glasač glasao za nezavisne kandidate (s == 0)
        {
            Izbori izbori = new Izbori(2022, 6, 6);

            DateTime datum1 = new DateTime(2000, 5, 5);
            Kandidat k1 = new Kandidat("Neko", "Anic", 1, datum1, "Druga gimnazija", true, null);
            Kandidat k2 = new Kandidat("Drago", "Kemic", 2, datum1, "Srednja elektrotehnicka skola za energetiku", true, null);
            Kandidat k3 = new Kandidat("Rizo", "Dinic", 3, datum1, "Peta gimnazija", true, null);
            izbori.nezavisniKandidati.Add(k1); izbori.nezavisniKandidati.Add(k2); izbori.nezavisniKandidati.Add(k3);

            DateTime datum2 = new DateTime(1995, 6, 3);
            Glasac g9 = new Glasac("Hena", "Helac", "Zmaja od Bosne de", datum2, "123E456", "0306995123456");
            izbori.Glasaci.Add(g9);
            List<int> lista1 = new List<int> { 1, 2 };
            izbori.Glasaj(0, lista1);
            DateTime datum15 = new DateTime(1996, 8, 7);
            Glasac g10 = new Glasac("Hena", "Dedovic", "Zmaja od Bosne df", datum2, "123E456", "0306995123456");
            izbori.Glasaci.Add(g10);
            List<int> lista2 = new List<int> { 2, 3 };
            izbori.Glasaj(0, lista2);

            Assert.AreNotEqual(0, izbori.nezavisniKandidati[0].brojGlasova);
            Assert.IsTrue(izbori.nezavisniKandidati[1].brojGlasova == 2);
            Assert.AreEqual(1, izbori.nezavisniKandidati[2].brojGlasova);

        }

        [TestMethod]
        public void TestObuhvataUslova2() // Testiramo uslov kada je glasač glasao stranku i njene kandidate (s != 0)
        {
            Izbori izbori = new Izbori(2022, 6, 6);

            Stranka s1 = new Stranka("Stranka1");

            DateTime datum1 = new DateTime(2000, 5, 5);
            Kandidat k1 = new Kandidat("Neko", "Anic", 1, datum1, "Druga gimnazija", false, s1);
            Kandidat k2 = new Kandidat("Drago", "Kemic", 2, datum1, "Srednja elektrotehnicka skola za energetiku", false, s1);
            Kandidat k3 = new Kandidat("Rizo", "Dinic", 3, datum1, "Peta gimnazija", false, s1);
            izbori.stranke.Add(s1);

            DateTime datum2 = new DateTime(1995, 6, 3);
            Glasac g9 = new Glasac("Hena", "Helac", "Zmaja od Bosne de", datum2, "123E456", "0306995123456");
            izbori.Glasaci.Add(g9);
            List<int> lista1 = new List<int> { 1, 2 };
            izbori.Glasaj(1, lista1);
            DateTime datum15 = new DateTime(1996, 8, 7);
            Glasac g10 = new Glasac("Hena", "Dedovic", "Zmaja od Bosne df", datum2, "123E456", "0306995123456");
            izbori.Glasaci.Add(g10);
            List<int> lista2 = new List<int> { 2, 3 };
            izbori.Glasaj(1, lista2);

            Assert.IsTrue(izbori.stranke[0].kandidati[1].brojGlasova == 2);
            Assert.AreEqual(2, izbori.stranke[0].brojGlasova);

        }

        [TestMethod]
        public void TestObuhvataUslova3() // Testiramo uslov kada je glasač glasao stranku a nije za njene kandidate (s != 0)
        {
            Izbori izbori = new Izbori(2022, 6, 6);

            Stranka s1 = new Stranka("Stranka1");

            DateTime datum1 = new DateTime(2000, 5, 5);
            Kandidat k1 = new Kandidat("Neko", "Anic", 1, datum1, "Druga gimnazija", false, s1);
            Kandidat k2 = new Kandidat("Drago", "Kemic", 2, datum1, "Srednja elektrotehnicka skola za energetiku", false, s1);
            Kandidat k3 = new Kandidat("Rizo", "Dinic", 3, datum1, "Peta gimnazija", false, s1);
            izbori.stranke.Add(s1);

            DateTime datum2 = new DateTime(1995, 6, 3);
            Glasac g9 = new Glasac("Hena", "Helac", "Zmaja od Bosne de", datum2, "123E456", "0306995123456");
            izbori.Glasaci.Add(g9);
            List<int> lista1 = new List<int> {};
            izbori.Glasaj(1, lista1);
            DateTime datum15 = new DateTime(1996, 8, 7);
            Glasac g10 = new Glasac("Hena", "Dedovic", "Zmaja od Bosne df", datum2, "123E456", "0306995123456");
            izbori.Glasaci.Add(g10);
            List<int> lista2 = new List<int> {};
            izbori.Glasaj(1, lista2);

            Assert.AreEqual(2, izbori.stranke[0].brojGlasova);

        }
    }
}
