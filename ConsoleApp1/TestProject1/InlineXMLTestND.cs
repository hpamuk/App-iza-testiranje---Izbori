using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Xml;

namespace TestProject1
{
    [TestClass]
    public class InlineXMLTestND // FUNKCIONALNOST 3 : DEDOVIĆ NEJRA
    {
        static IEnumerable<object[]> IspisKonacnihRezultata1
        {
            get
            {
                return new[]
                {
                    new object[] {"Stranke koje su osvojile mandat:\nND\nUkupan broj osvojenih glasova: 5\nPostotak osvojenih glasova: 100%.\n" +
                                "Kandidati iz stranke koji su osvojili mandat: \nNejra Dedovic\nUkupan broj osvojenih glasova: 3\nPostotak osvojenih glasova: 60%.\n" +
                                "Neko Nekic\nUkupan broj osvojenih glasova: 3\nPostotak osvojenih glasova: 60%.\n" +
                                "Huso Husic\nUkupan broj osvojenih glasova: 2\nPostotak osvojenih glasova: 40%.\n" +
                                "Nezavisni kandidati koji su osvojili mandat:\n" +
                                "Izlaznost na izborima je: 50%."}
                };
            }
        }

        static IEnumerable<object[]> IspisKonacnihRezultata2
        {
            get
            {
                return new[]
                {
                    new object[] {"Stranke koje su osvojile mandat:\nZvijezda\nUkupan broj osvojenih glasova: 2\nPostotak osvojenih glasova: 40%.\n" +
                            "Kandidati iz stranke koji su osvojili mandat: \nSumeja Dedovic\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 50%.\n" +
                            "Ferid Nekic\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 50%.\n" +
                            "Huso Husic\nUkupan broj osvojenih glasova: 2\nPostotak osvojenih glasova: 100%.\n" +
                            "Mjesec\nUkupan broj osvojenih glasova: 2\nPostotak osvojenih glasova: 40%.\n" +
                            "Kandidati iz stranke koji su osvojili mandat: \nNedzla Helac\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 50%.\n" +
                            "Suljo Suljic\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 50%.\n" +
                            "Nezavisni kandidati koji su osvojili mandat:\n" +
                            "Sanela Anic\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 20%.\n" +
                            "Lamija Kemic\nUkupan broj osvojenih glasova: 1\nPostotak osvojenih glasova: 20%.\n" +
                            "Izlaznost na izborima je: 50%."}
                };
            }
        }

        [TestMethod]
        [DynamicData("IspisKonacnihRezultata1")]
            public void IspisInformacijaTest1(string Ispis)
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
                List<int> lista1 = new List<int> { 1, 2};
                izbori.Glasaj(1, lista1);
                DateTime datum7 = new DateTime(1994, 6, 3);
                Glasac g2 = new Glasac("Nedzla", "Pamuk", "Ilirska ab", datum7, "123E457", "0306994123456");
                List<int> lista2 = new List<int> { 1 };
                izbori.Glasaj(1, lista2);
                DateTime datum8 = new DateTime(1994, 5, 3);
                Glasac g3 = new Glasac("Naida", "Kemic", "Zmaja od Bosne ba", datum8, "123E458", "0305994123456");
                List<int> lista3 = new List<int> { 1 , 3};
                izbori.Glasaj(1, lista3);
                DateTime datum9 = new DateTime(1994, 5, 2);
                Glasac g4 = new Glasac("Sumeja", "Zolota", "Butmirska cesta ac", datum9, "123E459", "0205994123456");
                List<int> lista4 = new List<int> { 3, 2 };
                izbori.Glasaj(1, lista4);
                DateTime datum10 = new DateTime(1992, 6, 3);
                Glasac g5 = new Glasac("Nejra", "Hodzic", "Zmaja od Bosne aa", datum10, "123E456", "0306992123456");
                List<int> lista5 = new List<int> { 2 };
                izbori.Glasaj(1, lista5);

                StringAssert.Equals(Ispis, izbori.KonacniRezultati());

            }

        [TestMethod]
        [DynamicData("IspisKonacnihRezultata2")]
        public void IspisInformacijaTest2(string Ispis)
        {
            Izbori izbori = new Izbori(2022, 10, 5);

            Stranka stranka1 = new Stranka("Zvijezda");
            Stranka stranka2 = new Stranka("Mjesec");

            DateTime datum = new DateTime(2001, 11, 17);
            Kandidat k1 = new Kandidat("Sumeja", "Dedovic", 1, datum, "Srednja elektrotehnicka skola", false, stranka1);
            Kandidat k2 = new Kandidat("Ferid", "Nekic", 2, datum, "Srednja masinska skola", false, stranka1);
            Kandidat k3 = new Kandidat("Huso", "Husic", 3, datum, "Treca gimnazija", false, stranka1);
            izbori.stranke.Add(stranka1);

            DateTime datum1 = new DateTime(2001, 2, 7);
            Kandidat k4 = new Kandidat("Nedzla", "Helac", 1, datum1, "Srednja elektrotehnicka skola", false, stranka2);
            Kandidat k5 = new Kandidat("Suljo", "Suljic", 2, datum1, "Prva gimnazija", false, stranka2);
            Kandidat k6 = new Kandidat("Medina", "Mujic", 3, datum1, "Srednja ekonomska skola", false, stranka2);
            izbori.stranke.Add(stranka2);

            DateTime datum5 = new DateTime(2000, 5, 5);
            Kandidat k7 = new Kandidat("Sanela", "Anic", 1, datum5, "Druga gimnazija", true, null);
            Kandidat k8 = new Kandidat("Lamija", "Kemic", 2, datum5, "Srednja elektrotehnicka skola za energetiku", true, null);
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

            Assert.AreEqual(Ispis, izbori.KonacniRezultati());

        }

        public static IEnumerable<object[]> UčitajPodatkeXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("TestND.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                List<string> elements = new List<string>();
                foreach (XmlNode innerNode in node)
                {
                    elements.Add(innerNode.InnerText);
                }
                yield return new object[] { elements[0] };
            }
        }

        static IEnumerable<object[]> IspisXML
        {
            get
            {
                return UčitajPodatkeXML();
            }
        }


        [TestMethod]
        [DynamicData("IspisXML")]
        public void IspisInformacijaTest3(string Ispis)
        {
            Izbori izbori = new Izbori(2022, 5, 0);
            StringAssert.Equals(Ispis, izbori.KonacniRezultati());
        }
    }
}
