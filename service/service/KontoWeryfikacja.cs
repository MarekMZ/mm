using data;
using System;
using System.Collections.Generic;
using System.Text;

namespace service
{
    public interface IKontoWeryfikacja
    {
        public WynikOperacji Weryfikuj(Konto konto);
    }
    
    
    
    public class KontoWeryfikacja : IKontoWeryfikacja
    {
        public WynikOperacji Weryfikuj(Konto konto)
        {
            WynikOperacji wynik = new WynikOperacji();

            Random rnd = new Random();
            int r = rnd.Next(1, 3);

            int w = r % 2;
            
            if( r % 2 == 0)
            {
                wynik.Komunikat = "weryfikacja negatywna";
            }
            else
            {
                wynik.Komunikat = "";
            }
            return new WynikOperacji { Komunikat = "" };
        }

    }
}
