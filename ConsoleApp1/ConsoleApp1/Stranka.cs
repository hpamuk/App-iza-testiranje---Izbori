using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Stranka
    {
        public string naziv;
        public static int redniBroj = 0;
        public List<Kandidat> kandidati;
        public int brojGlasova;
        public List<Rukovodilac> rukovodstvo;


        public Stranka(string naziv)
        {
            this.naziv = naziv;
            this.RedniBroj = this.RedniBroj+1;
            this.brojGlasova = 0;
            kandidati = new List<Kandidat>();
            rukovodstvo = new List<Rukovodilac>();

        }

        public string Naziv { get => naziv; set => naziv = value; }
        public int RedniBroj { get => redniBroj; set => redniBroj = value; }
        public List<Kandidat> Kandidati { get => kandidati; set => kandidati = value; }
        public int BrojGlasova { get => brojGlasova; }

        public List<Rukovodilac> Rukovodstvo { get => rukovodstvo; set => rukovodstvo = value; }

       
        public void dodajKandidata(Kandidat kandidat)
        {
            kandidati.Add(kandidat);
        }

        public void ukloniKandidata(Kandidat kandidat)
        {
            kandidati.Remove(kandidat);
        }

        public void dodajGlasStranci()
        {
            brojGlasova++;
        }


        // FUNKCIONALNOST 4 HENA PAMUK
        public List<Kandidat> napraviListuRukovodiocaIKandidata(List<Kandidat> listaK, List<Rukovodilac> listaR)
        {
            List<Kandidat> rukovodiociKandidati = new List<Kandidat>();
            foreach (Kandidat kandidat in listaK)
            {
                Boolean postoji = false;
                foreach (Rukovodilac rukovodilac in listaR)
                {
                    if (kandidat.Ime.Equals(rukovodilac.Ime) && 
                        kandidat.Prezime.Equals(rukovodilac.Prezime) && 
                        kandidat.stranka.Equals(rukovodilac.stranka) &&
                        kandidat.datumRodjenja.Equals(rukovodilac.DatumRodjenja))
                    {
                        postoji = true;
                        break;
                    }
                }
                if (postoji)
                {
                    rukovodiociKandidati.Add(kandidat);
                }
            }
            return rukovodiociKandidati;
        }

        // FUNKCIONALNOST 4 HENA PAMUK 
        public int sumaRukovociocaKandidata(List<Kandidat> rukovodiociKandidati)
        {
            int sumaGlasova = 0;
            foreach (Kandidat kandidat in rukovodiociKandidati)
            {
                sumaGlasova = sumaGlasova + kandidat.brojGlasova;
            }
            return sumaGlasova;
        }

        // FUNKCIONALNOST 4 HENA PAMUK
        public string ispisRukovodstvaStrankeKojiSuKandidati() 
        {
            List<Kandidat> rukovodiociKandidati = napraviListuRukovodiocaIKandidata(kandidati, rukovodstvo);
            int sumaGlasova = sumaRukovociocaKandidata(rukovodiociKandidati);

            // pravljenje stringa za ispis
            string ispis = "";
            ispis = ispis + "Ukupan broj glasova: " + sumaGlasova + "\n";
            ispis = ispis + "Kandidati:\n";

            foreach (Kandidat kandidat in rukovodiociKandidati)
            {
                ispis = ispis + "Identifikacioni broj: ";
                ispis = ispis + Izbori.IdentifikacijskiKodZaKandidata(kandidat) + "\n";
            }
            return ispis;
        } 
    }
}
