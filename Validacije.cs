using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ProjekatProba
{
    static class Validacije
    {
        public static bool proveriPodatkeKorisnik(TextBox idbr, TextBox ime, TextBox prezime, TextBox datumRodjenja, TextBox jmbg, TextBox brojTelefon, TextBox lozinkaa, int tip)
        {
            if (idbr.Text == "" || ime.Text == "" || prezime.Text == "" || datumRodjenja.Text == "" || jmbg.Text == "" || brojTelefon.Text == "" || lozinkaa.Text == "" || (tip != 0 && tip != 1))
            {
                MessageBox.Show("Niste popunili sva polja! ");
                return false;
            }
            string odgovor = "";
            bool provera = true;
            Match regularniIzraz = Regex.Match(idbr.Text, @"^[1-9]{1}[0-9]{3}$");
            if (!regularniIzraz.Success)
            {
                odgovor += "IDBR nije u dozvoljenom opsegu (1000,9999)" + Environment.NewLine;
                provera = false;
                idbr.Clear();
            }
            regularniIzraz = Regex.Match(ime.Text, @"^[A-Z]{1}[a-z]{1,18}$");
            if (!regularniIzraz.Success)
            {
                odgovor += "Ime mora imati bar 2 karaktera, mora poceti velikim slovom, i moze sadrzati samo slova" + Environment.NewLine;
                provera = false;
                ime.Clear();
            }
            regularniIzraz = Regex.Match(prezime.Text, @"^[A-Z]{1}[a-z]{1,18}$");
            if (!regularniIzraz.Success)
            {
                odgovor += "Prezime mora imati bar 2 karaktera, mora poceti velikim slovom, i moze sadrzati samo slova" + Environment.NewLine;
                provera = false;
                prezime.Clear();
            }
            bool datumProvera = false;
            try
            {
                DateTime datum = DateTime.ParseExact(datumRodjenja.Text,"dd/MM/yyyy",CultureInfo.CurrentCulture);
                datumProvera = true;
            }
            catch
            {
                odgovor += "Datum nije u odgovarajucem formatu (dd/MM/yyyy - 01/01/1995)"+ Environment.NewLine;
                provera = false;
                datumRodjenja.Clear();
            }
            if (datumProvera)
            {
                DateTime datum = DateTime.ParseExact(datumRodjenja.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                string datumPomoc = (datum.Day<10? "0"+datum.Day: datum.Day+"") + (datum.Month < 10 ? "0" + datum.Month : datum.Month + "" )+ datum.Year.ToString().Remove(0, 1);
                if (!jmbg.Text.StartsWith(datumPomoc))
                {
                    odgovor += "JMBG mora pocinjati datutom rodjenja" + Environment.NewLine;
                    provera = false;
                    jmbg.Clear();
                }
            }
            regularniIzraz = Regex.Match(jmbg.Text, @"[0-9]{13}");
            if (!regularniIzraz.Success)
            {
                odgovor += "JMBG moze sadrzati samo brojeve" + Environment.NewLine;
                provera = false;
                jmbg.Clear();
            }
            regularniIzraz = Regex.Match(brojTelefon.Text, @"^06[0-9]{4,9}");
            if (!regularniIzraz.Success)
            {
                odgovor += "Broj telefona mora poceti sa 06, moze sadrzati samo brojeve i ne sme biti duzi od 10 cifri" + Environment.NewLine;
                provera = false;
                brojTelefon.Clear();
            }
            regularniIzraz = Regex.Match(lozinkaa.Text, @"^\w*\d\w*\d\w*$");
            if (!regularniIzraz.Success && lozinkaa.Text.Length < 8)
            {
                odgovor += "Lozinka mora da sadrzi bar 2 cifre, biti duza od 8 karaktera i sadrzati samo slova i cifre" + Environment.NewLine;
                provera = false;
                lozinkaa.Clear();
            }
            if (tip != 0 && tip != 1)
            {
                odgovor += "Morate odabrati tip" + Environment.NewLine;
                provera = false;
            }
            if(provera)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Doslo je do greske: " + Environment.NewLine + odgovor);
                return false;
            }
        }
        public static bool proveriPodatkeAutomobil(TextBox idbr,TextBox model,TextBox marka,TextBox godiste, TextBox kubikaza)
        {
            bool provera = true;
            string odgovor = "";
            Match regularniIzraz = Regex.Match(idbr.Text, @"^[1-9]{1}[0-9]{2}$");
            if (!regularniIzraz.Success)
            {
                odgovor += "IDBR mora biti u opsegu 100-999"+Environment.NewLine;
                provera = false;
                idbr.Clear();
            }
            regularniIzraz = Regex.Match(marka.Text, @"^[A-Z]{1}[a-zA-Z]*\s*-*[a-zA-Z]*$");
            if (!regularniIzraz.Success)
            {
                odgovor += "Marka mora pocinjati velikim slovom, moze sadrzati samo slova i imati samo jedan razmak ili crtu"+Environment.NewLine;
                provera = false;
                marka.Clear();
            }
            regularniIzraz = Regex.Match(model.Text, @"^[A-Z]{1}\w*-*\s*\w*-*\s*\w*-*\s*\w*$");
            if (!regularniIzraz.Success)
            {
                odgovor += "Model mora pocinjati velikim slovo, moze sadrzati najvise 4 reci odvojene razmakom ili crticom"+Environment.NewLine;
                provera = false;
                model.Clear();
            }
            regularniIzraz = Regex.Match(godiste.Text, @"^20[0,1]{1}[0-9]{1}$");
            if (!regularniIzraz.Success)
            {
                odgovor += "Godiste mora biti broj u opsegu 2000-2019"+Environment.NewLine;
                provera = false;
                godiste.Clear();
            }
            regularniIzraz = Regex.Match(kubikaza.Text, @"^([6-9][0-9]{2}|[1-5][0-9]{3}|6000)$");
            if(!regularniIzraz.Success)
            {
                odgovor += "Kubikaza mora biri broj u opsegu od 600-6000" + Environment.NewLine;
                provera = false;
                kubikaza.Clear();
            }
            if (provera)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Doslo je do greske" + Environment.NewLine + odgovor);
                return false;
            }
        }
        public static bool proveriPodatkePonuda(TextBox idbrAuto, TextBox cena)
        {
            bool provera = true;
            string odgovor = "";
            Match regularniIzraz = Regex.Match(idbrAuto.Text, @"^[1-9]{1}[0-9]{2}$");
            if (!regularniIzraz.Success)
            {
                odgovor += "IDBR auta mora biti u opsegu od 100 do 999"+Environment.NewLine;
                provera = false;
                idbrAuto.Clear();
            }
            regularniIzraz = Regex.Match(cena.Text, @"^[1-9]{1}[0-9]{2,6}$");
            if (!regularniIzraz.Success)
            {
                odgovor += "Cena mora biti izmedju 100 i 1000000"+Environment.NewLine;
                provera = false;
                cena.Clear();
            }
            if (!provera)
            {
                MessageBox.Show("Doslo je do greske: " + Environment.NewLine+odgovor);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
