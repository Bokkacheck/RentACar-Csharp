using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatProba
{
    public class Kupac : Korisnik
    {
        public Kupac() { }
        public Kupac(int idbr, string ime, string prezime, DateTime datumRodjenja, string jmbg,string brojTelefon, string lozinkaa) : base(idbr,ime,prezime,datumRodjenja,jmbg,brojTelefon,lozinkaa)
        {
            
        }
        public override string ToString()
        {
            return base.ToString() + "Kupac";
        }
    }
}
