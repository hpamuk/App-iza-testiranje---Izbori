using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class Glasac
    {
        private string ime;
        private string prezime;
        private string adresa;
        private DateTime datumRodjenja;
        private string brojLicneKarte;
        private string maticniBroj;
        public string jedinstveniIdentifikacijskiKod;
        private int provjeraSifreZaResetovanjeInformacija = 0;
        private int strankaZaKojuGlasacGlasa = -1;
        private List<int> kandidatizaKojegGlasacGlasa = new List<int>();

        /* Funkcionalnost 1: 
        Sve lične informacije o glasačima trebaju biti validirane. Ime i prezime smiju sadržavati samo
        slova i crticu, a ostale vrste karaktera nisu dozvoljene.Ime se sastoji od minimalno 2, a
        maksimalno 40 slova, dok se prezime sastoji od minimalno 3, a maksimalno 50 slova.Ime,
        prezime i adresa ne smiju biti prazni.Svaki glasač mora biti punoljetan i njegov datum rođenja
        ne može biti u budućnosti. Broj lične karte uvijek se sastoji od tačno 7 karaktera u formatu
        999A999, pri čemu 9 može biti bilo koji broj, a A bilo koje slovo iz skupa (E, J, K, M, T). Matični
        broj se mora sastojati od 13 brojeva, pri čemu prva dva broja odgovaraju danu, sljedeća dva
        broja mjesecu, a sljedeća tri broja godini rođenja glasača.Validacijom se treba pokriti i
        jedinstveni identifikacioni broj glasača.
        
        Radio: Nadir Karaman */

        public Glasac(string ime, string prezime, string adresa, DateTime datumRodjenja, string brojLicneKarte, string maticniBroj)
        {
            if (validnoIme(ime)) this.Ime = ime;
            if (validnoPrezime(prezime)) this.Prezime = prezime;
            if (validnaAdresa(adresa)) this.Adresa = adresa;
            if (validanDatumRodjenja(datumRodjenja)) this.DatumRodjenja = datumRodjenja;
            if (validanBrojLicneKarte(brojLicneKarte)) this.BrojLicneKarte = brojLicneKarte;
            if (validanMaticniBroj(maticniBroj)) this.MaticniBroj = maticniBroj;
            string kod = IdentifikacioniKodMetoda(this);
            if (validanIdentifikacioniBroj(kod)) this.JedinstveniIdentifikacijskiKod = kod;
        }

        public bool validnoIme(string ime)
        {
            if (string.IsNullOrWhiteSpace(ime)) throw new ArgumentException("Ime je prazno!", ime);
            if(!Regex.IsMatch(ime, @"^[a-zA-Z-]+$")) throw new ArgumentException("Ime sadrži nedozvoljen znak!", ime);
            if(ime.Length < 2 || ime.Length > 40) throw new ArgumentException("Ime je nekorektne dužine!", ime);
            return true;
        }

        public bool validnoPrezime(string prezime)
        {
            if (string.IsNullOrWhiteSpace(prezime)) throw new ArgumentException("Prezime je prazno!", prezime);
            foreach (char c in prezime)
            {
                if (c == '-' || Char.IsLetter(c)) continue;
                else throw new ArgumentException("Prezime sadrži nedozvoljen znak!", prezime);
            }
            if (prezime.Length < 3 || prezime.Length > 50) throw new ArgumentException("Prezime je nekorektne dužine!", prezime);
            return true;
        }
        public bool validnaAdresa(string adresa)
        {
            if (string.IsNullOrWhiteSpace(adresa)) throw new ArgumentException("Adresa je prazna!", adresa);
            return true;
        }

        public bool validanDatumRodjenja(DateTime datumRodjenja)
        {
            if (DateTime.Compare(datumRodjenja, DateTime.Now) >= 0) throw new ArgumentException("Datum rođenja je u budućnosti!", datumRodjenja.ToString("dd/MM/yyyy HH:mm:ss"));
            if (datumRodjenja.AddYears(18) > DateTime.Now) throw new ArgumentException("Glasač nije punoljetan!", datumRodjenja.ToString("dd/MM/yyyy HH:mm:ss"));
            return true;
        }

        public bool validanBrojLicneKarte(string brojLicneKarte)
        {
            string provjera = "EJKMT";
            if (brojLicneKarte.Length != 7) throw new ArgumentException("Broj lične karte je nekorektne dužine!", brojLicneKarte);
            for (int i = 0; i < 7; i++)
            {
                if (i == 3 && !provjera.Contains(brojLicneKarte[i])) throw new ArgumentException("Broj lične karte sadrži nedozvoljene simbole!", brojLicneKarte);
                if (i != 3 && (brojLicneKarte[i] < '0' || brojLicneKarte[i] > '9')) throw new ArgumentException("Broj lične karte sadrži nedozvoljene simbole!", brojLicneKarte);
            }
            return true;
        }

        public bool validanMaticniBroj(string maticniBroj)
        {
            if (maticniBroj.Length != 13) throw new ArgumentException("Matični broj je nekorektne dužine!", maticniBroj);
            string test = datumRodjenja.Day.ToString("00") + datumRodjenja.Month.ToString("00") + datumRodjenja.Year.ToString().Substring(1);
            if (!maticniBroj.Substring(0, 2).Equals(test.Substring(0, 2))) throw new ArgumentException("Dan u matičnom broju je nekorektan!", maticniBroj);
            if (!maticniBroj.Substring(2, 2).Equals(test.Substring(2, 2))) throw new ArgumentException("Mjesec u matičnom broju je nekorektan!", maticniBroj);
            if (!maticniBroj.Substring(4, 3).Equals(test.Substring(4, 3))) throw new ArgumentException("Godina u matičnom broju je nekorektna!", maticniBroj);
            return true;
        }

        public bool validanIdentifikacioniBroj(string identifikacioniBroj)
        {
            string kod = "";
            kod = kod + ime.Substring(0, 2);
            kod = kod + prezime.Substring(0, 2);
            kod = kod + brojLicneKarte.Substring(0, 2);
            kod = kod + maticniBroj.Substring(0, 2);
            kod = kod + datumRodjenja.ToString().Substring(0, 2);
            kod = kod + adresa.Substring(0, 2);
            if (identifikacioniBroj != kod) return false;
            return true;
        }

        public string Ime
        {
            get { return ime; }
            set { if (validnoIme(value)) ime = value; }
        }
        public string Prezime
        {
            get { return prezime; }
            set { if (validnoPrezime(value)) prezime = value; }
        }
        public string Adresa {
            get { return adresa; }
            set { if (validnaAdresa(value)) adresa = value; }
        }
        public DateTime DatumRodjenja {
            get { return datumRodjenja; }
            set { if (validanDatumRodjenja(value)) datumRodjenja = value; }
        }
        public string BrojLicneKarte {
            get { return brojLicneKarte; }
            set { if (validanBrojLicneKarte(value)) brojLicneKarte = value; }
        }
        public string MaticniBroj {
            get { return maticniBroj; }
            set { if (validanMaticniBroj(value)) maticniBroj = value; }
        }
        public string JedinstveniIdentifikacijskiKod {
            get { return jedinstveniIdentifikacijskiKod; }
            set { if (validanIdentifikacioniBroj(value)) jedinstveniIdentifikacijskiKod = value; }
        }
        public int ProvjeraSifreZaResetovanjeInformacija { get => provjeraSifreZaResetovanjeInformacija; set => provjeraSifreZaResetovanjeInformacija = value; }

        public int StrankaZaKojuGlasacGlasa { get => strankaZaKojuGlasacGlasa; set => strankaZaKojuGlasacGlasa = value; }
        
        public List<int> KandidatiZaKojeGlasacGlasa { get => kandidatizaKojegGlasacGlasa; set => kandidatizaKojegGlasacGlasa = value; }
        /*public string IdentifikacioniKodMetoda(string ime, string prezime, string brojLicne, string maticniBroj, DateTime datumRodjenja, string adresa)
        {
            string kod = ime.Substring(0, 2) + prezime.Substring(0, 2) + brojLicne.Substring(0, 2) + maticniBroj.Substring(0, 2)
                + datumRodjenja.ToString().Substring(0, 2) + adresa.Substring(0, 2);
            return kod;
        }*/

        // FUNKCIONALNOST 4 HENA PAMUK
        public static string IdentifikacioniKodMetoda(Glasac g)
        {
           string kod = g.Ime.Substring(0, 2) + g.Prezime.Substring(0, 2) + g.BrojLicneKarte.Substring(0, 2) + g.MaticniBroj.Substring(0, 2)
                            + g.DatumRodjenja.ToString().Substring(0, 2) + g.Adresa.Substring(0, 2);
           return kod;
          

        }

        public void glasajZaStranku(int s)
        {
            strankaZaKojuGlasacGlasa = s;
        }

        public void glasajZaKandidata(int k)
        {
            kandidatizaKojegGlasacGlasa.Add(k);
        }



        /*
         Funkcionalnost br. 5:
            Potrebno je omogućiti resetovanje informacija o glasanju za pojedinačne glasače u slučaju
            pogrešnog glasanja. Za reset informacija o glasanju potrebno je unijeti jedinstveni
            identifikacioni broj glasača i tajnu šifru koja glasi „VVS20222023“. Ukoliko se šifra unese
            pogrešno tri puta zaredom, potrebno je ispisati informaciju o grešci i prekinuti rad programa.
         Dodijeljeni student/studentica: Emina Zolota
        */

        public bool ResetovanjeInformacijaOGlasanjuValidacija (string jedinstveniIndentifikacioniKodGlasaca, string tajnaSifra)
        {
            bool uspjesnoResetovano = false;
            if (tajnaSifra != "VVS20222023")
            {
                provjeraSifreZaResetovanjeInformacija++;
                if (provjeraSifreZaResetovanjeInformacija >= 3)
                {
                    throw new ArgumentException("Tajna šifra unesena pogrešno tri puta zaredom.");
                    provjeraSifreZaResetovanjeInformacija = 0;
                }
                return uspjesnoResetovano;
            }

            if (jedinstveniIndentifikacioniKodGlasaca != this.jedinstveniIdentifikacijskiKod)
            {
                return uspjesnoResetovano;
            }

            

            strankaZaKojuGlasacGlasa = -1;
            kandidatizaKojegGlasacGlasa.Clear();

            uspjesnoResetovano = true;

            return uspjesnoResetovano;
        }

        public bool ResetovanjeInformacijaOGlasanju(string jedinstveniIndentifikacioniKodGlasaca, string tajnaSifra, int s, int k)
        {
            bool provjera = ResetovanjeInformacijaOGlasanjuValidacija(jedinstveniIndentifikacioniKodGlasaca, tajnaSifra);
            if (provjera)
            {
                glasajZaKandidata(k);
                glasajZaStranku(s);
            }
            return provjera;
        }

        public bool VjerodostojnostGlasaca(IProvjera sigurnosnaProvjera)
        {
            if (sigurnosnaProvjera.DaLiJeVecGlasao(JedinstveniIdentifikacijskiKod))
                throw new Exception("Glasač je već izvršio glasanje!");
            return true;
        }

    }
}