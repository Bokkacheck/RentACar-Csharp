using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatProba
{
    static class Logovanje
    {
        public static bool ulogujSe(string korisnickoIme, string lozinka)
        {
            List<Korisnik> niz;
            niz = RadDatoteka.citanjeDatoteke<Korisnik>("korisnici.json");
            foreach(Korisnik korisnik in niz)
            {
                try
                {
                    if (korisnik.Idbr == int.Parse(korisnickoIme) && korisnik.Lozinka == lozinka)
                    {
                        if (korisnik is Kupac)
                        {
                            Kupac kupac = korisnik as Kupac;
                            KorisnickaForma forma = new KorisnickaForma(korisnik);
                            forma.Show();

                        }
                        else if (korisnik is Administrator)
                        {
                            Administrator admin = korisnik as Administrator;
                            FormaAdministracija forma = new FormaAdministracija(korisnik);
                            forma.Show();
                        }
                        return true;
                    }
                }
                catch { }
            }
            MessageBox.Show("Nije pronadjen korisnik s tim IDBRom i sifrom");
            return false;
        }
    }
}
