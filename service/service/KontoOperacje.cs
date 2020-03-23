using data;
using System;

namespace service
{
    public interface IKontoOperacje
    {
        public WynikOperacjiNaKoncie Wplata(Konto konto);

        public WynikOperacjiNaKoncie Wyplata(Konto konto);

        public WynikOperacjiNaKoncie Zamrozenie(Konto konto);

        public WynikOperacjiNaKoncie Zamkniecie(Konto konto);
    }





    public class KontoOperacje : IKontoOperacje
    {
        public WynikOperacjiNaKoncie Wplata(Konto konto)
        {
            WynikOperacjiNaKoncie wynik = new WynikOperacjiNaKoncie();
            if (konto.kontoStatus == KontoStatus.zamkniete)
            {
                wynik.Komunikat = "odmowa wyplaty - konto zamknięte";
                return wynik;
            }

            wynik.Komunikat = "";
            wynik.SaldoPoOperacji = konto.Kwota + 200;
            wynik.KontoStatus = KontoStatus.otwarte;
            return wynik;
        }

        public WynikOperacjiNaKoncie Wyplata(Konto konto)
        {
            WynikOperacjiNaKoncie wynik = new WynikOperacjiNaKoncie();
            if (konto.CzyZweryfikowane != true)
            {
                wynik.Komunikat = "odmowa wyplaty - konto niezweryfikowane";
                return wynik;
            }
            if(konto.kontoStatus == KontoStatus.zamkniete)
            {
                wynik.Komunikat = "odmowa wyplaty - konto zamknięte";
                return wynik;
            }
            
            wynik.Komunikat = "";
            wynik.SaldoPoOperacji = konto.Kwota - 200;
            wynik.KontoStatus = KontoStatus.otwarte;
            return wynik;
        }

        public WynikOperacjiNaKoncie Zamkniecie(Konto konto)
        {
            return new WynikOperacjiNaKoncie { Komunikat = "", SaldoPoOperacji = 0, KontoStatus = KontoStatus.zamkniete };
        }

        public WynikOperacjiNaKoncie Zamrozenie(Konto konto)
        {
            return new WynikOperacjiNaKoncie { Komunikat = "", SaldoPoOperacji = konto.Kwota, KontoStatus = KontoStatus.zamrozone };
        }
    }
}
