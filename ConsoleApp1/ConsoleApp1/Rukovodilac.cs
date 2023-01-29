using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Rukovodilac // FUNKCIONALNOST 4 HENA PAMUK
    {
        public string ime;
        public string prezime;
        private DateTime datumRodjenja;
        private string zavrsenaSkola;
        public Stranka stranka;


        public Rukovodilac(string ime, string prezime, DateTime datumRodjenja, string zavrsenaSkola, Stranka stranka)
        {
            // provjera da slucajno nije poslano prazno ime i prezime ili da nije zavrsena skola!
            if (string.IsNullOrWhiteSpace(ime) || string.IsNullOrWhiteSpace(prezime) ||
                string.IsNullOrWhiteSpace(zavrsenaSkola))
                throw new ArgumentException("Neko od polja je prazno!");
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.zavrsenaSkola = zavrsenaSkola;
            this.stranka = stranka;

        }


        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime DatumRodjenja
        {
            get => datumRodjenja; set => datumRodjenja = value;
        }
    }
}
