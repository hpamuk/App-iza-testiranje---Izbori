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
    [TestClass]
    public class InlineCSVTestNH // INLINE I CSV TESTIRANJE ZA FUNKCIONALNOST - NEDŽLA HELAĆ
    {
        static IEnumerable<object[]> IspisBivsihStranki1
        {
            get
            {
                return new[]
                {
                    new object[] { "Kandidat Nejra Dedovic je bio član stranke ETF od 01/01/2020 do 03/01/2021." }
                };
            }
        }
        [TestMethod]
        [DynamicData("IspisBivsihStranki1")]
        public void BivseStranke1(string ispis)
        {
            Stranka stranka1 = new Stranka("ND");
            DateTime datum1 = new DateTime(2001, 11, 17);
            Kandidat k1 = new Kandidat("Nejra", "Dedovic", 1, datum1, "Srednja elektrotehnicka skola", false, stranka1);

            Stranka stranka2 = new Stranka("ETF");
            k1.dodajBivsuStranku(stranka2, DateTime.Parse("01/01/2020"), DateTime.Parse("01/03/2021"));
            Assert.AreEqual(ispis, k1.ispisiBivseStranke());
        }



        public static IEnumerable<object[]> UčitajPodatkeCSV()
        {
            using (var reader = new StreamReader("TestNH.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1], elements[2] };
                }
            }
        }

        static IEnumerable<object[]> IspisBivsihStranki2
        {
            get
            {
                return UčitajPodatkeCSV();
            }
        }

        [TestMethod]
        [DynamicData("IspisBivsihStranki2")]
        public void BivseStranke2(string naziv, string datump, string datumk)
        {
            Stranka stranka2 = new Stranka("NH");
            DateTime datum1 = new DateTime(2001, 2, 7);
            Kandidat k4 = new Kandidat("Nedzla", "Helac", 1, datum1, "Srednja elektrotehnicka skola", false, stranka2);

            Stranka stranka5 = new Stranka(naziv);
            k4.dodajBivsuStranku(stranka5, DateTime.Parse(datump), DateTime.Parse(datumk));
            Assert.AreEqual(1, k4.bivseStranke.Count);
        }



    }
}
