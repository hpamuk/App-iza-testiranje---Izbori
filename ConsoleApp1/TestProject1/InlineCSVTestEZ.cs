using ConsoleApp1;
using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{

    //Testirala: Emina Zolota

    [TestClass]
    public class InlineTestNK1
    {
        // Inline testing
        static IEnumerable<object[]> GlasaciSaJedinstvenimIdentifikacionimKodomITajnomSifrom
        {
            get
            {
                return new[]
                {
                    new object[] {"Emina", "Zolota", "Zmaja od Bosne bb",
                         DateTime.Parse("02/09/2001"), "223E411", "0902001170027", "111222333444", "VVS20222023"},
                    new object[] {"Neko", "Nekic", "Zmaja od Bosne bb",
                         DateTime.Parse("02/09/2001"), "223E411", "0902001170027", "NeNe220902Zm", "VVS20222020"},
                    new object[] {"Hana", "Hanic", "Zmaja od Bosne bb",
                         DateTime.Parse("02/09/2001"), "223E411", "0902001170027", "NeNe220902Zm", "VVS20222020"}
                };
            }
        }

        static IEnumerable<object[]> PogresneTajneSifre
        {
            get
            {
                return new[]
                {
                    new object[] {"VVS20222020"}
                };
            }
        }

        static IEnumerable<object[]> GlasaciSaIspravnimIdentifKodomITajnomSifrom
        {
            get
            {
                return new[]
                {
                    new object[] {"Nedzla", "Nekic", "Zmaja od Bosne rt",
                         DateTime.Parse("01/01/1998"), "123E456", "0101998123456", "NeNe12011/Zm", "VVS20222023"}
                };
            }
        }

        [TestMethod]
        [DynamicData("GlasaciSaJedinstvenimIdentifikacionimKodomITajnomSifrom")]
        public void TestNeuspjesnogRestartovanjaGlasanjaGlasaca(string ime, string prezime, string adresa, DateTime datumRodjenja, string brojLicneKarte, string maticniBroj, string identifikacioniKod, string tajnaSifra)
        {
            Glasac glasac = new Glasac(ime, prezime, adresa, datumRodjenja, brojLicneKarte, maticniBroj);
            glasac.glasajZaStranku(1);
            glasac.glasajZaKandidata(1);
            bool resetovanjeUspjesno = glasac.ResetovanjeInformacijaOGlasanju(identifikacioniKod, tajnaSifra, 2, 2);
            Assert.IsFalse(resetovanjeUspjesno);
        }

        [TestMethod]
        [DynamicData("PogresneTajneSifre")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPogresneTajne(string tajnasifra)
        {
            Glasac glasac = new Glasac("Emina", "Zolota", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
            glasac.glasajZaStranku(1);
            glasac.glasajZaKandidata(1);
            glasac.ResetovanjeInformacijaOGlasanju(glasac.JedinstveniIdentifikacijskiKod, "VVS20222010", 2, 2);
            glasac.ResetovanjeInformacijaOGlasanju(glasac.JedinstveniIdentifikacijskiKod, "VVS20222010", 2, 2);
            glasac.ResetovanjeInformacijaOGlasanju(glasac.JedinstveniIdentifikacijskiKod, tajnasifra, 2, 2);
        }

        [TestMethod]
        [DynamicData("GlasaciSaIspravnimIdentifKodomITajnomSifrom")]
        public void GlasaciSaIspravnimIdentifKodomITajnomSifrome(string ime, string prezime, string adresa, DateTime datumRodjenja, string brojLicneKarte, string maticniBroj, string identifikacioniKod, string tajnaSifra)
        {
            Glasac glasac = new Glasac(ime, prezime, adresa, datumRodjenja, brojLicneKarte, maticniBroj);
            glasac.glasajZaStranku(1);
            glasac.glasajZaKandidata(1);
            bool resetovanjeUspjesno = glasac.ResetovanjeInformacijaOGlasanju(identifikacioniKod, tajnaSifra, 2, 2);
            Assert.IsTrue(resetovanjeUspjesno);
        }

        // CSV testing
        public static IEnumerable<object[]> UčitajPodatkeCSV()
        {
            using (var reader = new StreamReader("TestEZ.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1],
                    elements[2], DateTime.Parse(elements[3]), elements[4], elements[5], elements[6], elements[7] };
                }
            }
        }

        static IEnumerable<object[]> GlasaciCSV
        {
            get
            {
                return UčitajPodatkeCSV();
            }
        }

        [TestMethod]
        [DynamicData("GlasaciCSV")]
        public void TestNeuspjesnogRestartovanjaGlasanjaGlasacaCSV(string ime, string prezime, string adresa, DateTime datumRodjenja, string brojLicneKarte, string maticniBroj, string identifikacioniKod, string tajnaSifra)
        {
            Glasac glasac = new Glasac(ime, prezime, adresa, datumRodjenja, brojLicneKarte, maticniBroj);
            glasac.glasajZaStranku(1);
            glasac.glasajZaKandidata(1);
            bool resetovanjeUspjesno = glasac.ResetovanjeInformacijaOGlasanju(identifikacioniKod, tajnaSifra, 2, 2);
            Assert.IsFalse(resetovanjeUspjesno);
        }

    }
}