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
        public static List<KontoInformacje> konta = new List<KontoInformacje>
        {
            new KontoInformacje{ Numer = 1, kontoStatus = KontoStatus.otwarte, Saldo = 100 },
            new KontoInformacje{ Numer = 2, kontoStatus = KontoStatus.zamkniete, Saldo = 0 },
            new KontoInformacje{ Numer = 3, kontoStatus = KontoStatus.zamrozone, Saldo = 300}
        };
    }
    
}
