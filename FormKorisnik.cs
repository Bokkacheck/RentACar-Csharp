using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatProba
{
    public partial class KorisnickaForma : Form
    {
        private List<Rezervacija> rezervacije;
        private Kupac ulogovanKupac;
        public KorisnickaForma()
        {
            InitializeComponent();
        }
        public KorisnickaForma(Korisnik k) : this()
        {
            this.FormClosed += Login.ugasiProgram;
            ulogovanKupac = (Kupac)k;
            rezervacije = RadDatoteka.citanjeDatoteke<Rezervacija>("rezervacije.json");
            osveziRezervacije();
            popuniProfil();
        }
        private void osveziRezervacije()
        {
            listBox1.Items.Clear();
            foreach(Rezervacija r in rezervacije)
            {
                if (r.IdbrKupca == ulogovanKupac.Idbr)
                {
                    listBox1.Items.Add(r.ToString());
                }
            }
        }
        private void popuniProfil()
        {
            lblIme.Text = ulogovanKupac.Ime;
            lblPrezime.Text = ulogovanKupac.Prezime;
            lblIDBR.Text = ulogovanKupac.Idbr.ToString();
            lblJMBG.Text = ulogovanKupac.Jmbg.ToString();
            lblTelefon.Text = ulogovanKupac.BrojTelefon;
            lblDatumRodjenja.Text = ulogovanKupac.DatumRodjenja.ToString("dd/MM/yyyy");
            RadSlika.prikaziSliku(pbProfil, "korisnik", ulogovanKupac.Idbr + "");
        }
        private void btnIzloguj_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
        }
        private void btnNovaRezervacija_Click(object sender, EventArgs e)
        {
            new FormRezervacije(ulogovanKupac.Idbr).Show();
            this.Close();
        }
        private void btnObrisiRezervaciju_Click(object sender, EventArgs e)
        {
            Rezervacija.obrisiTrazenuRezervaciju(rezervacije, ulogovanKupac.Idbr, listBox1.SelectedIndex);
            RadDatoteka.upisDatoteka(rezervacije, "rezervacije.json");
            osveziRezervacije();
        }
    }
}
