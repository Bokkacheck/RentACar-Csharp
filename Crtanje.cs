using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProjekatProba
{
    public static class Crtanje
    {
        private static Random rnd = new Random();
        public static void crtajMesec(Graphics g, int ukupnoDana, List<int> daniPosebno,Rectangle okvir)
        {
            SolidBrush boja = new SolidBrush(Color.Black);
            float pocetak = -90;
            int brojac = 0;
            for(int i = 0;i < daniPosebno.Count; i++)
            {
                if (daniPosebno[i] != 0) brojac++;
            }
            if(brojac!=0)
            brojac = 255 / (brojac+1);
            int mnozi = 0;
            for (int i = 0;i< daniPosebno.Count; i++)
            {
                if (daniPosebno[i] != 0)
                {
                    boja.Color = Color.FromArgb(255%brojac, 255,255%(i+1));
                    switch (i%4)
                    {
                        case 0:
                            boja.Color = Color.FromArgb(255,brojac,brojac*mnozi);
                            break;
                        case 1:
                            boja.Color = Color.FromArgb(brojac*mnozi, 255, brojac);
                            break;
                        case 2:
                            boja.Color = Color.FromArgb(brojac, brojac*mnozi, brojac);
                            break;
                        case 3:
                            boja.Color = Color.FromArgb(brojac*mnozi, 255, 255);
                            break;
                    }
                    g.FillPie(boja, okvir, pocetak, (float)((360.0/ukupnoDana) * daniPosebno[i]));
                    pocetak += (float)((360.0 / ukupnoDana) * daniPosebno[i]);
                    mnozi++;
                }
            }
        }
        public static void crtajBoje(Graphics g,Panel p,List<int>daniPosebno)
        {
            SolidBrush boja = new SolidBrush(Color.Black);
            int brojac = 0;
            for (int i = 0; i < daniPosebno.Count; i++)
            {
                if (daniPosebno[i] != 0) brojac++;
            }
            if (brojac != 0)
                brojac = 255 / (brojac + 1);
            int mnozi = 0;
            for (int i = 0; i < daniPosebno.Count; i++)
            {
                boja.Color = Color.Black;
                if (daniPosebno[i] != 0)
                {
                    boja.Color = Color.FromArgb(255 % brojac, 255, 255 % (i + 1));
                    switch (i % 4)
                    {
                        case 0:
                            boja.Color = Color.FromArgb(255, brojac, brojac * mnozi);
                            break;
                        case 1:
                            boja.Color = Color.FromArgb(brojac * mnozi, 255, brojac);
                            break;
                        case 2:
                            boja.Color = Color.FromArgb(brojac, brojac * mnozi, brojac);
                            break;
                        case 3:
                            boja.Color = Color.FromArgb(brojac * mnozi, 255, 255);
                            break;
                    }
                    mnozi++;
                }
                Rectangle okvir = new Rectangle(p.Width - 50,10+ 25 * i, 20, 8);
                g.FillRectangle(boja, okvir);
            }
        }
        public static void crtajStatistikaGodine(Graphics g,int visina,int prethodnaVisina,int mesec, Panel p,bool kriva)
        {
            int maxSirina = p.Width - 50;
            Pen olovka = new Pen(Color.Blue, 3);
            Point xOsa1 = new Point(5, p.Height - 60);
            Point xOsa2 = new Point(p.Width - 2, p.Height - 60);
            g.DrawLine(olovka, xOsa1, xOsa2);
            Point yOsa1 = new Point(15, p.Height - 55);
            Point yOsa2 = new Point(15, 5);
            g.DrawLine(olovka, yOsa1, yOsa2);
            SolidBrush boja = new SolidBrush(Color.Red);
            visina += 2;
            prethodnaVisina += 2;
            Rectangle okvir = new Rectangle(10 + (maxSirina / 22)*(2*mesec-1), xOsa1.Y-4*visina, (maxSirina / 24) , (int)(4*visina));
            g.FillRectangle(boja, okvir);
            g.DrawString((visina - 2) + "", new Font("Arial", 10), Brushes.Black ,10+ (maxSirina /22) * (2 * mesec - 1), xOsa1.Y - 4 * visina-15);
            g.DrawString((vratiMesec(mesec)), new Font("Arial", 7), Brushes.Black,(maxSirina / 22) * (2 * mesec - 1), xOsa1.Y+10);
            if (kriva)
            {
                Point proslaTacka;
                Point sadasnjaTacka;
                if(mesec == 1)
                {
                    proslaTacka = new Point(xOsa1.X + 5, xOsa1.Y);
                }
                else
                {
                    proslaTacka = new Point(17 + (maxSirina / 22) * (2 * (mesec - 1) - 1), xOsa1.Y - 4 * prethodnaVisina+5);
                }
                sadasnjaTacka = new Point(17+(maxSirina / 22) * (2 * mesec - 1), xOsa1.Y - 4 * visina+5);
                olovka = new Pen(Color.Black, 3);
                float[] dashValues = { 1, 1};
                olovka.DashPattern = dashValues;
                g.DrawLine(olovka, proslaTacka, sadasnjaTacka);
            }
        }
        private static string vratiMesec(int broj)
        {
            switch (broj)
            {
                case 1: return "Januar";
                case 2: return "Februa";
                case 3: return "Mart";
                case 4: return "April";
                case 5: return "Maj";
                case 6: return "Jun"; 
                case 7: return "Jul"; 
                case 8: return "Avgust"; 
                case 9: return "Septembar"; 
                case 10: return "Oktobar";
                case 11: return "Novembar";
                case 12: return "Decembar";
                default: return "";
            }
        }
    }
}
