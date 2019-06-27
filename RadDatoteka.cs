using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;


namespace ProjekatProba
{
    static class RadDatoteka
    {
        public static JsonSerializerSettings podesavanjeJson = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };
        public static bool upisDatoteka<T>(T lista, string datoteka)
        {
            try
            {
                string tekst = JsonConvert.SerializeObject(lista, podesavanjeJson);
                File.WriteAllText(datoteka, tekst);
            }
            catch(IOException)
            {
                MessageBox.Show("Doslo je do greske sa upisom u datoteku, pokusajte opet");
                return false;
            }
            catch(Exception e)
            {
                MessageBox.Show("Doslo je do greske " + e.Message);
                return false;
            }
            return true;
        }
        public static List<T> citanjeDatoteke<T>(string datoteka)
        {
            try
            {
                string tekst = File.ReadAllText(datoteka);
                return (List<T>)JsonConvert.DeserializeObject<List<T>>(tekst, podesavanjeJson);
            }
            catch (IOException)
            {
                MessageBox.Show("Doslo je do greske sa upisom u datoteku, pokusajte opet");
            }
            catch (Exception e)
            {
                MessageBox.Show("Doslo je do greske " + e.Message);
            }
            return new List<T>(); ;
        }
    }
}
