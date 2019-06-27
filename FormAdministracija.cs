using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

namespace ProjekatProba
{
    public delegate void Osvezi();
    public partial class FormaAdministracija : Form
    {
        private string korisnikIDBR;
        private string automobilIDBR;
        private string automobilIDBRIzmene;
        private string ponudaIDBRauta;
        private string korisnikIDBRrez;
        private string automobilGodineStatistikaIdbr;
        private List<Korisnik> korisnici;
        private List<Automobil> automobili;
        private List<Ponuda> ponude;
        private List<Rezervacija> rezervacije;
        private Administrator ulogovanAdmin;
        private Ponuda trenutnaPonuda;
        public Osvezi osvezi;
        public FormaAdministracija()
        {
            InitializeComponent();
        }
        //POCETAK
        public FormaAdministracija(Korisnik korisnik) : this()
        {
            ulogovanAdmin = (Administrator)korisnik;
            this.FormClosed += Login.ugasiProgram;
            this.FormClosed += upisNaKraju;
            this.Load += ucitajPodatke;
            popuniProfil();
            korisnici = RadDatoteka.citanjeDatoteke<Korisnik>("korisnici.json");
            automobili = RadDatoteka.citanjeDatoteke<Automobil>("automobili.json");
            ponude = RadDatoteka.citanjeDatoteke<Ponuda>("ponude.json");
            rezervacije = RadDatoteka.citanjeDatoteke<Rezervacija>("rezervacije.json");
            Ponuda.azurirajDatum(ponude);
            Ponuda.sortirajPonudu(ponude); 
            timer1.Enabled = true;
            timer1.Interval = 1000 * 60; //minut
            txtLozinka.UseSystemPasswordChar = true;
            osvezi = osveziKorisnik;
            osvezi += osveziAutomobil;
            osvezi += osveziAutomobilIzmene;
            osvezi += osveziPonuda;
            osvezi += osveziRezervacije;
            osvezi += osveziStatistika;
        }
        private void btnIzloguj_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
        }
        private void popuniProfil()
        {
            lblIme.Text = ulogovanAdmin.Ime;
            lblPrezime.Text = ulogovanAdmin.Prezime;
            lblIDBR.Text = ulogovanAdmin.Idbr.ToString();
            lblJMBG.Text = ulogovanAdmin.Jmbg.ToString();
            lblTelefon.Text = ulogovanAdmin.BrojTelefon;
            lblDatumRodjenja.Text = ulogovanAdmin.DatumRodjenja.ToString("dd/MM/yyyy");
            RadSlika.prikaziSliku(pbProfil, "korisnik", ulogovanAdmin.Idbr + "");
            korisnikIDBR = "";
        }
        private void ucitajPodatke(object sender, EventArgs e)
        {
            osvezi();
        }
        //OSVEZI
        private void osveziKorisnik()
        {
            txtImeKorisnik.Text = "";
            txtPrezimeKupac.Text = "";
            txtTelefonKupac.Text = "";
            txtJMBGKupac.Text = "";
            txtIDBRKupac.Text = "";
            txtTelefonKupac.Text = "";
            txtDatumKupac.Text = "";
            txtLozinka.Text = "";
            cbKorisnici.Items.Clear();
            cbKorisnici.Text = "Odaberi kupca";
            cbKorisnici.Items.Add("Dodaj novog korisnika");
            pbKorisnik.Image = null;
            foreach (Korisnik korisnik in korisnici)
            {
                if(ulogovanAdmin is GlavniAdmin)
                {
                    if (!(korisnik is GlavniAdmin))
                        cbKorisnici.Items.Add(korisnik.ToString());
                }
                else
                {
                    if (korisnik is Kupac)
                    {
                        Kupac kupac = korisnik as Kupac;
                        cbKorisnici.Items.Add(kupac.ToString());
                    }
                }
            }
            korisnikIDBR = "";
        }
        private void osveziAutomobil()
        {
            lblAutomobilGodiste.Text = "";
            lblAutomobilGorivo.Text = "";
            lblAutomobilIDBR.Text = "";
            lblAutomobilKubikaza.Text = "";
            lblAutomobilMarka.Text = "";
            lblAutomobilMenjac.Text = "";
            lblAutomobilModel.Text = "";
            lblAutomobilPogon.Text = "";
            lblBrojVrata.Text = "";
            lblKaroserija.Text = "";
            cbAutomobili.Items.Clear();
            cbAutomobili.Text = "Odaberi automobil";
            pbAuto.Image = null;
            foreach (Automobil automobil in automobili)
            {
                cbAutomobili.Items.Add("IDBR: " + automobil.IdbrAuta + " Marka: " + automobil.Marka + " Model: " +automobil.Model+ " Godiste: " + automobil.Godiste);
            }
            automobilIDBR = "";
        }
        private void osveziAutomobilIzmene()
        {
            txtGodiste.Text = "";
            cbGorivo.SelectedIndex = -1;
            txtAutoIDBR.Text = "";
            txtKubikaza.Text =  "";
            txtMarka.Text = "";
            cbMenjac.SelectedIndex = -1;
            txtModel.Text = "";
            cbPogon.SelectedIndex = -1;
            cbBrojVrata.SelectedIndex = -1;
            cbKaroserija.SelectedIndex = -1;
            cbAutomobiliIzmene.Items.Clear();
            cbAutomobiliIzmene.Items.Add("Dodaj novi automobil");
            pbAutoIzmene.Image = null;
            foreach (Automobil automobil in automobili)
            {
                cbAutomobiliIzmene.Items.Add("IDBR: " + automobil.IdbrAuta + " Marka: " + automobil.Marka + " Model: " + automobil.Model + " Godiste: " + automobil.Godiste);
            }
            automobilIDBRIzmene = "";
        }
        private void osveziRezervacije()
        {
            lbRezervacije.Items.Clear();
            cbRezervacije.Items.Clear();
            foreach (Korisnik korisnik in korisnici)
            {
                if (korisnik is Kupac)
                {
                    Kupac kupac = korisnik as Kupac;
                    cbRezervacije.Items.Add(kupac.ToString());
                }
            }
            korisnikIDBRrez = "";
        }
        private void osveziPonuda()
        {
            dpDatumOdPonuda.MinDate = DateTime.Now.Date;
            dpDatumDoPonuda.MinDate = DateTime.Now.Date;
            cbPonuda.Items.Clear();
            cbPonuda.Items.Add("Dodaj novu ponudu");
            dpDatumOdPonuda.Value = DateTime.Now;
            dpDatumDoPonuda.Value = DateTime.Now;
            txtPonudaIdbrAuta.Clear();
            txtCena.Clear();
            trenutnaPonuda = null;
        }
        private void osveziStatistika()
        {
            automobilGodineStatistikaIdbr = "";
            cbAutoGodine.Items.Clear();
            foreach(Automobil automobil in automobili)
            {
                cbAutoGodine.Items.Add("IDBR: " + automobil.IdbrAuta + " Marka: " + automobil.Marka + " Model: " + automobil.Model + " Godiste: " + automobil.Godiste);
            }
        }
        //KORISNICI
        private void cbKorisnici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                korisnikIDBR = cbKorisnici.SelectedItem.ToString().Substring(6, 4);
            }
            else if (sender is Button)
            {
                Match provera = Regex.Match(txtPretragaKorisnik.Text, @"^[1-9]{1}[0-9]{3}$");
                if (provera.Success)
                {
                    korisnikIDBR = txtPretragaKorisnik.Text;
                }
                else
                {
                    MessageBox.Show("IDBR mora biti u opsegu 1000-9999");
                    return;
                }
            }
            bool pomoc = true;
            if (cbKorisnici.SelectedIndex == 0)
            {
                btnPretragaKorisnik.Visible = false;
                txtPretragaKorisnik.Visible = false;
                btnDodajKorisnik.Visible = true;
                lblTipKorisnik.Visible = true;
                cbTip.Visible = true;
                btnIzmenaKorisnik.Visible = false;
                btnObrisiKorisnik.Visible = false;
                osvezi();
                korisnikIDBR = "1";
                RadSlika.obrisiSliku("korisnik", "1");
                pomoc = false;
            }
            else
            {
                btnPretragaKorisnik.Visible = true;
                txtPretragaKorisnik.Visible = true;
                btnDodajKorisnik.Visible = false;
                lblTipKorisnik.Visible = false;
                cbTip.Visible = false;
                btnIzmenaKorisnik.Visible = true;
                btnObrisiKorisnik.Visible = true;
                if (ulogovanAdmin is GlavniAdmin)
                {
                    foreach (Korisnik korisnik in korisnici)
                    {
                        if (korisnik.Idbr.ToString() == korisnikIDBR && !(korisnik is GlavniAdmin))
                        {
                            txtImeKorisnik.Text = korisnik.Ime;
                            txtPrezimeKupac.Text = korisnik.Prezime;
                            txtTelefonKupac.Text = korisnik.BrojTelefon;
                            txtJMBGKupac.Text = korisnik.Jmbg.ToString();
                            txtIDBRKupac.Text = korisnik.Idbr.ToString();
                            txtTelefonKupac.Text = korisnik.BrojTelefon;
                            txtDatumKupac.Text = korisnik.DatumRodjenja.ToString("dd/MM/yyyy");
                            txtLozinka.Text = korisnik.Lozinka;
                            cbKorisnici.Text = korisnik.ToString();
                            RadSlika.prikaziSliku(pbKorisnik, "korisnik", korisnik.Idbr + "");
                            pomoc = false;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Korisnik korisnik in korisnici)
                    {
                        if (korisnik is Kupac && korisnik.Idbr.ToString() == korisnikIDBR)
                        {
                            txtImeKorisnik.Text = korisnik.Ime;
                            txtPrezimeKupac.Text = korisnik.Prezime;
                            txtTelefonKupac.Text = korisnik.BrojTelefon;
                            txtJMBGKupac.Text = korisnik.Jmbg.ToString();
                            txtIDBRKupac.Text = korisnik.Idbr.ToString();
                            txtTelefonKupac.Text = korisnik.BrojTelefon;
                            txtDatumKupac.Text = korisnik.DatumRodjenja.ToString("dd/MM/yyyy");
                            txtLozinka.Text = korisnik.Lozinka;
                            cbKorisnici.Text = korisnik.ToString();
                            RadSlika.prikaziSliku(pbKorisnik, "korisnik", korisnik.Idbr + "");
                            pomoc = false;
                            break;
                        }
                    }
                }                
            }
            if (pomoc)  //ako nije nadjen korsinik sa unetim IDRB om u pretrazi da ostane prethodni
            {
                if (cbKorisnici.SelectedIndex != -1)
                    korisnikIDBR = cbKorisnici.SelectedItem.ToString().Substring(6, 4);
                MessageBox.Show("Nije pronadjen korisnik sa tim IDBR om");
            }
            txtPretragaKorisnik.Clear();
        }
        private void chkLozinka_CheckedChanged(object sender, EventArgs e)
        {
            if(chkLozinka.Checked == true)
            {
                txtLozinka.UseSystemPasswordChar = false;
            }
            else
            {
                txtLozinka.UseSystemPasswordChar = true;
            }
        }
        private void btnObrisiKorisnik_Click(object sender, EventArgs e)
        {
            if (korisnikIDBR != "")
            {
                ulogovanAdmin.obrisiKorisnika(korisnici, korisnikIDBR);
                Rezervacija.obrisiRezervaciju(rezervacije, int.Parse(korisnikIDBR));
                osvezi();
            }
            else
            {
                MessageBox.Show("Odaberite korisnika");
            }
        }
        private void btnDodajKorisnik_Click(object sender, EventArgs e)
        {
            int tip = cbTip.SelectedIndex;
            if(Validacije.proveriPodatkeKorisnik(txtIDBRKupac, txtImeKorisnik, txtPrezimeKupac,txtDatumKupac, txtJMBGKupac, txtTelefonKupac, txtLozinka, tip))
            {
                if(ulogovanAdmin.dodajKorisnika(korisnici, int.Parse(txtIDBRKupac.Text), txtImeKorisnik.Text, txtPrezimeKupac.Text, DateTime.ParseExact(txtDatumKupac.Text,"dd/MM/yyyy",CultureInfo.CurrentCulture), txtJMBGKupac.Text, txtTelefonKupac.Text, txtLozinka.Text, tip))
                {
                    if (File.Exists("slike/korisnik1.jpg"))
                    {
                        RadSlika.promenaIDBRaSlika("korisnik", "1", txtIDBRKupac.Text);
                    }
                    MessageBox.Show("Korisnik uspesno dodat");
                    osvezi();
                }
            }
            else
            {
                MessageBox.Show("Korisnik nije dodatk");
            }
        }
        private void btnIzmenaKorisnik_Click(object sender, EventArgs e)
        {
            if (korisnikIDBR == "")
            {
                MessageBox.Show("Odaberite korisnika");
            }
            else
            {
                if (Validacije.proveriPodatkeKorisnik(txtIDBRKupac, txtImeKorisnik, txtPrezimeKupac, txtDatumKupac, txtJMBGKupac, txtTelefonKupac, txtLozinka, 0))
                {
                   if(ulogovanAdmin.izmenaKupca(korisnici, int.Parse(korisnikIDBR), int.Parse(txtIDBRKupac.Text), txtImeKorisnik.Text, txtPrezimeKupac.Text, DateTime.ParseExact(txtDatumKupac.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture), txtJMBGKupac.Text, txtTelefonKupac.Text, txtLozinka.Text))
                   {
                        Rezervacija.izmenaIdbrKorisnik(rezervacije,int.Parse(korisnikIDBR), int.Parse(txtIDBRKupac.Text));
                        MessageBox.Show("Uspesno izmenjeni podaci");
                        osvezi();
                   }

                }
                else
                {
                    MessageBox.Show("Podaci nisu izmenjeni");
                }
            }
        }
        //AUTOMOBILI
        private void cbAutomobili_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                automobilIDBR = cbAutomobili.SelectedItem.ToString().Substring(6, 3);
            }
            else if (sender is Button)
            {
                Match provera = Regex.Match(txtPretragaAutomobil.Text, @"^[1-9]{1}[0-9]{2}$");
                if (provera.Success)
                {
                    automobilIDBR = txtPretragaAutomobil.Text;
                }
                else
                {
                    MessageBox.Show("IDBR mora biti u opsegu 100-999");
                    return;
                }
            }
            bool pomoc = true;
            foreach (Automobil automobil in automobili)
            {
                if ((automobil.IdbrAuta + "") == automobilIDBR)
                {
                    lblAutomobilGodiste.Text = automobil.Godiste + "";
                    lblAutomobilGorivo.Text = automobil.Gorivo;
                    lblAutomobilIDBR.Text = automobil.IdbrAuta + "";
                    lblAutomobilKubikaza.Text = automobil.Kubikaza + "";
                    lblAutomobilMarka.Text = automobil.Marka;
                    lblAutomobilMenjac.Text = automobil.VrstaMenjaca;
                    lblAutomobilModel.Text = automobil.Model;
                    lblAutomobilPogon.Text = automobil.Pogon;
                    lblBrojVrata.Text = automobil.BrojVrata;
                    lblKaroserija.Text = automobil.Karoserija;
                    RadSlika.prikaziSliku(pbAuto, "automobil", automobil.IdbrAuta + "");
                    pomoc = false;
                    break;
                }
            }
            if (pomoc)
            {
                if (cbAutomobili.SelectedIndex != -1)
                    automobilIDBR = cbAutomobili.SelectedItem.ToString().Substring(6, 3);
                MessageBox.Show("Nije pronadjen automobil sa tim IDBR om");
            }
        }
        private void cbAutomobiliIzmene_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                automobilIDBRIzmene = cbAutomobiliIzmene.SelectedItem.ToString().Substring(6, 3);
            }
            else if (sender is Button)
            {
                Match provera = Regex.Match(txtPretragaAutomobilaIzmene.Text, @"^[1-9]{1}[0-9]{2}$");
                if (provera.Success)
                {
                    automobilIDBRIzmene = txtPretragaAutomobilaIzmene.Text;
                }
                else
                {
                    MessageBox.Show("IDBR mora biti u opsegu 100-999");
                    return;
                }
            }
            bool pomoc = true;
            if(cbAutomobiliIzmene.SelectedIndex == 0)
            {
                btnDodajAutomobil.Visible = true;
                btnIzmeniAutomobil.Visible = false;
                btnPretragaIzmene.Visible = false;
                txtPretragaAutomobilaIzmene.Visible = false;
                osvezi();
                automobilIDBRIzmene = "1";
                RadSlika.obrisiSliku("automobil", "1");
                return;
            }
            else
            {
                btnDodajAutomobil.Visible = false;
                btnIzmeniAutomobil.Visible = true;
                btnPretragaIzmene.Visible = true;
                txtPretragaAutomobilaIzmene.Visible = true;
                foreach (Automobil automobil in automobili)
                {
                    if ((automobil.IdbrAuta + "") == automobilIDBRIzmene)
                    {
                        txtGodiste.Text = automobil.Godiste + "";
                        cbGorivo.Text = automobil.Gorivo;
                        txtAutoIDBR.Text = automobil.IdbrAuta + "";
                        txtKubikaza.Text = automobil.Kubikaza + "";
                        txtMarka.Text = automobil.Marka;
                        cbMenjac.Text = automobil.VrstaMenjaca;
                        txtModel.Text = automobil.Model;
                        cbPogon.Text = automobil.Pogon;
                        cbBrojVrata.Text = automobil.BrojVrata;
                        cbKaroserija.Text = automobil.Karoserija;
                        RadSlika.prikaziSliku(pbAutoIzmene, "automobil", automobil.IdbrAuta + "");
                        pomoc = false;
                        break;
                    }
                }
            }
            if (pomoc)
            {
                if (cbAutomobiliIzmene.SelectedIndex != -1)
                    automobilIDBRIzmene = cbAutomobiliIzmene.SelectedItem.ToString().Substring(6, 3);
                MessageBox.Show("Nije pronadjen automobil sa tim IDBR om");

            }
        }
        private void btnObrisiAutomobil_Click(object sender, EventArgs e)
        {
            Automobil.obrisiAutomobil(automobili, automobilIDBR);
            Ponuda.obrisiPonuda(ponude, automobilIDBR);
            osvezi();
        }
        private void btnIzmeniAutomobil_Click(object sender, EventArgs e)
        {
            if (automobilIDBRIzmene != "")
            {
                if (cbPogon.Text == "" || cbMenjac.Text == "" || cbKaroserija.Text == "" || cbGorivo.Text == "" || cbBrojVrata.Text == "")
                {
                    MessageBox.Show("Morate uneti sva polja");
                    return;
                }
                else if (Validacije.proveriPodatkeAutomobil(txtAutoIDBR, txtModel, txtMarka, txtGodiste, txtKubikaza))
                {
                    if (Automobil.izmeniAutomobil(automobili, automobilIDBRIzmene, int.Parse(txtAutoIDBR.Text), txtMarka.Text, txtModel.Text, int.Parse(txtGodiste.Text), int.Parse(txtKubikaza.Text), cbPogon.Text, cbMenjac.Text, cbKaroserija.Text, cbGorivo.Text, cbBrojVrata.Text))
                    {
                        Ponuda.izmenaIdbr(ponude, automobilIDBRIzmene, txtAutoIDBR.Text);
                        Rezervacija.izmenaIdbrAuto(rezervacije, int.Parse(automobilIDBRIzmene), int.Parse(txtAutoIDBR.Text));
                        osvezi();
                    }
                }
            }
            else
            {
                MessageBox.Show("Odaberite korisnika");
            }
        }
        private void btnDodajAutomobil_Click(object sender, EventArgs e)
        {
            if (cbPogon.Text == "" || cbMenjac.Text == "" || cbKaroserija.Text == "" || cbGorivo.Text == "" || cbBrojVrata.Text == "")
            {
                MessageBox.Show("Morate uneti sva polja");
                return;
            }
            else if (Validacije.proveriPodatkeAutomobil(txtAutoIDBR, txtModel, txtMarka, txtGodiste, txtKubikaza))
            {
                if(Automobil.dodajAutomobil(automobili, int.Parse(txtAutoIDBR.Text), txtMarka.Text, txtModel.Text, int.Parse(txtGodiste.Text), int.Parse(txtKubikaza.Text), cbPogon.Text, cbMenjac.Text, cbKaroserija.Text, cbGorivo.Text, cbBrojVrata.Text))
                {
                    if (File.Exists("slike/automobil1.jpg"))
                    {
                        RadSlika.promenaIDBRaSlika("automobil", "1", txtAutoIDBR.Text);
                    }
                    osvezi();
                }
            }
            File.Delete("slike/automobil1.jpg");
        }
        //SLIKA
        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            Button provera = sender as Button;
            if (provera == btnDodajSlikuKorisnik)
            {
                RadSlika.dodajSLiku("korisnik", korisnikIDBR);
                RadSlika.prikaziSliku(pbKorisnik, "korisnik", korisnikIDBR);
            }
            else if (provera == btnDodajSlikuAuto)
            {
                RadSlika.dodajSLiku("automobil", automobilIDBRIzmene);
                RadSlika.prikaziSliku(pbAutoIzmene, "automobil", automobilIDBRIzmene);
            }
        }
        private void btnObrisiSliku_Click(object sender, EventArgs e)
        {
            Button provera = sender as Button;
            if (provera == btnDodajSlikuKorisnik)
            {
                RadSlika.obrisiSliku("korisnik", korisnikIDBR);
                RadSlika.prikaziSliku(pbKorisnik, "korisnik", korisnikIDBR);
            }
            else if (provera == btnObrisiSlikuAuto )
            {
                RadSlika.obrisiSliku("automobil", automobilIDBRIzmene);
                RadSlika.prikaziSliku(pbAutoIzmene, "automobil", automobilIDBRIzmene);
            }
        }
        //PONUDE
        private void btnPonudaPretraga_Click(object sender, EventArgs e)
        {
            cbPonuda.Items.Clear();
            cbPonuda.Items.Add("Dodaj novu ponudu");
            ponudaIDBRauta = txtPonudaPretraga.Text;
            foreach (Ponuda ponuda in ponude)
            {
                if (ponuda.IdbrAuta + "" == ponudaIDBRauta)
                {
                    cbPonuda.Items.Add(ponuda.ToString());
                }
            }
            txtPonudaPretraga.Clear();
        }
        private void cbPonuda_SelectedIndexChanged(object sender, EventArgs e)
        {
            int brojac = 0;
            if (cbPonuda.SelectedIndex == 0)
            {
                btnDodajPonuda.Visible = true;
                btnIzmeniPonuda.Visible = false;
                btnIzbrisiPonuda.Visible = false;
                osvezi();
            }
            else
            {
                btnDodajPonuda.Visible = false;
                btnIzmeniPonuda.Visible = true;
                btnIzbrisiPonuda.Visible = true;
                foreach (Ponuda ponuda in ponude)
                {
                    if (ponuda.IdbrAuta + "" == ponudaIDBRauta)
                    {
                        if (cbPonuda.SelectedIndex == ++brojac)
                        {
                            txtPonudaIdbrAuta.Text = ponuda.IdbrAuta + "";
                            dpDatumOdPonuda.Value = ponuda.DatumOd.Date;
                            dpDatumDoPonuda.Value = ponuda.DatumDo.Date;
                            txtCena.Text = ponuda.CenaDan + "";
                            trenutnaPonuda = ponuda;
                        }
                    }
                }
            }

        }
        private void dpDatumOdPonuda_ValueChanged(object sender, EventArgs e)
        {
            dpDatumDoPonuda.MinDate = dpDatumOdPonuda.Value.Date;
        }
        private void btnIzbrisiPonuda_Click(object sender, EventArgs e)
        {
            if (!(trenutnaPonuda is null))
            {
                if (Ponuda.obrisiPonuda(ponude, trenutnaPonuda))
                {
                    MessageBox.Show("Uspesno obrisana ponuda");
                    osvezi();
                }
                else
                {
                    MessageBox.Show("Ponuda nije obrisana");
                }
            }
            else
            {
                MessageBox.Show("Odaberite ponudu prvo");
            }

        }
        private void btnDodajPonuda_Click(object sender, EventArgs e)
        {
            if (Validacije.proveriPodatkePonuda(txtPonudaIdbrAuta, txtCena))
            {
                if (!Automobil.proveraAutomobila(automobili, int.Parse(txtPonudaIdbrAuta.Text)))
                {
                    trenutnaPonuda = new Ponuda(int.Parse(txtPonudaIdbrAuta.Text), dpDatumOdPonuda.Value.Date, dpDatumDoPonuda.Value.Date, int.Parse(txtCena.Text));
                    if (Ponuda.dodajPonuda(ponude, trenutnaPonuda))
                    {
                        MessageBox.Show("Ponuda uspesno dodata");
                    }
                    else
                    {
                        MessageBox.Show("Vec postoji ovakva ponuda, ponuda nije dodata");
                    }
                }
                else
                {
                    MessageBox.Show("Ne postoji automobil sa tim IDBRom");
                    txtPonudaIdbrAuta.Clear();
                }
            }
        }
        private void btnIzmeniPonuda_Click(object sender, EventArgs e)
        {
            if (!(trenutnaPonuda is null))
            {
                if (Validacije.proveriPodatkePonuda(txtPonudaIdbrAuta, txtCena))
                {
                    if (!Automobil.proveraAutomobila(automobili, int.Parse(txtPonudaIdbrAuta.Text)))
                    {
                        Ponuda novaPonuda = new Ponuda(int.Parse(txtPonudaIdbrAuta.Text), dpDatumOdPonuda.Value.Date, dpDatumDoPonuda.Value.Date, int.Parse(txtCena.Text));
                        Ponuda.obrisiPonuda(ponude, trenutnaPonuda);    //obrisi staru(trenutnu) i zameni novom
                        if (Ponuda.dodajPonuda(ponude, novaPonuda))
                        {
                            MessageBox.Show("Ponuda uspesno izmenjena");
                            osvezi();
                        }
                        else
                        {
                            Ponuda.dodajPonuda(ponude, trenutnaPonuda); //vrati staru ako uneto nije dobro
                            osvezi();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ne postoji automobil sa tim IDBRom");
                        txtPonudaIdbrAuta.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Odaberite ponudu prvo");
            }
        }
        //REZERVACIJE
        private void cbRezervacije_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbRezervacije.Items.Clear();
            if (sender is ComboBox)
            {
                korisnikIDBRrez = cbRezervacije.SelectedItem.ToString().Substring(6, 4);
            }
            else if (sender is Button)
            {
                Match provera = Regex.Match(txtRezervacijeKorisnik.Text, @"^[1-9]{1}[0-9]{3}$");
                if (provera.Success)
                {
                    korisnikIDBRrez = txtRezervacijeKorisnik.Text;
                }
                else
                {
                    MessageBox.Show("IDBR mora biti u opsegu 1000-9999");
                    return;
                }
            }
            bool pomoc = false;
            foreach(Korisnik k in korisnici)
            {
                if (k.Idbr + "" == korisnikIDBRrez)
                {
                    pomoc = true;
                    break;
                }
            }
            if (!pomoc)
            {
                if (cbRezervacije.SelectedIndex != -1)
                    korisnikIDBRrez = cbRezervacije.SelectedItem.ToString().Substring(6, 4);
                MessageBox.Show("Nije pronadjen korisnik sa tim IDBR om");
            }
            foreach (Rezervacija r in rezervacije)
            {
                if ((r.IdbrKupca + "") == korisnikIDBRrez)
                {
                    lbRezervacije.Items.Add(r.ToString());
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int broj;
            if (int.TryParse(korisnikIDBRrez, out broj) && lbRezervacije.SelectedIndex != -1)
            {
                Rezervacija.obrisiTrazenuRezervaciju(rezervacije, broj, lbRezervacije.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Korisnik ili rezervacija nisu odabrani");
            }
            osvezi();
        }
        //KRAJ-UPIS-AZURIRANJE
        private void upis()
        {
            RadDatoteka.upisDatoteka(korisnici, "korisnici.json");
            RadDatoteka.upisDatoteka(automobili, "automobili.json");
            RadDatoteka.upisDatoteka(ponude, "ponude.json");
            RadDatoteka.upisDatoteka(rezervacije, "rezervacije.json");
        }
        private void upisNaKraju(object sender, FormClosedEventArgs e)
        {
            upis();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            upis();
        }
        private void btnAzuriranje_Click(object sender, EventArgs e)
        {
            upis();
        }
        private void chkAzuriranje_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAzuriranje.Checked == true)
            {
                timer1.Enabled = true;
                timer1.Interval = 1000 * 60 * 2; //2 minuta;
            }
            else
            {
                timer1.Enabled = false;
            }
        }
        // STATISTIKA - jedan
        private void pnlMesec_Paint(object sender, PaintEventArgs e)
        {
            List<int> daniPosebno = new List<int>();
            int ukupnoDana = Statistika.racunajDane(rezervacije, automobili, daniPosebno, dpPocetakStatistika.Value.Date, dpKrajStatistika.Value.Date);
            ispisi(daniPosebno,ukupnoDana);
            Rectangle okvir = new Rectangle(50, 10, pnlMesec.Width-90, pnlMesec.Height-15);
            Crtanje.crtajMesec(e.Graphics, ukupnoDana, daniPosebno,okvir);
        }
        private void btnCrtajMesec_Click(object sender, EventArgs e)
        {
            pnlMesec.Invalidate();
        }
        private void ispisi(List<int> daniPosebno,int daniUkupno)
        {
            pnlMesecText.Controls.Clear();
            if (daniPosebno != null)
            for (int i = 0; i < daniPosebno.Count; i++)
            {
                Label nova = new Label();
                nova.Text = i + 1 + "    " + automobili[i].IdbrAuta + "     " + automobili[i].Marka + "    " + automobili[i].Model + "    " + daniPosebno[i] + "    " + Math.Round((float)(100.0 / daniUkupno* daniPosebno[i]),2)+"%";
                nova.Location = new Point(10, 10 + i * 25);
                nova.Width = pnlMesecText.Width - 50;
                pnlMesecText.Controls.Add(nova);
            }
            pnlMesecText.Invalidate();
        }
        private void pnlMesecText_Paint(object sender, PaintEventArgs e)
        {
            List<int> daniPosebno = new List<int>();
            int ukupnoDana = Statistika.racunajDane(rezervacije, automobili, daniPosebno, dpPocetakStatistika.Value.Date, dpKrajStatistika.Value.Date);
            Crtanje.crtajBoje(pnlMesecText.CreateGraphics(), pnlMesecText, daniPosebno);
        }
        private void pnlMesecText_Scroll(object sender, ScrollEventArgs e)
        {
            pnlMesecText.Invalidate();
        }
        private void rbMesec_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMesec.Checked)
            {
                pnlOkvirMesec.Visible = true;
                pnlGodinaOkvir.Visible = false;
            }
            else
            {
                pnlOkvirMesec.Visible = false;
                pnlGodinaOkvir.Visible = true;
            }
        }
        private void dpPocetakStatistika_ValueChanged(object sender, EventArgs e)
        {
            dpKrajStatistika.MinDate = dpPocetakStatistika.Value;
        }
        //STATISTIKA - dva
        private bool pomoc = false;
        private void cbAutoGodine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                automobilGodineStatistikaIdbr = cbAutoGodine.SelectedItem.ToString().Substring(6, 3);
            }
            else if (sender is Button)
            {
                Match provera = Regex.Match(txtAutoGodine.Text, @"^[1-9]{1}[0-9]{2}$");
                if (provera.Success)
                {
                    automobilGodineStatistikaIdbr = txtAutoGodine.Text;
                }
                else
                {
                    MessageBox.Show("IDBR mora biti u opsegu 100-999");
                    return;
                }
            }
            bool pomoc = true;
            foreach (Automobil automobil in automobili)
            {
                if ((automobil.IdbrAuta + "") == automobilGodineStatistikaIdbr)
                {
                    pomoc = false;
                    break;
                }
            }
            if (pomoc)
            {
                if (cbAutoGodine.SelectedIndex != -1)
                    automobilGodineStatistikaIdbr = cbAutoGodine.SelectedItem.ToString().Substring(6, 3);
                MessageBox.Show("Nije pronadjen automobil sa tim IDBR om");
            }
        }
        private void pnlGodina_Paint(object sender, PaintEventArgs e)
        {
            if(pomoc == true)
            {
                int prethodniBrojDana = 0;
                for (int i = 1; i <= 12; i++)
                {
                    int brojDana = Statistika.racunajDaneMesec(int.Parse(automobilGodineStatistikaIdbr), rezervacije, i, int.Parse(txtStatistikaGodina.Text));
                    Crtanje.crtajStatistikaGodine(e.Graphics, brojDana,prethodniBrojDana, i, pnlGodina,chkKriva.Checked);
                    prethodniBrojDana = brojDana;
                }
            }
            pomoc = false;

        }
        private void btnGodinaUcitaj_Click(object sender, EventArgs e)
        {
            if (automobilGodineStatistikaIdbr != "")
            {
                Match provera = Regex.Match(txtStatistikaGodina.Text, @"^[2]{1}[0]{1}[1,2]{1}[0-9]{1}$");
                if (!provera.Success)
                {
                    MessageBox.Show("Godina mora biti u opsegu 2010-2030");
                    return;
                }
                else
                {
                    pomoc = true;
                    pnlGodina.Invalidate();
                    foreach(Automobil automobil in automobili)
                    {
                        if (automobil.IdbrAuta + "" == automobilGodineStatistikaIdbr)
                            lblGodinaAutoInfo.Text = "IDBR: " + automobil.IdbrAuta + " Marka: " + automobil.Marka + " Model: " + automobil.Model;
                    }
                }
            }
            else
            {
                MessageBox.Show("Odaberite automobil prvo");
            }
        }

        private void chkKriva_CheckedChanged(object sender, EventArgs e)
        {
            pomoc = true;
            pnlGodina.Invalidate();
        }
    }
}
