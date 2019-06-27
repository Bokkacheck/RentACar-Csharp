using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatProba
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            List<Korisnik> niz = new List<Korisnik>
            {
                new GlavniAdmin(1000,"Bojan","Stojkovic",new DateTime(1997,9,14),"1409997710038","0643000112","lozinka97"),
                new Kupac(1001,"Goran","Stojkovic",new DateTime(1973,4,15),"1409997710038","123456","lozinka73"),
                new Administrator(1002,"Ivan","Stojkovic",new DateTime(2005,10,25),"2510005710025","0631235988","lozinka05"),
                new Kupac(1003,"Olivera","Stojkovic",new DateTime(1974,5,14),"1409997710038","123654","lozinka74"),
                new Administrator(1004,"Mihajlo","Zivkovic",new DateTime(2008,1,24),"2401008710025","0613535772","lozinka"),
                new Kupac(1005,"Natalija","Zivkovic",new DateTime(2003,4,15),"1504003710256","0626599874","lozinka1"),

            };
            //List<Automobil> nizAutomobila = new List<Automobil>
            //{
            //    new Automobil(100,"Opel", "Corsa",2002,1400,"Prednji","Manuelni","Hecbek","Benzin+Gas (TNG)","4/5"),
            //    new Automobil(110,"Opel", "Corsa",2002,1400,"Prednji","Manuelni","Hecbek","Benzin+Gas (TNG)","4/5"),
            //    new Automobil(101,"Audi", "A3",2001,1800,"Zadnji","Manuelni","Dzip/Suv","Benzin+Gas (TNG)","4/5"),
            //    new Automobil(102,"Opel", "Grand-Land-X",2012,2000,"Prednji","Automatski","Hecbek","Dizel","4/5"),
            //    new Automobil(103,"Audi", "A3",2002,1600,"Prednji","Manuelni","Karavan","Benzin","2/3"),
            //    new Automobil(104,"Opel", "Corsa",2002,1650,"4X4","Manuelni","Hecbek","Benzin+Gas (TNG)","2/3"),
            //    new Automobil(105,"Volkswagen", "B5",2001,1400,"4X4","Manuelni","Monovolumen","Dizel","4/5"),
            //    new Automobil(106,"Audi", "A4",2014,2200,"Prednji","Automatski","Hecbek","Benzin","4/5"),
            //    new Automobil(107,"Opel", "Grand-Land-X",2012,2500,"Prednji","Manuelni","Hecbek","Benzin","4/5"),
            //    new Automobil(108,"Opel", "Grand-Land-X",2015,2000,"Prednji","Automatski","Hecbek","Dizel","4/5"),
            //    new Automobil(109,"Opel", "Astra",2012,2000,"Prednji","Automatski","Hecbek","Dizel","4/5"),

            //};
            //List<Ponuda> nizPonuda = new List<Ponuda>()
            //{
            //    new Ponuda(100,new DateTime(2019,4,14),new DateTime(2019,5,15),1200),
            //    new Ponuda(100,new DateTime(2019,4,25),new DateTime(2019,5,6),1600),
            //    new Ponuda(101,new DateTime(2019,4,19),new DateTime(2019,5,28),1200),
            //    new Ponuda(110,new DateTime(2019,4,14),new DateTime(2019,4,25),1000),
            //    new Ponuda(101,new DateTime(2019,4,4),new DateTime(2019,5,5),2000),
            //    new Ponuda(102,new DateTime(2019,5,14),new DateTime(2019,7,5),2400),
            //    new Ponuda(110,new DateTime(2019,4,25),new DateTime(2019,4,25),1000),
            //    new Ponuda(110,new DateTime(2019,5,23),new DateTime(2019,4,25),1000),
            //    new Ponuda(110,new DateTime(2019,4,14),new DateTime(2019,4,25),1000),
            //    new Ponuda(103,new DateTime(2019,6,4),new DateTime(2019,12,5),2600),
            //    new Ponuda(103,new DateTime(2019,6,4),new DateTime(2019,12,5),2600),
            //    new Ponuda(110,new DateTime(2019,8,25),new DateTime(2019,4,25),1000),
            //    new Ponuda(104,new DateTime(2019,8,4),new DateTime(2019,9,5),800),
            //    new Ponuda(110,new DateTime(2019,8,25),new DateTime(2019,4,25),1000),
            //};
            RadDatoteka.upisDatoteka(niz, "korisnici.json");
            //RadDatoteka.upisDatoteka(nizAutomobila, "automobili.json");
            //RadDatoteka.upisDatoteka(nizPonuda, "ponude.json");
            Login logIn = new Login();
            logIn.Show();
            Application.Run();
        }
    }
}
