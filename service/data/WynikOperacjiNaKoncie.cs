using System;
using System.Collections.Generic;
using System.Text;

namespace data
{
    public class WynikOperacjiNaKoncie:WynikOperacji
    {
        public decimal? SaldoPoOperacji { get; set; }
        public KontoStatus KontoStatus { get; set; }
    }
}
