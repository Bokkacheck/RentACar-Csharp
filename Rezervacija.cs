using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatProba
{
    class Rezervacija
    {
        DateTime pocetakRezervacije;
        DateTime krajRezervacije;
        int idbrAuta;
        int idbrKupca;
        double cena;

        public override string ToString()
        {
            return "IDBR auta: " + idbrAuta + " Pocetak rezervacije: " + pocetakRezervacije.ToString("dd/MM/yyyy") + " Kraj rezervacije: " + krajRezervacije.ToString("dd/MM/yyyy");
        } 
        public Rezervacija(DateTime pocetakRezervacije, DateTime krajRezervacije, int idbrAuta, int idbrKupca, double cena)
        {
            this.pocetakRezervacije = pocetakRezervacije.Date;
            this.krajRezervacije = krajRezervacije.Date;
            this.idbrAuta = idbrAuta;
            this.idbrKupca = idbrKupca;
            this.cena = cena;
        }
        public static void sortirajRezervacije(List<Rezervacija> rezervacije)
        {
            for (int i = 0; i < rezervacije.Count - 1; i++)
            {
                for (int j = i + 1; j < rezervacije.Count; j++)
                {
                    if (rezervacije[i].idbrAuta > rezervacije[j].idbrAuta)
                    {
                        Rezervacija pomoc = rezervacije[i];
                        rezervacije[i] = rezervacije[j];
                        rezervacije[j] = pomoc;
                    }
                }
            }
            int pocetak = 0;
            for (int i = 0; i < rezervacije.Count; i++)
            {
                if (i != rezervacije.Count - 1)
                    if (rezervacije[i].idbrAuta == rezervacije[i + 1].idbrAuta)
                    {
                        continue;
                    }
                for (int j = pocetak; j < i; j++)
                {
                    for (int k = j + 1; k < i + 1; k++)
                    {
                        if (rezervacije[j].pocetakRezervacije.Date > rezervacije[k].pocetakRezervacije.Date)
                        {
                            Rezervacija pomoc = rezervacije[j];
                            rezervacije[j] = rezervacije[k];
                            rezervacije[k] = pomoc;
                        }
                    }
                }
                pocetak = i + 1;
            }
        }  
        public static void izmenaIdbrKorisnik(List<Rezervacija> rezervacije,int stari,int novi)
        {
            for(int i = 0; i < rezervacije.Count; i++)
            {
                if (rezervacije[i].idbrKupca == stari)
                {
                    rezervacije[i].idbrKupca = novi;
                }
            }
        }
        public static void izmenaIdbrAuto(List<Rezervacija> rezervacije, int stari, int novi)
        {
            for(int i = 0;i<rezervacije.Count;i++)
            {
                if(rezervacije[i].idbrAuta == stari)
                {
                    rezervacije[i].idbrAuta = novi;
                }
            }
        }
        public static void obrisiRezervaciju(List<Rezervacija> rezervacije,int idbrKupac)
        {
            for(int i = 0; i < rezervacije.Count; i++)
            {
                if(rezervacije[i].idbrKupca == idbrKupac)
                {
                    rezervacije.RemoveAt(i--);
                }
            }
        }
        public static void obrisiTrazenuRezervaciju(List<Rezervacija> rezervacije, int idbrKupac, int selektovanIndex)
        {
            int brojac = 0;
            for (int i = 0; i < rezervacije.Count; i++)
            {
                if (idbrKupac == rezervacije[i].IdbrKupca)
                {
                    if (selektovanIndex == brojac)
                    {
                        rezervacije.RemoveAt(i);
                        break;
                    }
                    brojac++;
                }
            }
        }
        public DateTime PocetakRezervacije { get => pocetakRezervacije.Date; set => pocetakRezervacije = value; }
        public DateTime KrajRezervacije { get => krajRezervacije.Date; set => krajRezervacije = value; }
        public int IdbrAuta { get => idbrAuta; set => idbrAuta = value; }
        public int IdbrKupca { get => idbrKupca; set => idbrKupca = value; }
        public double Cena { get => cena; set => cena = value; }
    }
}
