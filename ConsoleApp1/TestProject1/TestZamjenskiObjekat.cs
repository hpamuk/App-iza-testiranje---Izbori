using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class TestZamjenskiObjekat
    {

        [TestMethod]
        public void TestVjerodostojnostGlasaca()
        {
            Izbori izbori = new Izbori(2022, 2, 2);

            Glasac glasac1 = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");
            Glasac glasac2 = new Glasac("Nadir-Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("03/25/2000"), "223E411", "2503000170027");

            izbori.Glasaci.Add(glasac1);
            izbori.Glasaci.Add(glasac2);

            Spy spy = new Spy();

            glasac1.glasajZaStranku(1);
            glasac2.glasajZaStranku(1);

            Assert.IsTrue(spy.DaLiJeVecGlasao(glasac1.JedinstveniIdentifikacijskiKod));
            Assert.IsTrue(spy.DaLiJeVecGlasao(glasac2.JedinstveniIdentifikacijskiKod));
            Assert.IsFalse(spy.DaLiJeVecGlasao("kkkk"));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestVjerodostojnostGlasacaVecGlasao()
        {
            Izbori izbori = new Izbori(2022, 2, 2);

            Glasac glasac1 = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");

            izbori.Glasaci.Add(glasac1);

            Spy spy = new Spy();

            glasac1.glasajZaStranku(1);

            glasac1.VjerodostojnostGlasaca(spy);
        }

        [TestMethod]
        public void TestVjerodostojnostGlasacaNijeGlasao()
        {
            Izbori izbori = new Izbori(2022, 2, 2);

            Glasac glasac1 = new Glasac("Nadir", "Karaman", "Zmaja od Bosne bb", DateTime.Parse("04/29/2001"), "223E411", "2904001170027");

            izbori.Glasaci.Add(glasac1);

            Spy spy = new Spy();

            Assert.IsTrue(glasac1.VjerodostojnostGlasaca(spy));
            
        }
    }
}
