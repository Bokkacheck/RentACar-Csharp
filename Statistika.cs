using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatProba
{
    class Statistika
    {
        public static int racunajDane(List<Rezervacija> rezervacije, List<Automobil> automobili, List<int> daniPosebno, DateTime pocetak, DateTime kraj)
        {
            int ukupnoDana = 0;
            int ukupnoAuto = 0;
            Rezervacija.sortirajRezervacije(rezervacije);
            for (int i = 0; i < automobili.Count; i++)
            {
                ukupnoAuto = 0;
                for (int j = 0; j < rezervacije.Count; j++)
                {
                    if (automobili[i].IdbrAuta == rezervacije[j].IdbrAuta)
                    {
                        if (rezervacije[j].PocetakRezervacije.Date >= pocetak && rezervacije[j].PocetakRezervacije <= kraj)
                        {
                            if (rezervacije[j].KrajRezervacije.Date <= kraj)
                            {
                                ukupnoAuto += (int)(rezervacije[j].KrajRezervacije.Date - rezervacije[j].PocetakRezervacije.Date).TotalDays;
                            }
                            else
                            {
                                ukupnoAuto += (int)(kraj - rezervacije[j].PocetakRezervacije.Date).TotalDays;
                            }
                        }
                        else if (rezervacije[j].KrajRezervacije >= pocetak && pocetak >= rezervacije[j].PocetakRezervacije)
                        {
                            if (rezervacije[j].KrajRezervacije <= kraj)
                            {
                                ukupnoAuto += (int)(rezervacije[j].KrajRezervacije - pocetak).TotalDays;
                            }
                            else if (rezervacije[j].KrajRezervacije > kraj)
                            {
                                ukupnoAuto += (int)(kraj - pocetak).TotalDays;
                            }
                        }
                    }
                }
                daniPosebno.Add(ukupnoAuto);
                ukupnoDana += ukupnoAuto;
            }
            return ukupnoDana;
        }
        public static int racunajDaneMesec(int autoIdbr,List<Rezervacija> rezervacije, int mesec, int godina)
        {
            int ukupnoAuto = 0;
            DateTime pocetak = new DateTime(godina, mesec, 1).Date;
            DateTime kraj = pocetak.AddMonths(1).AddDays(-1).Date;
            Rezervacija.sortirajRezervacije(rezervacije);
            for (int i = 0; i < rezervacije.Count; i++)
            {
                if (autoIdbr== rezervacije[i].IdbrAuta)
                {
                    if (rezervacije[i].PocetakRezervacije.Date >= pocetak && rezervacije[i].PocetakRezervacije <= kraj)
                    {
                        if (rezervacije[i].KrajRezervacije.Date <= kraj)
                        {
                            ukupnoAuto += (int)(rezervacije[i].KrajRezervacije.Date - rezervacije[i].PocetakRezervacije.Date).TotalDays+1;
                        }
                        else
                        {
                            ukupnoAuto += (int)(kraj - rezervacije[i].PocetakRezervacije.Date).TotalDays+1;
                        }
                    }
                    else if (rezervacije[i].KrajRezervacije >= pocetak && pocetak >= rezervacije[i].PocetakRezervacije)
                    {
                        if (rezervacije[i].KrajRezervacije <= kraj)
                        {
                            ukupnoAuto += (int)(rezervacije[i].KrajRezervacije - pocetak).TotalDays+1;
                        }
                        else if (rezervacije[i].KrajRezervacije > kraj)
                        {
                            ukupnoAuto += (int)(kraj - pocetak).TotalDays+1;
                        }
                    }
                }
            }
            return ukupnoAuto;
        }
    }
}
