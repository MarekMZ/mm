using System;
using System.Collections.Generic;
using System.Text;

namespace data
{
    public class KontoInformacje
    {
        public int Numer { get; set; }
        public decimal Saldo { get; set; }
        public KontoStatus kontoStatus { get; set; }
        public string kontoStatusOpis { get; set; }
    }
}
