using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatProba
{
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    class Ponuda
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
    {
        int idbrAuta;
        DateTime datumOd;
        DateTime datumDo;
        double cenaDan;
        public Ponuda(int idbrAuta, DateTime datumOd, DateTime datumDo, double cenaDan)
        {
            this.idbrAuta = idbrAuta;
            this.datumOd = datumOd.Date;
            this.datumDo = datumDo.Date;
            this.cenaDan = cenaDan;
        }
        public override string ToString()
        {
            return "IDBR auta:" + idbrAuta + " Datum od: "+DatumOd.ToString("dd/MM/yyyy") + " Datum do: " + datumDo.ToString("dd/MM/yyyy") + " Cena:" +cenaDan;
        }
        public static void azurirajDatum(List<Ponuda> ponude)
        {
            for(int i = 0;i < ponude.Count; i++)
            {
                if(ponude[i].datumOd.Date < DateTime.Now.Date)
                {
                    ponude[i].datumOd = DateTime.Now.Date;
                }
                if(ponude[i].datumDo.Date < DateTime.Now.Date)
                {
                    ponude.RemoveAt(i--);
                }
            }
        }
        public static bool obrisiPonuda(List<Ponuda> ponude,Ponuda ponuda)
        {
            for(int i = 0; i < ponude.Count; i++)
            {
                if (ponude[i] == ponuda)
                {
                    ponude.RemoveAt(i);
                    return true;
                }
            }
            return false;

        }
        public static bool obrisiPonuda(List<Ponuda> ponude, string idbrAuta)
        {
            for(int i = 0; i < ponude.Count; i++)
            {
                if(ponude[i].idbrAuta+"" == idbrAuta)
                {
                    ponude.RemoveAt(i--);
                }
            }
            return true;
        }
        public static void sortirajPonudu(List<Ponuda> ponude)
        {
            for(int i = 0; i < ponude.Count-1; i++)
            {
                for(int j = i+1; j< ponude.Count; j++)
                {
                    if (ponude[i].idbrAuta > ponude[j].idbrAuta)
                    {
                        Ponuda pomoc = ponude[i];
                        ponude[i] = ponude[j];
                        ponude[j] = pomoc;
                    }
                }
            }
            int pocetak = 0;
            for (int i = 0; i < ponude.Count; i++)
            {
                if(i!=ponude.Count-1)
                if (ponude[i].idbrAuta == ponude[i+1].idbrAuta)
                {
                    continue;
                }
                for(int j = pocetak; j < i; j++)
                {
                    for(int k = j + 1; k < i+1; k++)
                    {
                        if (ponude[j].datumOd.Date > ponude[k].datumOd.Date)
                        {
                            Ponuda pomoc = ponude[j];
                            ponude[j] = ponude[k];
                            ponude[k] = pomoc;
                        }
                    }
                }
                pocetak = i + 1;
            }
        }
        public static bool dodajPonuda(List<Ponuda> ponude,Ponuda ponuda)
        {
            if (proveraPonuda(ponude, ponuda))
            {
                ponude.Add(ponuda);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool izmenaIdbr(List<Ponuda> ponude,string stariIdbr,string noviIdbr)
        {
            for(int i = 0; i < ponude.Count; i++)
            {
                if(ponude[i].idbrAuta+"" == stariIdbr)
                {
                    ponude[i].idbrAuta = int.Parse(noviIdbr);
                }
            }
            return true;
        }
        public static bool proveraPonuda(List<Ponuda> ponude, Ponuda ponuda)
        {
            for (int i = 0; i < ponude.Count; i++)
            {
                if (ponude[i].idbrAuta==ponuda.idbrAuta)
                {
                    if(!((ponuda.datumOd.Date < ponude[i].datumOd.Date && ponuda.datumDo.Date < ponude[i].datumOd.Date)|| (ponuda.datumOd.Date > ponude[i].datumDo.Date && ponuda.datumDo.Date > ponude[i].datumDo.Date)))
                    {
                        MessageBox.Show("Automobil se vec nalazi u nekoj ponudi u ovom periodu");
                        return false;
                    }
                }
                if(ponude[i] == ponuda)
                {
                    MessageBox.Show("Vec postoji ovakva ponuda");
                    return false;
                }
            }
            return true;
        }
        public static bool operator==(Ponuda prva,Ponuda druga)
        {
            if (prva.idbrAuta == druga.idbrAuta && prva.datumOd.Date == druga.datumOd.Date && prva.datumDo.Date == druga.datumDo.Date && prva.cenaDan == druga.cenaDan)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Ponuda prva, Ponuda druga)
        {
            if (prva.idbrAuta == druga.idbrAuta && prva.datumOd.Date == druga.datumOd.Date && prva.datumDo.Date == druga.datumDo.Date && prva.cenaDan == druga.cenaDan)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int IdbrAuta { get => idbrAuta; set => idbrAuta = value; }
        public DateTime DatumOd { get => datumOd.Date; set => datumOd = value.Date; }
        public DateTime DatumDo { get => datumDo.Date; set => datumDo = value.Date; }
        public double CenaDan { get => cenaDan; set => cenaDan = value; }
    }
}
