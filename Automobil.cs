using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatProba
{
    class Automobil
    {
        int idbrAuta;
        string marka;
        string model;
        int godiste;
        int kubikaza;
        string pogon;
        string vrstaMenjaca;
        string karoserija;
        string gorivo;
        string brojVrata;

        public Automobil()
        {
            idbrAuta = 0;
        }
        public Automobil(int idbrAuta, string marka, string model, int godiste,int kubikaza,string pogon,string vrstaMenjaca,string karoserija,string gorivo,string brojVrata)
        {
            this.idbrAuta = idbrAuta;
            this.marka = marka;
            this.model = model;
            this.godiste = godiste;
            this.kubikaza = kubikaza;
            this.pogon = pogon;
            this.vrstaMenjaca = vrstaMenjaca;
            this.karoserija = karoserija;
            this.gorivo = gorivo;
            this.brojVrata = brojVrata;
        }
        public static bool obrisiAutomobil(List<Automobil> automobili,string automobilIDBR)
        {
            for(int i=0;i<automobili.Count;i++)
            {
                if ((automobili[i].IdbrAuta + "") == automobilIDBR)
                {
                    automobili.RemoveAt(i);
                    RadSlika.obrisiSliku("automobil", automobilIDBR);
                    MessageBox.Show("Automobil obrisan");
                    return true;
                }
            }
            return false;
        }
        public static bool dodajAutomobil(List<Automobil> automobili, int idbrAuta, string marka,string model,int godiste,int kubikaza,string pogon,string vrstaMenjaca,string karoseroja,string gorivo,string brojVrata)
        {
            if (proveraAutomobila(automobili, idbrAuta))
            {
                automobili.Add(new Automobil(idbrAuta, marka, model, godiste, kubikaza, pogon, vrstaMenjaca, karoseroja, gorivo, brojVrata));
                MessageBox.Show("Vozilo dodato");
                return true;
            }
            else
            {
                MessageBox.Show("Vec postoji automobil sa ovim IDBRom, vozilo nije izmenjeno/dodato");
                return false;
            }
        }
        public static bool izmeniAutomobil(List<Automobil> automobili,string originalIDBR, int idbrAuta, string marka, string model, int godiste, int kubikaza, string pogon, string vrstaMenjaca, string karoseroja, string gorivo, string brojVrata)
        {
            int pozicijaKorisnikaUListi = 0;
            Automobil automobil = null;
            for (int i = 0; i < automobili.Count; i++)
            {
                if (originalIDBR == automobili[i].idbrAuta+"")
                {
                    pozicijaKorisnikaUListi = i;
                    automobil = automobili[i];
                    automobili[i] = new Automobil();
                }
            }
            if (proveraAutomobila(automobili, idbrAuta))
            { 
                automobili[pozicijaKorisnikaUListi] = new Automobil(idbrAuta, marka, model,godiste, kubikaza, pogon, vrstaMenjaca, karoseroja, gorivo,brojVrata);
                RadSlika.promenaIDBRaSlika("automobil", originalIDBR + "", idbrAuta + "");
                MessageBox.Show("Vozilo izmenjeno");
                return true;
            }
            else
            {
                automobili[pozicijaKorisnikaUListi] = automobil;
                MessageBox.Show("Vec postoji automobil sa ovim IDBRom, vozilo nije izmenjeno");
                return false;
            }
        }
        public static bool proveraAutomobila(List<Automobil> automobili,int idbrAuta)
        {
            foreach (Automobil automobil in automobili)
            {
                if (automobil.idbrAuta == idbrAuta)
                {
                    return false;
                }
            }
            return true;
        }
        public string vratiSvojstvo(string ime)
        {
            switch (ime)
            {
                case "cbMarka": return this.Marka;
                case "cbModel": return this.Model;
                case "cbGodiste": return this.Godiste + "";
                case "cbKubikaza": return this.Kubikaza + "";
                case "cbMenjac": return this.VrstaMenjaca;
                case "cbBrojVrata": return this.BrojVrata;
                case "cbGorivo":return this.Gorivo;
                case "cbKaroserija":return this.Karoserija;
                case "cbPogon": return this.Pogon;
                default: return "";
            }
        }
        public int IdbrAuta { get => idbrAuta; set => idbrAuta = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public int Godiste { get => godiste; set => godiste = value; }
        public int Kubikaza { get => kubikaza; set => kubikaza = value; }
        public string Pogon { get => pogon; set => pogon = value; }
        public string VrstaMenjaca { get => vrstaMenjaca; set => vrstaMenjaca = value; }
        public string Karoserija { get => karoserija; set => karoserija = value; }
        public string Gorivo { get => gorivo; set => gorivo = value; }
        public string BrojVrata { get => brojVrata; set => brojVrata = value; }

    }
}
