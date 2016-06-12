using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace zam
{
    public enum TypWagi {Aln, Atz, Ata, Bts, Ats, Bd }      //enumy
    public enum RodzajWagi {a60, a80, a100, a200, a500, a1000 }
    public enum StatusZaawansowania { Wprowadzono, realizacja, pakowanie }

    



    public class Zamowienie : Wspolne 
    {
      
        public int Ilosc  { get; set; }         //propercje
        public string Odbiorca { get; set; }
        public TypWagi Typ{ get; set; }
        public RodzajWagi Rodzaj { get; set; }
        
        public string DataZamowienia { get; set; }


        //public DateTime Data { get; set; }
        public Zamowienie() { }

        public Zamowienie(int ilosc, string odbiorca, TypWagi typ, RodzajWagi rodzaj, string dataZamowienia, StatusZaawansowania status)
        {
            Ilosc = ilosc;           //konstruktor
            this.Odbiorca = odbiorca;
            this.Typ = typ;
            this.Rodzaj = rodzaj;
            this.DataZamowienia = dataZamowienia;
            this.Status = status;
        }


    }
}
