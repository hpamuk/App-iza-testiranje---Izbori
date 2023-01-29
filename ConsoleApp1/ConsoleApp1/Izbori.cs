using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Izbori
    {
        public int godina;
        public int ukupanBrojPrijavljenih;
        public int ukupanBrojGlasaca;
        public static double izborniPrag1 = 0.02;
        public static double izborniPrag2 = 0.2;

        public List<Kandidat> kandidatiWinneri;
        public List<Stranka> strankeWinneri;
        public List<Stranka> stranke;
        public List<Kandidat> nezavisniKandidati;
        public static List<Glasac> glasaci = new List<Glasac>();

        public Izbori(int godina, int ukupanBrojPrijavljenih, int ukupanBrojGlasaca)
        {
            this.godina = godina;
            this.ukupanBrojPrijavljenih = ukupanBrojPrijavljenih;
            this.ukupanBrojGlasaca = ukupanBrojGlasaca;
            this.stranke = new List<Stranka>();
            this.nezavisniKandidati = new List<Kandidat>();
            glasaci = new List<Glasac>();
            this.kandidatiWinneri = new List<Kandidat>();
            this.strankeWinneri = new List<Stranka>();
        }

        public int Godina { get => godina; set => godina = value; }
        public int UkupanBrojPrijavljenih { get => ukupanBrojPrijavljenih; set => ukupanBrojPrijavljenih = value; }
        public int UkupanBrojGlasaca { get => ukupanBrojGlasaca; set => ukupanBrojGlasaca = value; }
        public static double IzborniPrag1 { get => izborniPrag1; set => izborniPrag1 = value; }
        public static double IzborniPrag2 { get => izborniPrag2; set => izborniPrag2 = value; }
        public List<Kandidat> KandidatiWinneri { get => kandidatiWinneri; set => kandidatiWinneri = value; }
        public double Izlaznost { get => UkupanBrojGlasaca / UkupanBrojPrijavljenih; }
        public List<Kandidat> NezavisniKandidati { get => nezavisniKandidati; set => nezavisniKandidati = value; }
        public List<Glasac> Glasaci { get => glasaci; set => glasaci = value; }

        public void Glasaj(Glasac g) // ova metoda je napravljena za slučaj kada se od korisnika traži da unosi podatke o strankama i kandidatima za koje će da glasa
        {
            int glas;
            Console.WriteLine("Unesite broj stranke za koju zelite glasati:\n1. ND, 2. NH, 3. EZ, 4. HP, 5. NK ili 0 ako zelite glasati za nezavisnog kandidata.");
            glas = Convert.ToInt32(Console.ReadLine());//unosi se broj stranke za koju je glasac glasao

            if (glas < 0 || glas > 5) throw new Exception("Niste unijeli ispravan broj!");//provjerava se da li je glasac unio ispravan broj

            g.glasajZaStranku(glas);

            if (glas == 0)//ukoliko je glasac glasao za nezavisnog kandidata
            {
                Console.WriteLine("Mozete glasati za jednog nezavisnog kandidata unosom njegovog rednog broja:\n ");
                foreach (Kandidat kandidat in nezavisniKandidati)//ispisuje nezavisne kandidate
                {
                    Console.WriteLine(kandidat.brojNaListi + ". " + kandidat.ime + " " + kandidat.prezime + "\n");
                }
                int glas1;
                glas1 = Convert.ToInt32(Console.ReadLine());//unosi se redni broj nezaivsnog kandidata
                if (glas < 0 || glas > nezavisniKandidati.Count) throw new Exception("Niste unijeli ispravan broj!");//provjerava se da li je glasac unio ispravan broj
                foreach (Kandidat kandidat in nezavisniKandidati)
                {
                    if (glas1 == kandidat.brojNaListi)
                    {
                        kandidat.dodajGlas();//dodaje se glas odabranom kandidatu
                        break;
                    }

                }
                g.glasajZaKandidata(glas1);
                Console.WriteLine("Vas glas je uspjesno zabiljezen. Hvala!");
            }
            else
            {   //ukoliko glasac zeli glasati za stranku
                for (int i = 0; i < stranke.Count; i++)
                {
                    if (glas - 1 == i)//provjera za koju je stranku glasac glasao
                    {
                        Console.WriteLine("Da li zelite glasati za kandidate iz stranke za koju ste glasali ? (0 - NE, 1 - DA)");
                        int glas2;
                        glas2 = Convert.ToInt32(Console.ReadLine());//unosi se da li glasac zeli glasati i za kandidate unutar stranke
                        if (glas < 0 || glas > 1) throw new Exception("Niste unijeli ispravan broj!");//provjerava se da li je glasac unio ispravan broj
                        if (glas2 == 0)//ukoliko je glasac odabrao da glasa samo za stranku
                        {
                            stranke[i].dodajGlasStranci();//dodaje se glas stranci
                            Console.WriteLine("Vas glas je uspjesno zabiljezen. Hvala!");
                            break;
                        }
                        else if (glas2 == 1)//ukoliko je glasac odabrao da glasa i za kandidate
                        {
                            stranke[i].dodajGlasStranci();//dodaje se glas za stranku
                            Console.WriteLine("Mozete glasati za jednog ili vise kandidata. Ako zelite glas dati kandidatu unesite njegov redni broj, usuprotnom unesite 0:\n ");
                            foreach (Kandidat kandidat in stranke[i].kandidati)
                            {
                                Console.WriteLine(kandidat.brojNaListi + ". " + kandidat.ime + " " + kandidat.prezime + "\n");
                                int glas3 = 0;
                                glas3 = Convert.ToInt32(Console.ReadLine());//unos rednog broja kandidata za kojeg glasac zeli da glasa
                                if (glas <= 0 || glas > stranke[i].kandidati.Count) throw new Exception("Niste unijeli ispravan broj!");//provjerava se da li je glasac unio ispravan broj

                                kandidat.dodajGlas();//dodaje se kandidatu glas
                                g.glasajZaKandidata(glas3);
                                stranke[i].brojGlasova--;//ovdje oduzimamo od stranke glas jer nije potrebno za svakog kandidata dodati glas stranci
                            }
                            Console.WriteLine("Vas glas je uspjesno zabiljezen. Hvala!");
                            
                        }
                    }
                }
            }
            Console.WriteLine("Ako želite restartovati svoj glas, unesite 1, u suprotnom 0: ");
            int reset = 0;
            reset = Convert.ToInt32(Console.ReadLine());
            if (reset == 1)
            {
                while (true)
                {
                    Console.WriteLine("Unesite vas jedinstveni identifikacioni kod: ");
                    string kod = Console.ReadLine();
                    Console.WriteLine("Unesite tajnu sifru: ");
                    string sifra = Console.ReadLine();
                    Console.WriteLine("Unesite redni broj nove stranke za koju zelite glasati: ");
                    int s = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Unesite redni broj novog kandidata za koga zelite glasati: ");
                    int k = Convert.ToInt32(Console.ReadLine());
                    bool uspjesno = g.ResetovanjeInformacijaOGlasanju(kod, sifra, s, k);
                    if (uspjesno)
                    {
                        Console.WriteLine("Vas novi odabir je zabiljezen");
                    }
                    else
                    {
                        Console.WriteLine("Pogrešno ste unijeli identifikacioni kod ili tajnu sifru. Pokusajte ponovo.");
                    }
                }
            }

        }
        public bool OsvojilaMandat(Stranka stranka)
        {
            if (stranka.BrojGlasova >= izborniPrag1 * ukupanBrojGlasaca)
            {
                return true;
            }
            return false;
        }
        public bool OsvojiliMandat(Kandidat kandidat)
        {
            if (kandidat.DaLiJeNezavisan)
            {
                if (kandidat.BrojGlasova >= izborniPrag1 * ukupanBrojGlasaca)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (OsvojilaMandat(kandidat.stranka))
                {
                    if (kandidat.BrojGlasova >= izborniPrag2 * kandidat.stranka.BrojGlasova)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }

        }

        public void Glasaj(int s, List<int> k) // ova metoda je napravljena za slučaj kada se kroz kod unosi za koju stranku i kandidate će glasati glasač
        {
            if (s == 0)
            {
                for (int a = 0; a < k.Count; a++)
                {
                    int x = k[a];
                    for (int i = 0; i < nezavisniKandidati.Count; i++)
                    {
                        
                        if (x == i + 1)
                        {
                            Kandidat kandidat = nezavisniKandidati[i];
                            kandidat.dodajGlas();
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < stranke.Count; i++)
                {
                    if (s == i + 1)
                    {
                        stranke[i].dodajGlasStranci();


                        for (int a = 0; a < k.Count; a++)
                        {
                            int x = k[a];
                            for (int j = 0; j < stranke[i].kandidati.Count; j++)
                            {
                                
                                if (x == j + 1)
                                {
                                    Kandidat kandidat = stranke[i].kandidati[j];
                                    kandidat.dodajGlas();
                                    stranke[i].brojGlasova--;
                                }
                            }

                        }
                    }
                }
            }
        }



        public string TrenutniRezultati()
        { //presjek glasanja
            string ispis = "";
            foreach (Stranka stranka in stranke)
            {
                ispis = ispis + "Ime stranke: " + stranka.Naziv + "\nBroj glasova: " + stranka.BrojGlasova + "\nKandidati iz stranke:\n";
                List<Kandidat> kandidati = stranka.Kandidati;
                foreach (Kandidat kandidat in kandidati)
                {
                    ispis = ispis + "Ime kadidata: " + kandidat.Ime + " " + kandidat.Prezime + "\nBroj glasova: " + kandidat.BrojGlasova + "\n";
                }
            }
            return ispis;
        }

        public string KonacniRezultati()//FUNKCIONALNOST BROJ 3 DEDOVIĆ NEJRA
        {
            foreach (Stranka stranka in stranke)
            {
                if (OsvojilaMandat(stranka)) strankeWinneri.Add(stranka);
            }
            foreach (Kandidat kandidat in nezavisniKandidati)
            {
                if (OsvojiliMandat(kandidat)) kandidatiWinneri.Add(kandidat);
            }
            string ispis = "Stranke koje su osvojile mandat:\n";
            foreach (Stranka stranka in strankeWinneri)
            {
                ispis = ispis + stranka.Naziv + "\nUkupan broj osvojenih glasova: " +
                                stranka.brojGlasova + "\nPostotak osvojenih glasova: " +
                                Convert.ToDouble(stranka.brojGlasova) / ukupanBrojGlasaca * 100 + "%." + "\n";
                ispis = ispis + "Kandidati iz stranke koji su osvojili mandat: \n";
                foreach (Kandidat kandidat in stranka.kandidati)
                {
                    if (OsvojiliMandat(kandidat))
                    {
                        ispis = ispis + kandidat.Ime + " " + kandidat.Prezime +
                                "\nUkupan broj osvojenih glasova: " + kandidat.brojGlasova +
                                "\nPostotak osvojenih glasova: " + Convert.ToDouble(kandidat.brojGlasova) / stranka.brojGlasova * 100 + "%.\n";
                    }
                }

            }
            ispis = ispis + "Nezavisni kandidati koji su osvojili mandat:\n";
            foreach (Kandidat kandidat in kandidatiWinneri)
            {
                ispis = ispis + kandidat.Ime + " " + kandidat.Prezime +
                        "\nUkupan broj osvojenih glasova: " +
                        kandidat.brojGlasova + "\nPostotak osvojenih glasova: " +
                        Convert.ToDouble(kandidat.brojGlasova) / ukupanBrojGlasaca * 100 + "%." + "\n";
            }
            ispis = ispis + "Izlaznost na izborima je: " + (Convert.ToDouble(ukupanBrojGlasaca) / ukupanBrojPrijavljenih) * 100 + "%.";
            return ispis;
        }

        // FUNKCIONALNOST 4 HENA PAMUK
        public static string IdentifikacijskiKodZaKandidata(Kandidat k)
        {
            string kod = "";
            foreach (Glasac glasac in Izbori.glasaci)
            {
                if (k.Ime.Equals(glasac.Ime) && k.Prezime.Equals(glasac.Prezime))
                    kod = Glasac.IdentifikacioniKodMetoda(glasac);
            }
            return kod;
        } 

    }
}
