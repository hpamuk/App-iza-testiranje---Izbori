using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{ // TEST HENA PAMUK FUNKCIONALNOST 4
    [TestClass]
    public class TestHP
    {

            static Stranka stranka;
            static Rukovodilac rukovodilac1;
            static Rukovodilac rukovodilac2;
            static Rukovodilac rukovodilac3;
            static Rukovodilac rukovodilac4;
            static Kandidat kandidat1;
            static Kandidat kandidat2;
            static Kandidat kandidat3;
            static Glasac glasac1;
            static Glasac glasac2;
            static Glasac glasac3;
            static List<Glasac> glasacList;
            static List<Rukovodilac> rukovodilacList;
            static List<Kandidat> kandidatList;
            
            // Inicijalizacija podataka koja se vrši samo jednom
            [ClassInitialize]
            public static void PočetnaInicijalizacija(TestContext context)
            {
                stranka = new Stranka("Kombi Stranka");
                
            }

            // Inicijalizacija podataka koja se vrši prije svakog testa
            [TestInitialize]
            public void InicijalizacijaPrijeSvakogTesta()
            {
            // pravim po 3 rukovodioca, 3 glasaca i 3 kandidata
                rukovodilac1 = new Rukovodilac("Hena", "Pamuk", DateTime.Parse("11/10/1996"), "Treca gimnazija", stranka);
                rukovodilac2 = new Rukovodilac("Mira", "Miric", DateTime.Parse("10/20/1996"), "Srednja elektrotehnicka skola", stranka);
                rukovodilac3 = new Rukovodilac("Lejla", "Ildic", DateTime.Parse("03/12/1990"), "Druga gimnazija", stranka);
                rukovodilac4 = new Rukovodilac("Ilda", "Pjanic", DateTime.Parse("01/03/1997"), "Druga gimnazija", stranka);


                glasac1 = new Glasac("Hena", "Pamuk", "Zmaja od Bosne df", DateTime.Parse("11/10/1996"), "223E411", "1011996123456");
                glasac2 = new Glasac("Mira", "Miric", "Zmaja od Bosne dg", DateTime.Parse("10/20/1996"), "223E413", "2010996170024");
                glasac3 = new Glasac("Ilda", "Karaman", "Zmaja od Bosne dh", DateTime.Parse("01/03/1997"), "223E414", "0301997170027");

                kandidat1 = new Kandidat("Hena", "Pamuk", 1, DateTime.Parse("11/10/1996"), "Treca gimnazija", false, stranka);
                kandidat2 = new Kandidat("Mira", "Miric", 2, DateTime.Parse("10/20/1996"), "Srednja elektrotehnicka skola", false, stranka);
                kandidat3 = new Kandidat("Ilda", "Ildic", 3, DateTime.Parse("05/20/1996"), "Druga gimnazija", false, stranka);

                kandidat1.dodajGlas();
                kandidat1.dodajGlas();
                kandidat2.dodajGlas();
                kandidat2.dodajGlas();
                kandidat2.dodajGlas();
                kandidat3.dodajGlas();
                
                glasacList = new List<Glasac>(3) { glasac1, glasac2, glasac3 };
                kandidatList = new List<Kandidat>(3) { kandidat1, kandidat2, kandidat3 };
                rukovodilacList = new List<Rukovodilac>(4) { rukovodilac1, rukovodilac2, rukovodilac3, rukovodilac4 };

            }

            [TestMethod]
            public void napraviListuRukovodiocaIKandidataTest()
            {
                List<Kandidat> rukovodiociKandidati = stranka.napraviListuRukovodiocaIKandidata(kandidatList, rukovodilacList);
                Assert.AreEqual(2, rukovodiociKandidati.Count);
            }

            [TestMethod]
            public void sumaRukovociocaKandidataTest()
            {
                List<Kandidat> rukovodiociKandidati = stranka.napraviListuRukovodiocaIKandidata(kandidatList, rukovodilacList);
                Assert.AreEqual(5, stranka.sumaRukovociocaKandidata(rukovodiociKandidati));
            }

            [TestMethod]
            public void identifikacijskiKodZaKandidataTest()
            {
                Izbori iz = new Izbori(2022, 43, 4);
                iz.Glasaci = glasacList;
                string kod = Izbori.IdentifikacijskiKodZaKandidata(kandidat1);
                Assert.AreEqual(12, kod.Length);
            }

            [TestMethod()]
            public void ispisRukovodstvaStrankeKojiSuKandidatiTest()
            {
                stranka.Kandidati = kandidatList;
                stranka.Rukovodstvo = rukovodilacList;
                Izbori iz = new Izbori(2022, 43, 4);
                iz.Glasaci = glasacList;
                string ispis = stranka.ispisRukovodstvaStrankeKojiSuKandidati();
                Assert.AreEqual("Ukupan broj glasova: 5\nKandidati:\nIdentifikacioni broj: " +
                    "HePa221011Zm\nIdentifikacioni broj: MiMi222010Zm\n", ispis);
            }
        
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void testKonstruktoraRukovodioca()
        {
            Rukovodilac r = new Rukovodilac(" ", "Pamuk", DateTime.Parse("11/10/1996"), "Treca gimnazija", stranka);
        }
        
    }
   }


