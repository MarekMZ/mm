using System;
using System.Collections.Generic;

namespace data
{
    public enum KontoStatus
    {
        otwarte = 1,
        zamrozone = 2,
        zamkniete = 3
    }

    public class Konto
    {
        public int Numer { get; set; }
        public decimal Kwota { get; set; }
        public KontoStatus kontoStatus { get; set; }
        public bool? CzyZweryfikowane { get; set; }
    }

    public static class BazaKont
    {
        public static List<Konto> konta = new List<Konto>
        {
            new Konto{ Numer = 1, CzyZweryfikowane = null, kontoStatus = KontoStatus.otwarte, Kwota = 100 },
            new Konto{ Numer = 2, CzyZweryfikowane = null, kontoStatus = KontoStatus.zamkniete, Kwota = 0 },
            new Konto{ Numer = 3, CzyZweryfikowane = null, kontoStatus = KontoStatus.zamrozone, Kwota = 300}
        };
    }
    
}
