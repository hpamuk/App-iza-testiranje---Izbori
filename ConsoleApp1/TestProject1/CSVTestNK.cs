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

    //Testirao: Nadir Karaman
    
    [TestClass]
    public class CSVTestNK
    {
        public static IEnumerable<object[]> UčitajPodatkeCSV()
        {
            using (var reader = new StreamReader("TestNK.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1], elements[2],
                    DateTime.Parse(elements[3]), elements[4], elements[5] };
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
        [ExpectedException(typeof(ArgumentException))]
        public void TestKonstruktoraGlasacaCSV(string ime, string prezime, string adresa, DateTime datumRodjenja, string brojLicneKarte, string maticniBroj)
        {
            Glasac glasac = new Glasac(ime, prezime, adresa, datumRodjenja, brojLicneKarte, maticniBroj);
        }
    }
}
