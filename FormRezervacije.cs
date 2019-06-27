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
    public partial class FormRezervacije : Form
    {
        private List<Ponuda> ponude;
        private List<Automobil> automobili;
        private List<Rezervacija> rezervacije;
        private List<Rezervacija> oRezervacije; //postojece rezervacije za odabrani auto
        private List<Automobil> odabrani;
        private List<Ponuda> oPonude;   //odabrane ponude za izabrani auto(cele)
        private List<Korisnik> korisnici;
        private List<Ponuda> iPonude; //ponude za odabrani auto (izracunate)
        private Rezervacija trenutnaRezervacija;
        private int korisnikIdbr;
        public FormRezervacije()
        {
            InitializeComponent();
        }
        public FormRezervacije(int k) :this()
        {
            korisnikIdbr = k;
            automobili = RadDatoteka.citanjeDatoteke<Automobil>("automobili.json");
            ponude = RadDatoteka.citanjeDatoteke<Ponuda>("ponude.json");
            Ponuda.azurirajDatum(ponude);
            rezervacije = RadDatoteka.citanjeDatoteke<Rezervacija>("rezervacije.json");
            this.FormClosed += Login.ugasiProgram;
            popuniCb(automobili, cbMarka);
            odabrani = new List<Automobil>();
            korisnici = RadDatoteka.citanjeDatoteke<Korisnik>("korisnici.json");
            dpPreuzimanje.MinDate = DateTime.Now.Date;
            dpVracanje.MinDate = DateTime.Now.Date;
        }
        //IZBOR AUTA
        private void popuniCb(List<Automobil> lista,ComboBox cb)
        {
            foreach (Automobil auto in lista)
            {
                bool nadjen = false;
                string podatak = auto.vratiSvojstvo(cb.Name);
                foreach (string postojeci in cb.Items)
                {
                    if (podatak == postojeci)
                    {
                        nadjen = true;
                        break;
                    }
                }
                if (!nadjen)
                {
                    cb.Items.Add(podatak);
                }
            }
        }
        private void cisti()
        {
            lbPonude.Items.Clear();
            txtCena.Text = "";
            trenutnaRezervacija = null;
            dpPreuzimanje.Value = DateTime.Now.Date;
            dpVracanje.Value = DateTime.Now.Date;
        }
        private void NoviOdabir(object sender, EventArgs e)
        {
            if (((ComboBox)sender) == cbMarka)
            {
                cisti();
                foreach (ComboBox cb in this.Controls.OfType<ComboBox>())
                {
                    if (cb != cbMarka) cb.Items.Clear();
                }
            }

            if (((ComboBox)sender) == cbModel)
            {
                cisti();
                foreach (ComboBox cb in this.Controls.OfType<ComboBox>())
                {
                    if (cb != cbMarka && cb != cbModel) cb.Items.Clear();
                }
            }
            odabrani = new List<Automobil>();
            foreach (Automobil auto in automobili)      //provera auta
            {
                bool odgovara = true;
                foreach (ComboBox cb in this.Controls.OfType<ComboBox>())
                {
                    if (cb.SelectedIndex != -1)
                    {
                        if (auto.vratiSvojstvo(cb.Name) != cb.SelectedItem + "")
                        {
                            odgovara = false;
                        }
                    }
                }
                if (odgovara)
                {
                    odabrani.Add(auto);
                }
            }
            foreach (ComboBox cb in this.Controls.OfType<ComboBox>())
            {
                if (cb!=cbMarka)
                {
                    if (cb != cbModel)
                    {
                        cb.Items.Clear();
                    }
                    popuniCb(odabrani,cb);
                }
                if (cb.Items.Count == 1)
                {
                    cb.SelectedIndex = 0;
                }
            }
        }
        //PRIKAZ PONUDA
        private void btnPrikaziPonude_Click(object sender, EventArgs e)
        {
            cisti();
            oPonude = new List<Ponuda>();
            oRezervacije = new List<Rezervacija>();
            foreach (ComboBox cb in this.Controls.OfType<ComboBox>())
            {
                if(cb.SelectedIndex == -1)
                {
                    MessageBox.Show("Popunite sva polja");
                    return;
                }
            }
            foreach(Automobil auto in odabrani)
            {
                foreach(Ponuda p in ponude)
                {
                    if(auto.IdbrAuta == p.IdbrAuta)
                    {
                        oPonude.Add(p);
                    }
                }
                foreach(Rezervacija r in rezervacije)
                {
                    if(auto.IdbrAuta == r.IdbrAuta)
                    {
                        oRezervacije.Add(r);
                    }
                }
            }
            Ponuda.sortirajPonudu(oPonude);
            Rezervacija.sortirajRezervacije(oRezervacije);
            racunajPonude();
        }
        private void racunajPonude()
        {
            iPonude = new List<Ponuda>();
            DateTime ponPocetak, ponKraj, rezPocetak, rezKraj;
            for(int i = 0; i < oPonude.Count; i++)
            {
                bool provera = true;
                bool cela = true;
                for (int j = 0; j < oRezervacije.Count; j++)
                {
                    if (oPonude[i].IdbrAuta == oRezervacije[j].IdbrAuta)
                    {
                        provera = false;
                        ponPocetak = oPonude[i].DatumOd.Date;
                        ponKraj = oPonude[i].DatumDo.Date;
                        rezPocetak = oRezervacije[j].PocetakRezervacije.Date;
                        rezKraj = oRezervacije[j].KrajRezervacije.Date;
                        if (ponPocetak >= rezPocetak && ponKraj <= rezKraj) // sredjen prvi
                        {
                            cela = false;
                            break;
                        }
                        else if (ponPocetak >= rezPocetak && ponPocetak <= rezKraj && ponKraj>rezKraj) //radi drugi
                        {
                            cela = false;
                            oPonude[i] = new Ponuda(oPonude[i].IdbrAuta, rezKraj.AddDays(1).Date, ponKraj, oPonude[i].CenaDan);
                            if (j == oRezervacije.Count - 1)
                            {
                                iPonude.Add(oPonude[i]);
                                break;
                            }
                            else if (ponKraj < oRezervacije[j+1].PocetakRezervacije.Date || oRezervacije[j+1].IdbrAuta != oPonude[i].IdbrAuta)
                            {
                                iPonude.Add(oPonude[i]);
                                break;
                            }
                        }
                        else if (ponPocetak <= rezPocetak && ponKraj >= rezKraj)        //treci
                        {
                            cela = false;
                            oPonude[i] = new Ponuda(oPonude[i].IdbrAuta, rezKraj.AddDays(1).Date, ponKraj, oPonude[i].CenaDan);
                            iPonude.Add(new Ponuda(oPonude[i].IdbrAuta, ponPocetak.Date, rezPocetak.AddDays(-1).Date, oPonude[i].CenaDan));
                            if (j == oRezervacije.Count - 1)
                            {
                                iPonude.Add(oPonude[i]);
                                break;
                            }
                            else if (ponKraj < oRezervacije[j + 1].PocetakRezervacije.Date || oRezervacije[j + 1].IdbrAuta != oPonude[i].IdbrAuta)
                            {
                                iPonude.Add(oPonude[i]);
                                break;
                            }
                        }
                        else if (ponPocetak <= rezPocetak && ponKraj <= rezKraj&& ponKraj>rezPocetak)
                        {
                            cela = false;
                            iPonude.Add(new Ponuda(oPonude[i].IdbrAuta, ponPocetak, rezPocetak.AddDays(-1).Date, oPonude[i].CenaDan));
                            break;
                        }
                    }
                }
                if (provera||cela)
                {
                    iPonude.Add(oPonude[i]);
                }
            }
            ispisiPonude();
        }
        private void ispisiPonude()
        {
            for(int i = 0; i < iPonude.Count; i++)
            {
                if (iPonude[i].DatumOd > iPonude[i].DatumDo)
                {
                    iPonude.RemoveAt(i--);
                }
            }
            int brojac = 0;
            bool prvi = true;
            foreach (Automobil auto in odabrani)
            {
                brojac++;
                prvi = true;
                foreach (Ponuda p in iPonude)
                {
                    if (auto.IdbrAuta == p.IdbrAuta)
                    {
                        if (prvi)
                        {
                            lbPonude.Items.Add("Ponuda za " + brojac + ". auto");
                        }
                        prvi = false;
                        lbPonude.Items.Add(p);
                    }
                }
            }
        }
        //REZERVACIJA
        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            if(trenutnaRezervacija != null)
            {
                rezervacije.Add(trenutnaRezervacija);
                RadDatoteka.upisDatoteka(rezervacije, "rezervacije.json");
                MessageBox.Show("Uspesno upisana rezervacija");
                btnPrikaziPonude_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Rezervacija nije upisana, odaberite novu rezervaciju");
            }
        }
        private void dpPreuzimanje_ValueChanged(object sender, EventArgs e)
        {
            dpVracanje.MinDate = dpPreuzimanje.Value.Date;
            dpVracanje_ValueChanged(sender, e);
        }
        private void dpVracanje_ValueChanged(object sender, EventArgs e)
        {
            if (iPonude == null) return;
            trenutnaRezervacija = null;
            DateTime pocetak = dpPreuzimanje.Value.Date;
            DateTime kraj = dpVracanje.Value.Date;
            double ukupnaCena = 0;
            for (int i = 0; i < iPonude.Count; i++)
            {
                ukupnaCena = 0;
                if (pocetak >= iPonude[i].DatumOd && pocetak <= iPonude[i].DatumDo)   //nasli smo mogucu pocetnu ponudu
                {
                    int brojac = 0;
                    for (int j = i; j < iPonude.Count; j++)     //nastavlajm dalje kroz ponude
                    {
                        if (iPonude[i].IdbrAuta == iPonude[j].IdbrAuta)
                        {
                            if (i == j || (iPonude[j].DatumOd.Date - iPonude[i + brojac++].DatumDo).TotalDays == 1)
                            {
                                ukupnaCena = ukupnaCena + iPonude[j].CenaDan * ((iPonude[j].DatumDo.Date - iPonude[j].DatumOd.Date).TotalDays);
                                if (iPonude[j].DatumDo.Date >= kraj)
                                {
                                    ukupnaCena = ukupnaCena - iPonude[i].CenaDan * ((pocetak - iPonude[i].DatumOd.Date).TotalDays);
                                    ukupnaCena = ukupnaCena - iPonude[j].CenaDan * ((iPonude[j].DatumDo.Date - kraj).TotalDays - 1);
                                    txtCena.Text = ukupnaCena + "";
                                    trenutnaRezervacija = new Rezervacija(pocetak.Date, kraj.Date, iPonude[i].IdbrAuta, korisnikIdbr, ukupnaCena);
                                    return;
                                }
                            }
                            else
                            {
                                i = j;
                                break;
                            }
                        }
                        else
                        {
                            i = j;
                            break;
                        }
                    }
                }
            }
            txtCena.Text = "Nije moguca rezervacija";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Korisnik k in korisnici)
            {
                if(korisnikIdbr == k.Idbr)
                {
                    new KorisnickaForma(k).Show();
                    this.Close();
                }
            }
        }
    }

}
