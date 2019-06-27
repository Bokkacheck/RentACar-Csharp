using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatProba
{
    public class Korisnik
    {
        private string jmbg;
        private int idbr;
        private DateTime datumRodjenja;
        private string brojTelefon;
        private string ime;
        private string prezime;
        private string lozinka;
        public Korisnik()
        {
            idbr = 0;
        }
        public Korisnik(int idbr , string ime,string prezime,DateTime datumRodjenja, string jmbg,string brojTelefon, string lozinkaa)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.lozinka = lozinkaa;
            this.idbr = idbr;
            this.datumRodjenja = datumRodjenja;
            this.jmbg = jmbg;
            this.brojTelefon = brojTelefon;
        }
        public static bool proveraKorisnika(List<Korisnik> korisnici,int idbr, string jmbg, string brojTelefon)
        {
            string odgovor="";
            bool provera = false;
            foreach(Korisnik korisnik in korisnici)
            {
                if (idbr == korisnik.idbr)
                {
                    odgovor += "1. Postoji korisnik sa ovim IDBRom" + Environment.NewLine;
                    provera = true;
                }
                if (jmbg == korisnik.jmbg)
                {
                    odgovor += "2. Postoji korisnik sa ovakvim JMBGom " + Environment.NewLine;
                    provera = true;
                }
                if (brojTelefon == korisnik.brojTelefon)
                {
                    odgovor += "3. Postoji korisnik sa ovakvim brojem telefona ";
                    provera = true;
                }
                if (provera)
                {
                    MessageBox.Show("Nemoguc unos" + Environment.NewLine + odgovor);
                    return false;
                }
            }
            return true;
        }
        public override string ToString()
        {
            return "IDBR: " + Idbr + " Ime: " + Ime + " Prezime: " + Prezime + " Tip: ";
        }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public int Idbr { get => idbr; set => idbr = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string BrojTelefon { get => brojTelefon; set => brojTelefon = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
    }
}
