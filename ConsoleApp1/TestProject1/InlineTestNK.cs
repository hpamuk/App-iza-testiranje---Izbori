using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{

    //Testirao: Nadir Karaman

    [TestClass]
    public class InlineTestNK
    {
        static IEnumerable<object[]> Glasaci
        {
            get
            {
                return new[]
                {                 
                     new object[] { "", "Karaman", "Zmaja od Bosne bb", 
                         DateTime.Parse("04/29/2001"), "223E411", "2904001170027"},

                     new object[] { "Nadir1", "Karaman", "Zmaja od Bosne bb", 
                         DateTime.Parse("04/29/2001"), "223E411", "2904001170027"},

                     new object[] {"Nadirnadirnadirnadirnadirnadirnadirnadirn", "Karaman", "Zmaja od Bosne bb", 
                         DateTime.Parse("04/29/2001"), "223E411", "2904001170027"},

                     new object[] { "N", "Karaman", "Zmaja od Bosne bb",
                         DateTime.Parse("04/29/2001"), "223E411", "2904001170027"},

                     new object[] { "Nadir", "", "Zmaja od Bosne bb",
                         DateTime.Parse("04/29/2001"), "223E411", "2904001170027"},

                     new object[] {"Nadir", "Kar$man", "Zmaja od Bosne bb",
                         DateTime.Parse("04/29/2001"), "223E411", "2904001170027"},

                     new object[] {"Nadir", "Karamankaramankaramankaramankaramankaramankaramanka", "Zmaja od Bosne bb", 
                         DateTime.Parse("04/29/2001"), "223E411", "2904001170027"},

                     new object[] {"Nadir", "Ka", "Zmaja od Bosne bb",
                         DateTime.Parse("04/29/2001"), "223E411", "2904001170027"},

                     new object[] {"Nadir", "Karaman", "",
                         DateTime.Parse("04/29/2001"), "223E411", "2904001170027"},

                     new object[] {"Nadir", "Karaman", "Zmaja od Bosne bb",
                         DateTime.Parse("04/29/2023"), "223E411", "2904001170027"},

                     new object[] {"Nadir", "Karaman", "Zmaja od Bosne bb",
                         DateTime.Parse("04/29/2001"), "223411", "2904001170027"},

                     new object[] {"Nadir", "Karaman", "Zmaja od Bosne bb",
                         DateTime.Parse("04/29/2001"), "223A411", "2904001170027"},

                     new object[] {"Nadir", "Karaman", "Zmaja od Bosne bb",
                         DateTime.Parse("04/29/2001"), "2J3E411", "2904001170027"},

                     new object[] {"Nadir", "Karaman", "Zmaja od Bosne bb",
                         DateTime.Parse("04/29/2001"), "223E411", "290400117007"},

                     new object[] {"Nadir", "Karaman", "Zmaja od Bosne bb",
                         DateTime.Parse("04/29/2001"), "223411", "2904001170027"},

                     new object[] {"Nadir", "Karaman", "Zmaja od Bosne bb",
                          DateTime.Parse("04/29/2001"), "223E411", "2804001170027"},

                     new object[] {"Nadir", "Karaman", "Zmaja od Bosne bb", 
                         DateTime.Parse("04/29/2001"), "223E411", "2903001170027"},

                     new object[] { "Nadir", "Karaman", "Zmaja od Bosne bb", 
                         DateTime.Parse("04/29/2001"), "223E411", "2904004170027" }
                };
            }
        }

        static IEnumerable<object[]> Glasaci2
        {
            get
            {
                return new[]
                {
                    new object[] {"Nadir", "Karaman", "Zmaja od Bosne bb",
                         DateTime.Parse("11/09/2001"), "223E411", "0911001170027"},

                    new object[] { "Nadir", "Karaman", "Zmaja od Bosne bb",
                         DateTime.Parse("04/29/2001"), "223E411", "2904001170027"},

                    new object[] { "Nadir", "Karaman-Karaman", "Zmaja od Bosne bb",
                         DateTime.Parse("04/29/2001"), "223E411", "2904001170027"},

                    new object[] { "Nadir-Nadir", "Karaman", "Zmaja od Bosne bb",
                         DateTime.Parse("04/29/2001"), "223E411", "2904001170027"}
                };
            }
        }

        [TestMethod]
        [DynamicData("Glasaci")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestKonstruktoraGlasaca(string ime, string prezime, string adresa, DateTime datumRodjenja, string brojLicneKarte, string maticniBroj)
        {
            Glasac glasac = new Glasac(ime, prezime, adresa, datumRodjenja, brojLicneKarte, maticniBroj);
        }

        [TestMethod]
        [DynamicData("Glasaci2")]
        public void TestKonstruktoraGlasaca2(string ime, string prezime, string adresa, DateTime datumRodjenja, string brojLicneKarte, string maticniBroj)
        {
            Glasac glasac = new Glasac(ime, prezime, adresa, datumRodjenja, brojLicneKarte, maticniBroj);

            StringAssert.Equals(ime, glasac.Ime);
            StringAssert.Equals(prezime, glasac.Prezime);
            StringAssert.Equals(adresa, glasac.Adresa);
            Assert.AreEqual(datumRodjenja, glasac.DatumRodjenja);
            StringAssert.Equals(brojLicneKarte, glasac.BrojLicneKarte);
            StringAssert.Equals(maticniBroj, glasac.MaticniBroj);
        }
    }
}