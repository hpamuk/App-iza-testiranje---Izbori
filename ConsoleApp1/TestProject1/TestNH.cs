using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    //u svim pojedinacnim testovima gdje je koristeno DateTime.Parse radjeno je po formatu mm/dd/yyyy

    [TestClass]
    public class TestNH
    {
        [TestMethod]
        public void TestProvjeraDodavanjaBivseStranke()
        {
            Stranka stranka2 = new Stranka("NH");
            DateTime datum1 = new DateTime(2001, 2, 7);
            Kandidat k4 = new Kandidat("Nedzla", "Helac", 1, datum1, "Srednja elektrotehnicka skola", false, stranka2);
            stranka2.kandidati.Add(k4);
            Stranka stranka4 = new Stranka("EZ");
            Stranka stranka5 = new Stranka("HP");
            DateTime datumP1 = new DateTime(2016, 1, 1);
            DateTime datumK1 = new DateTime(2017, 2, 1);
            DateTime datumP2 = new DateTime(2017, 6, 15);
            DateTime datumK2 = new DateTime(2018, 8, 17);
            k4.dodajBivsuStranku(stranka4, datumP1, datumK1);
            k4.dodajBivsuStranku(stranka5, datumP2, datumK2);
            Assert.AreEqual(2, k4.bivseStranke.Count);
        }

        [TestMethod]
        public void TestProvjereImenaBivseStranke()
        {
            Stranka stranka5 = new Stranka("ETF");
            Stranka stranka2 = new Stranka("NH");
            DateTime datum1 = new DateTime(2001, 2, 7);
            Kandidat k4 = new Kandidat("Nedzla", "Helac", 1, datum1, "Srednja elektrotehnicka skola", false, stranka2);
            DateTime datumP = new DateTime(2020, 2, 7);
            DateTime datumK = new DateTime(2022, 1, 1);
            k4.dodajBivsuStranku(stranka5, datumP, datumK);
            Assert.AreEqual("ETF", k4.bivseStranke[0].Item1.Naziv);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Kandidat se trenutno nalazi u ovoj stranci, nemoguce je tu stranku dodati u njegove bivse stranke!")]
        public void TestDodavanjaTrenutneStranke()
        {
            Stranka stranka2 = new Stranka("NH");
            DateTime datum1 = new DateTime(2001, 2, 7);
            Kandidat k4 = new Kandidat("Nedzla", "Helac", 1, datum1, "Srednja elektrotehnicka skola", false, stranka2);
            DateTime datumP = new DateTime(2020, 2, 7);
            DateTime datumK = new DateTime(2022, 1, 1);
            k4.dodajBivsuStranku(stranka2, datumP, datumK); 
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Mora se poslati period boravka kandidata u toj stranci!")]
        public void TestBezVremenaBoravka()
        {
            Stranka stranka2 = new Stranka("NH");
            DateTime datum1 = new DateTime(2001, 2, 7);
            Kandidat k4 = new Kandidat("Nedzla", "Helac", 1, datum1, "Srednja elektrotehnicka skola", false, stranka2);
            DateTime datum = new DateTime();
            k4.dodajBivsuStranku(stranka2, datum, datum);
        }

        [TestMethod]
        public void TestIspisaBivseStranke()
        {
            Stranka stranka2 = new Stranka("NH");
            DateTime datum1 = new DateTime(2001, 2, 7);
            Kandidat k4 = new Kandidat("Nedzla", "Helac", 1, datum1, "Srednja elektrotehnicka skola", false, stranka2);

            Stranka stranka5 = new Stranka("ETF");
            k4.dodajBivsuStranku(stranka5, DateTime.Parse("01/01/2020"), DateTime.Parse("01/03/2021"));
            Assert.AreEqual("Kandidat Nedzla Helac je bio član stranke ETF od 01/01/2020 do 03/01/2021.", k4.ispisiBivseStranke());
        }
        [TestMethod]
        public void TestIspisaBivsihStranki()
        {
            Stranka stranka2 = new Stranka("NH");
            DateTime datum1 = new DateTime(2001, 2, 7);
            Kandidat k4 = new Kandidat("Nedzla", "Helac", 1, datum1, "Srednja elektrotehnicka skola", false, stranka2);

            Stranka stranka5 = new Stranka("ETF");
            Stranka stranka6 = new Stranka("VVS");
            k4.dodajBivsuStranku(stranka5, DateTime.Parse("01/01/2020"), DateTime.Parse("01/03/2021"));
            k4.dodajBivsuStranku(stranka6, DateTime.Parse("08/05/2021"), DateTime.Parse("12/30/2021"));
            Assert.AreEqual("Kandidat Nedzla Helac je bio član stranke ETF od 01/01/2020 do 03/01/2021, član stranke VVS od 05/08/2021 do 30/12/2021.", k4.ispisiBivseStranke());
        }

    }
}
