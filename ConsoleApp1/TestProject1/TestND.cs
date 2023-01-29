/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class TestND //Testovi za funkcionalnost 3 (Dedović Nejra)
    {
        [TestMethod]
        public void IspisInformacijaTest1()
        {
            Izbori izbori = new Izbori(2022, 10, 5);

            Stranka stranka1 = new Stranka("ND");
            Stranka stranka2 = new Stranka("NH");

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

            DateTime datum6 = new DateTime(1995, 6, 3);
            Glasac g1 = new Glasac("Nejra", "Helac", "Zmaja od Bosne bb", datum6, "123E456", "0306995123456");
            List<int> lista1 = new List<int>{1,2,3};
            izbori.Glasaj(1, lista1);
            DateTime datum7 = new DateTime(1994, 6, 3);
            Glasac g2 = new Glasac("Nejra", "Pamuk", "Zmaja od Bosne ab", datum7, "123E457", "0306994123456");
            List<int> lista2 = new List<int> { 1, 2};
            izbori.Glasaj(1, lista2);
            DateTime datum8 = new DateTime(1994, 5, 3);
            Glasac g3 = new Glasac("Nejra", "Kemic", "Zmaja od Bosne ba", datum8, "123E458", "0305994123456");
            List<int> lista3 = new List<int> { 1 };
            izbori.Glasaj(1, lista3);
            DateTime datum9 = new DateTime(1994, 5, 2);
            Glasac g4 = new Glasac("Nejra", "Zolota", "Zmaja od Bosne ac", datum9, "123E459", "0205994123456");
            List<int> lista4 = new List<int> { 3 };
            izbori.Glasaj(1, lista4);
            DateTime datum10 = new DateTime(1992, 6, 3);
            Glasac g5 = new Glasac("Nejra", "Karaman", "Zmaja od Bosne aa", datum10, "123E456", "0306992123456");
            List<int> lista5 = new List<int> { 2 };
            izbori.Glasaj(1, lista5);

            Assert.AreEqual("Stranke koje su osvojile mandat:\nND\nUkupan broj osvojenih glasova: 5\nPostotak osvojenih glasova: 100%.\n" +
                            "Kandidati iz stranke koji su osvojili mandat: \nNejra Dedovic\nUkupan broj osvojenih glasova: 3\nPostotak osvojenih glasova: 60%.\n" +
                            "Neko Nekic\nUkupan broj osvojenih glasova: 3\nPostotak osvojenih glasova: 60%.\n" +
                            "Huso Husic\nUkupan broj osvojenih glasova: 2\nPostotak osvojenih glasova: 40%.\n" +
                            "Nezavisni kandidati koji su osvojili mandat:\n"+
                            "Izlaznost na izborima je: 50%.", izbori.KonacniRezultati());

        }

        [TestMethod]
        public void IspisInformacijaTest2()
        {
            Izbori izbori = new Izbori(2022, 10, 5);

            Stranka stranka1 = new Stranka("ND");
            Stranka stranka2 = new Stranka("NH");

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

            DateTime datum5 = new DateTime(2000, 5, 5);
            Kandidat k7 = new Kandidat("Ana", "Anic", 1, datum5, "Druga gimnazija", true, null);
            Kandidat k8 = new Kandidat("Kemo", "Kemic", 2, datum5, "Srednja elektrotehnicka skola za energetiku", true, null);
            Kandidat k9 = new Kandidat("Dino", "Dinic", 3, datum5, "Peta gimnazija", true, null);
            izbori.nezavisniKandidati.Add(k7); izbori.nezavisniKandidati.Add(k8); izbori.nezavisniKandidati.Add(k9);

            DateTime datum6 = new DateTime(1995, 6, 3);
            Glasac g1 = new Glasac("Nejra", "Helac", "Zmaja od Bosne bb", datum6, "123E456", "0306995123456");
            List<int> lista1 = new List<int> { 1, 2, 3 };
            izbori.Glasaj(1, lista1);
            DateTime datum7 = new DateTime(1994, 6, 3);
            Glasac g2 = new Glasac("Nejra", "Pamuk", "Zmaja od Bosne ab", datum7, "123E457", "0306994123456");
            List<int> lista2 = new List<int> { 1, 2 };
            izbori.Glasaj(0, lista2);
            DateTime datum8 = new DateTime(1994, 5, 3);
            Glasac g3 = new Glasac("Nejra", "Kemic", "Zmaja od Bosne ba", datum8, "123E458", "0305994123456");
            List<int> lista3 = new List<int> { 1 };
            izbori.Glasaj(2, lista3);
            DateTime datum9 = new DateTime(1994, 5, 2);
            Glasac g4 = new Glasac("Nejra", "Zolota", "Zmaja od Bosne ac", datum9, "123E459", "0205994123456");
            List<int> lista4 = new List<int> { 3 };
            izbori.Glasaj(1, lista4);
            DateTime datum10 = new DateTime(1992, 6, 3);
            Glasac g5 = new Glasac("Nejra", "Karaman", "Zmaja od Bosne aa", datum10, "123E456", "0306992123456");
            List<int> lista5 = new List<int> { 2 };
            izbori.Glasaj(2, lista5);

            Assert.AreEqual("Stranke koje su osvojile mandat:\nND\nUkupan broj osvojenih glasova: 2\nPostotak osvojenih glasova: 40%.\n" +
                            "Kandidati iz stranke koji su osvojili mandat: \nNejra Dedovic\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 50%.\n" +
                            "Neko Nekic\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 50%.\n" +
                            "Huso Husic\nUkupan broj osvojenih glasova: 2\nPostotak osvojenih glasova: 100%.\n" +
                            "NH\nUkupan broj osvojenih glasova: 2\nPostotak osvojenih glasova: 40%.\n"+
                            "Kandidati iz stranke koji su osvojili mandat: \nNedzla Helac\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 50%.\n" +
                            "Suljo Suljic\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 50%.\n" +
                            "Nezavisni kandidati koji su osvojili mandat:\n" +
                            "Ana Anic\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 20%.\n" +
                            "Kemo Kemic\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 20%.\n" +
                            "Izlaznost na izborima je: 50%.", izbori.KonacniRezultati());

        }

        [TestMethod]
        public void IspisInformacijaTest3()
        {
            Izbori izbori = new Izbori(2022, 5, 2);

            Stranka stranka1 = new Stranka("ND");
            Stranka stranka2 = new Stranka("NH");

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

            DateTime datum5 = new DateTime(2000, 5, 5);
            Kandidat k7 = new Kandidat("Ana", "Anic", 1, datum5, "Druga gimnazija", true, null);
            Kandidat k8 = new Kandidat("Kemo", "Kemic", 2, datum5, "Srednja elektrotehnicka skola za energetiku", true, null);
            Kandidat k9 = new Kandidat("Dino", "Dinic", 3, datum5, "Peta gimnazija", true, null);
            izbori.nezavisniKandidati.Add(k7); izbori.nezavisniKandidati.Add(k8); izbori.nezavisniKandidati.Add(k9);

            DateTime datum6 = new DateTime(1995, 6, 3);
            Glasac g1 = new Glasac("Nejra", "Helac", "Zmaja od Bosne bb", datum6, "123E456", "0306995123456");
            List<int> lista1 = new List<int> { 1, 2, 3 };
            izbori.Glasaj(1, lista1);
            DateTime datum7 = new DateTime(1994, 6, 3);
            Glasac g2 = new Glasac("Nejra", "Pamuk", "Zmaja od Bosne ab", datum7, "123E457", "0306994123456");
            List<int> lista2 = new List<int> {};
            izbori.Glasaj(2, lista2);

            Assert.AreEqual("Stranke koje su osvojile mandat:\nND\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 50%.\n" +
                            "Kandidati iz stranke koji su osvojili mandat: \nNejra Dedovic\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 100%.\n" +
                            "Neko Nekic\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 100%.\n" +
                            "Huso Husic\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 100%.\n" +
                            "NH\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 50%.\n" +
                            "Kandidati iz stranke koji su osvojili mandat: \n"+
                            "Nezavisni kandidati koji su osvojili mandat:\n" +
                            "Izlaznost na izborima je: 40%.", izbori.KonacniRezultati());

        }

        [TestMethod]
        public void IspisInformacijaTest4()
        {
            Izbori izbori = new Izbori(2022, 5, 0);


            Assert.AreEqual("Stranke koje su osvojile mandat:\n" +
                            "Nezavisni kandidati koji su osvojili mandat:\n" +
                            "Izlaznost na izborima je: 0%.", izbori.KonacniRezultati());

        }
    }
}*/
