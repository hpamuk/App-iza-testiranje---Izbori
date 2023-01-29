using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class TestEZ
    {
        [TestMethod]
        public void TestResetovanjaGlasaOk()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
            glasac.glasajZaStranku(1);
            glasac.glasajZaKandidata(1);
            bool resetovanjeUspjesno = glasac.ResetovanjeInformacijaOGlasanju(glasac.JedinstveniIdentifikacijskiKod, "VVS20222023", 2, 2);
            Assert.IsTrue(resetovanjeUspjesno);
        }

        [TestMethod]
        public void TestPogresnogUnosaIdentifikacionogKoda()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
            glasac.glasajZaStranku(1);
            glasac.glasajZaKandidata(1);
            bool resetovanjeUspjesno = glasac.ResetovanjeInformacijaOGlasanju("1", "VVS20222023", 2, 2);
            Assert.IsFalse(resetovanjeUspjesno);
        }

        [TestMethod]
        public void TestPogresnogUnosaTajneSifreResetovanjeNeuspjesno()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
            glasac.glasajZaStranku(1);
            glasac.glasajZaKandidata(1);
            bool resetovanjeUspjesno = glasac.ResetovanjeInformacijaOGlasanju(glasac.jedinstveniIdentifikacijskiKod, "VVS20222", 2, 2);
            Assert.IsFalse(resetovanjeUspjesno);
        }

        [TestMethod]
        public void TestPogresnogUnosaTajneSifreInkrementiranjePokusaja()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
            glasac.glasajZaStranku(1);
            glasac.glasajZaKandidata(1);
            bool resetovanjeUspjesno = glasac.ResetovanjeInformacijaOGlasanju(glasac.JedinstveniIdentifikacijskiKod, "VVS20222", 2, 2);
            Assert.IsFalse(glasac.ProvjeraSifreZaResetovanjeInformacija == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Tajna šifra unesena pogrešno tri puta zaredom.")]
        public void TestBacanjaIzuzetkaZbogTriPutaPogresneSifre()
        {
            Glasac glasac = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
            glasac.glasajZaStranku(1);
            glasac.glasajZaKandidata(1);
            glasac.ResetovanjeInformacijaOGlasanju(glasac.JedinstveniIdentifikacijskiKod, "VVS202220", 2, 2);
            glasac.ResetovanjeInformacijaOGlasanju(glasac.JedinstveniIdentifikacijskiKod, "VVS202220", 2, 2);
            glasac.ResetovanjeInformacijaOGlasanju(glasac.JedinstveniIdentifikacijskiKod, "VVS202220", 2, 2);
        }
    }
}
