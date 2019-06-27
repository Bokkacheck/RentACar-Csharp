using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatProba
{
    public class Administrator : Korisnik
    {
        public Administrator() { }
        public Administrator(int idbr, string ime, string prezime, DateTime datumRodjenja, string jmbg, string brojTelefon, string lozinkaa) : base(idbr, ime, prezime, datumRodjenja, jmbg, brojTelefon, lozinkaa) { }
        public override string ToString()
        {
            return base.ToString() + "Administrator";
        }   
        public bool obrisiKorisnika(List<Korisnik> korisnici,string korisnikIDBR) {
            for(int i = 0; i < korisnici.Count; i++)
            {
                if (korisnici[i].Idbr.ToString() == korisnikIDBR)
                {
                    korisnici.RemoveAt(i);
                    RadSlika.obrisiSliku("korisnik", korisnikIDBR);
                    return true;
                }
            }
            return false;
        }
        public bool dodajKorisnika(List<Korisnik> korisnici, int idbr, string ime, string prezime, DateTime datumRodjenja, string jmbg, string brojTelefon, string lozinkaa, int tip)
        {
            if (proveraKorisnika(korisnici, idbr, jmbg, brojTelefon))
            {
                if (tip == 0)
                {
                    korisnici.Add(new Administrator(idbr, ime, prezime, datumRodjenja, jmbg, brojTelefon, lozinkaa));
                }
                else
                {
                    korisnici.Add(new Kupac(idbr, ime, prezime, datumRodjenja, jmbg, brojTelefon, lozinkaa));
                }
                return true;
            }
            else
            {
                return false;
            } 
        }
        public bool izmenaKupca(List<Korisnik> korisnici,int originalIDBR, int idbr, string ime, string prezime, DateTime datumRodjenja, string jmbg, string brojTelefon, string lozinkaa)
        {
            int pozicijaKorisnikaUListi = 0;
            Korisnik korisnik = null;
            for (int i = 0; i < korisnici.Count; i++)
            {
                if (originalIDBR == korisnici[i].Idbr)
                {
                    pozicijaKorisnikaUListi = i;
                    korisnik = korisnici[i];
                    korisnici[i] = new Korisnik();
                }
            }
            if (proveraKorisnika(korisnici, idbr, jmbg, brojTelefon))
            {
                korisnici[pozicijaKorisnikaUListi] = new Kupac(idbr, ime, prezime, datumRodjenja, jmbg, brojTelefon, lozinkaa);
                RadSlika.promenaIDBRaSlika("korisnik", originalIDBR+"", idbr+"");
                return true;
            }
            else
            {
                korisnici[pozicijaKorisnikaUListi] = korisnik;
                return false;
            }
        }
    }
}
