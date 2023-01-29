using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace TestProject1
{
    [TestClass]
    public class CodeTuning
    {
        [TestMethod]
        public void TestTuning()
        {
            Izbori izbori = new Izbori(2022, 10, 5);
            Stranka stranka1 = new Stranka("ND");
            Stranka stranka2 = new Stranka("NH");
            DateTime datum = new DateTime(2001, 11, 17);
            Kandidat k1 = new Kandidat("Nejra", "Dedovic", 1, datum, "Srednja elektrotehnicka skola", false, stranka1);
            Kandidat k2 = new Kandidat("Neko", "Nekic", 2, datum, "Srednja masinska skola", false, stranka1);
            Kandidat k3 = new Kandidat("Huso", "Husic", 3, datum, "Treca gimnazija", false, stranka1);
            izbori.stranke.Add(stranka1);
            DateTime datum1 = new DateTime(2001, 2, 7);
            Kandidat k4 = new Kandidat("Nedzla", "Helac", 1, datum1, "Srednja elektrotehnicka skola", false, stranka2);
            Kandidat k5 = new Kandidat("Suljo", "Suljic", 2, datum1, "Prva gimnazija", false, stranka2);
            Kandidat k6 = new Kandidat("Mujo", "Mujic", 3, datum1, "Srednja ekonomska skola", false, stranka2);
            izbori.stranke.Add(stranka2);
            DateTime datum6 = new DateTime(1995, 6, 3);
            Glasac g1 = new Glasac("Nejra", "Helac", "Zmaja od Bosne bb", datum6, "123E456", "0306995123456");
            List<int> lista1 = new List<int> { 1, 2, 3 };
            //prvi breakpoint
            int x = 0;
            for (int i = 0; i < 70000000; i++)
            {   
                izbori.Glasaj(1, lista1);
            }
            //drugi breakpoint
            int y = 0;
            Assert.IsTrue(true);
        }
    }
}
