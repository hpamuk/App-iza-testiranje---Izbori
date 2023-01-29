using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class TestNK
    {
        //Testirao: Nadir Karaman

        [TestMethod]
        public void TestPodatakaOk()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
            StringAssert.Equals("Nadir", glasac.Ime);
            StringAssert.Equals("Karaman", glasac.Prezime);
            StringAssert.Equals("Zmaja od Bosne bb", glasac.Adresa);
            Assert.AreEqual(DateTime.Parse("04/29/2001"), glasac.DatumRodjenja);
            StringAssert.Equals("223E411", glasac.BrojLicneKarte);
            StringAssert.Equals("2904001170027", glasac.MaticniBroj);
        }

        [TestMethod]
        public void TestImenaSCrticomOk()
        {
            Glasac glasac = new Glasac("Nadir-Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
            StringAssert.Equals("Nadir-Nadir", glasac.Ime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPraznogImena()
        {
            Glasac glasac = new Glasac("", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNedozvoljenogZnakaUImenu()
        {
            Glasac glasac = new Glasac("Nadir1", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPredugogImena()
        {
            Glasac glasac = new Glasac("Nadirnadirnadirnadirnadirnadirnadirnadirn", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPrekratkogImena()
        {
            Glasac glasac = new Glasac("N", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
        }

        [TestMethod]
        public void TestPrezimenaSCrticomOk()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman-Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
            StringAssert.Equals("Karaman-Karaman", glasac.Prezime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPraznogPrezimena()
        {
            Glasac glasac = new Glasac("Nadir", "", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNedozvoljenogZnakaUPrezimenu()
        {
            Glasac glasac = new Glasac("Nadir", "Kar$man", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPredugogPrezimena()
        {
            Glasac glasac = new Glasac("Nadir", "Karamankaramankaramankaramankaramankaramankaramanka", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPrekratkogPrezimena()
        {
            Glasac glasac = new Glasac("Nadir", "Ka", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPrazneAdrese()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDatumUBuducnosti()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2023"), "223E411", "2904001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGlasacNijePunoljetan()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2006"), "223E411", "2904001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDuzinaLicneKarte()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223411", "2904001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNedozvoljenoSlovo()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223A411", "2904001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNedozvoljeniSimbol()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "2J3E411", "2904001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDuzinaMaticnogBroja()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "290400117007");
        }

        [TestMethod]
        public void TestMaticnogBroja()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("11/09/2001"), "223E411", "0911001170027");
            StringAssert.Equals("0911001170027", glasac.MaticniBroj);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDanMaticnogBroja()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2804001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMjesecMaticnogBroja()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2903001170027");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGodinaMaticnogBroja()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904004170027");
        }

    }
}
