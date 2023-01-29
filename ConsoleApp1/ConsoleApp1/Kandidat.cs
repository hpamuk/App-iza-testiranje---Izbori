using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Kandidat
    {

        public string ime;
        public string prezime;
        public int brojNaListi;
        public bool daLiJeNezavisan;
        public Stranka stranka;
        public int brojGlasova;
        //detaljne informacije
        public DateTime datumRodjenja;
        public string zavrsenaSkola;
        public List<ValueTuple<Stranka, DateTime, DateTime>> bivseStranke; //ZA FUNKCIONLNOST BROJ 2


        public Kandidat(string ime, string prezime, int brojNaListi, DateTime datumRodjenja, string zavrsenaSkola, bool daLiJeNezavisan, Stranka stranka)
        {
            if (!sadrziSamoSlova(ime))
            {
                Console.WriteLine("Ime moze sadrzati samo slova!");
                return;
            }
            this.ime = ime;
            if (!sadrziSamoSlova(prezime))
            {
                Console.WriteLine("Prezime moze sadrzati samo slova!");
                return;
            }
            this.prezime = prezime;
            if (brojNaListi < 1)
            {
                Console.WriteLine("Broj na listi ne moze biti manji od 1!");
                return;
            }
            if (brojNaListi > 30)
            {
                Console.WriteLine("Lista sadrzi maksimalno 30 kandidata!");
                return;
            }


            this.brojNaListi = brojNaListi;
            this.datumRodjenja = datumRodjenja;
            this.zavrsenaSkola = zavrsenaSkola;
            this.daLiJeNezavisan = daLiJeNezavisan;
            this.stranka = stranka;
            this.brojGlasova = 0;
            this.bivseStranke = new List<ValueTuple<Stranka, DateTime, DateTime>>();
            if (stranka != null) stranka.dodajKandidata(this);
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public int BrojNaListi { get => brojNaListi; set => brojNaListi = value; }

        public bool DaLiJeNezavisan { get => daLiJeNezavisan; set => daLiJeNezavisan = value; }
        public int BrojGlasova { get => brojGlasova; set => brojGlasova = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public List<(Stranka, DateTime, DateTime)> BivseStranke { get => bivseStranke; set => bivseStranke = value; }

        public bool sadrziSamoSlova(string rijec)
        {
            foreach (char c in rijec)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }


        public void dodajGlas()
        {
            brojGlasova++;
            if (daLiJeNezavisan == false)
                stranka.dodajGlasStranci();
        }

        public void dodajBivsuStranku(Stranka s, DateTime pocetak, DateTime kraj) //FUNKCIONALNOST BROJ 2 NEDŽLA HELAĆ
        {
            if (s == stranka)
                throw new ArgumentException("Kandidat se trenutno nalazi u ovoj stranci, nemoguce je tu stranku dodati u njegove bivse stranke!");
            if (pocetak == null || kraj == null)
            {
                throw new ArgumentException("Mora se poslati period boravka kandidata u toj stranci!");
            }
            var bivsaS = ValueTuple.Create(s, pocetak, kraj);
            bivseStranke.Add(bivsaS);
        }
        public string ispisiBivseStranke() //FUNKCIONALNOST BROJ 2 NEDŽLA HELAĆ
        {
            string ispis = "";
            ispis = ispis + "Kandidat " + Ime + " " + Prezime + " je bio ";
            int i = 0;
            foreach (var s in bivseStranke)
            {

                ispis = ispis + "član stranke " + s.Item1.Naziv + " od " + s.Item2.Date.ToString("dd'/'MM'/'yyyy") + " do "
                        + s.Item3.ToString("dd'/'MM'/'yyyy");
                if (i != bivseStranke.Count - 1)
                    ispis = ispis + ", ";
                else
                    ispis = ispis + ".";
                i++;

            }
            return ispis;
        }
    }
}
