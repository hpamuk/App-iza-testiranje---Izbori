using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsvHelper;
using System.Globalization;
using System.IO;

namespace TestProject1
{  // TEST HENA PAMUK FUNKCIONALNOST 4
    [TestClass]
    public class InlineCSVTestHP
    {
        static IEnumerable<object[]> rukovodstvotrankeKojiSuKandidati1
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        "Ukupan broj glasova: 5\nKandidati:\nIdentifikacioni broj: HePa221011Zm\nIdentifikacioni broj: MiMi222010Zm\n"
                    }
                };
            }
        }

        static IEnumerable<object[]> rukovodstvotrankeKojiSuKandidati2
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        "Ukupan broj glasova: 8\nKandidati:\nIdentifikacioni broj: AnPa221011Zm\nIdentifikacioni broj: AjIr222010Zm\nIdentifikacioni broj: AdPj221211Zm\n"
                    }
                };
            }
        }

        [TestMethod]
        [DynamicData("rukovodstvotrankeKojiSuKandidati1")]
        public void ispisRukovodstvaKojiSuKandidati1(string ispis)
        {
            Stranka stranka = new Stranka("Kombi Stranka");
            Rukovodilac rukovodilac1 = new Rukovodilac("Hena", "Pamuk", DateTime.Parse("11/10/1996"), "Treca gimnazija", stranka);
            Rukovodilac rukovodilac2 = new Rukovodilac("Mira", "Miric", DateTime.Parse("10/20/1996"), "Srednja elektrotehnicka skola", stranka);
            Rukovodilac rukovodilac3 = new Rukovodilac("Lejla", "Ildic", DateTime.Parse("03/12/1990"), "Druga gimnazija", stranka);
            Rukovodilac rukovodilac4 = new Rukovodilac("Ilda", "Pjanic", DateTime.Parse("01/03/1997"), "Druga gimnazija", stranka);
            Glasac glasac1 = new Glasac("Hena", "Pamuk", "Zmaja od Bosne df", DateTime.Parse("11/10/1996"), "223E411", "1011996123456");
            Glasac glasac2 = new Glasac("Mira", "Miric", "Zmaja od Bosne dg", DateTime.Parse("10/20/1996"), "223E413", "2010996170024");
            Glasac glasac3 = new Glasac("Ilda", "Karaman", "Zmaja od Bosne dh", DateTime.Parse("01/03/1997"), "223E414", "0301997170027");
            Kandidat kandidat1 = new Kandidat("Hena", "Pamuk", 1, DateTime.Parse("11/10/1996"), "Treca gimnazija", false, stranka);
            Kandidat kandidat2 = new Kandidat("Mira", "Miric", 2, DateTime.Parse("10/20/1996"), "Srednja elektrotehnicka skola", false, stranka);
            Kandidat kandidat3 = new Kandidat("Ilda", "Ildic", 3, DateTime.Parse("05/20/1996"), "Druga gimnazija", false, stranka);
            kandidat1.dodajGlas();
            kandidat1.dodajGlas();
            kandidat2.dodajGlas();
            kandidat2.dodajGlas();
            kandidat2.dodajGlas();
            kandidat3.dodajGlas();
            List<Glasac> glasacList = new List<Glasac>(3) { glasac1, glasac2, glasac3 };
            List<Kandidat> kandidatList = new List<Kandidat>(3) { kandidat1, kandidat2, kandidat3 };
            List<Rukovodilac> rukovodilacList = new List<Rukovodilac>(4) { rukovodilac1, rukovodilac2, rukovodilac3, rukovodilac4 };
            stranka.Kandidati = kandidatList;
            stranka.Rukovodstvo = rukovodilacList;
            Izbori iz = new Izbori(2022, 43, 4);
            iz.Glasaci = glasacList;

            Assert.AreEqual(ispis, stranka.ispisRukovodstvaStrankeKojiSuKandidati());

        }

        [TestMethod]
        [DynamicData("rukovodstvotrankeKojiSuKandidati2")]
        public void ispisRukovodstvaKojiSuKandidati2(string ispis)
        {
            Stranka stranka = new Stranka("Kombi Stranka");
            Rukovodilac rukovodilac1 = new Rukovodilac("Ana", "Pamuk", DateTime.Parse("11/10/1996"), "Treca gimnazija", stranka);
            Rukovodilac rukovodilac2 = new Rukovodilac("Ajla", "Iric", DateTime.Parse("10/20/1996"), "Srednja elektrotehnicka skola", stranka);
            Rukovodilac rukovodilac3 = new Rukovodilac("Lejla", "Ildic", DateTime.Parse("03/12/1990"), "Druga gimnazija", stranka);
            Rukovodilac rukovodilac4 = new Rukovodilac("Ilda", "Pjanic", DateTime.Parse("01/03/1997"), "Druga gimnazija", stranka);
            Rukovodilac rukovodilac5 = new Rukovodilac("Ada", "Pjanic", DateTime.Parse("11/12/1997"), "Prva gimnazija", stranka);
            Glasac glasac1 = new Glasac("Ana", "Pamuk", "Zmaja od Bosne df", DateTime.Parse("11/10/1996"), "223E411", "1011996123456");
            Glasac glasac2 = new Glasac("Ajla", "Iric", "Zmaja od Bosne dg", DateTime.Parse("10/20/1996"), "223E413", "2010996170024");
            Glasac glasac3 = new Glasac("Ilda", "Karaman", "Zmaja od Bosne dh", DateTime.Parse("01/03/1997"), "223E414", "0301997170027");
            Glasac glasac4 = new Glasac("Ada", "Pjanic", "Zmaja od Bosne dd", DateTime.Parse("11/12/1997"), "227E423", "1211997717027");
            Kandidat kandidat1 = new Kandidat("Ana", "Pamuk", 1, DateTime.Parse("11/10/1996"), "Treca gimnazija", false, stranka);
            Kandidat kandidat2 = new Kandidat("Ajla", "Iric", 2, DateTime.Parse("10/20/1996"), "Srednja elektrotehnicka skola", false, stranka);
            Kandidat kandidat3 = new Kandidat("Ilda", "Ildic", 3, DateTime.Parse("05/20/1996"), "Druga gimnazija", false, stranka);
            Kandidat kandidat4 = new Kandidat("Ada", "Pjanic", 5, DateTime.Parse("11/12/1997"), "Prva gimnazija", false, stranka);
            kandidat1.dodajGlas();
            kandidat1.dodajGlas();
            kandidat1.dodajGlas(); 
            kandidat2.dodajGlas();  
            kandidat2.dodajGlas();
            kandidat2.dodajGlas();
            kandidat2.dodajGlas();
            kandidat3.dodajGlas();
            kandidat4.dodajGlas();
            List<Glasac> glasacList = new List<Glasac>(3) { glasac1, glasac2, glasac3, glasac4 };
            List<Kandidat> kandidatList = new List<Kandidat>(3) { kandidat1, kandidat2, kandidat3, kandidat4 };
            List<Rukovodilac> rukovodilacList = new List<Rukovodilac>(4) { rukovodilac1, rukovodilac2, rukovodilac3, rukovodilac4, rukovodilac5 };
            stranka.Kandidati = kandidatList;
            stranka.Rukovodstvo = rukovodilacList;
            Izbori iz = new Izbori(2022, 43, 4);
            iz.Glasaci = glasacList;

            Assert.AreEqual(ispis, stranka.ispisRukovodstvaStrankeKojiSuKandidati());

        }

        // Test klase Rukovodilac
        public static IEnumerable<object[]> UčitajPodatkeCSV()
        {
            using (var reader = new StreamReader("TestHP.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1],
                    DateTime.Parse(elements[2]), elements[3], new Stranka("kombi") };
                }
            }
        }
        static IEnumerable<object[]> Rukovodioci
        {
            get
            {
                return UčitajPodatkeCSV();
            }
        }
        [TestMethod]
        [DynamicData("Rukovodioci")]
        [ExpectedException(typeof(ArgumentException))]
        public void konstruktorRukovodiocaTest(string ime, string prezime, DateTime datumRodjenja, string zavrsenaSkola, Stranka stranka)
        {
            Rukovodilac r = new Rukovodilac(ime, prezime, datumRodjenja, zavrsenaSkola, stranka);
        }


    }

}

