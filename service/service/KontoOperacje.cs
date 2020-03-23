using data;
using System;
using System.Linq;

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

            KontoInformacje ko = BazaKont.konta.Where(k => k.Numer == konto.Numer).FirstOrDefault();


            if (ko.kontoStatus == KontoStatus.zamkniete)
            {
                wynik.Komunikat = "odmowa wyplaty - konto zamknięte";
                return wynik;
            }

            ko.Saldo += konto.Kwota;
            ko.kontoStatus = KontoStatus.otwarte;

            wynik.Komunikat = "";
            wynik.SaldoPoOperacji = ko.Saldo;
            wynik.KontoStatus = ko.kontoStatus;
            return wynik;
        }

        public WynikOperacjiNaKoncie Wyplata(Konto konto)
        {
            WynikOperacjiNaKoncie wynik = new WynikOperacjiNaKoncie();

            KontoInformacje ko = BazaKont.konta.Where(k => k.Numer == konto.Numer).FirstOrDefault();

            if (konto.CzyZweryfikowane != true)
            {
                wynik.Komunikat = "odmowa wyplaty - konto niezweryfikowane";
                return wynik;
            }
            if(ko.kontoStatus == KontoStatus.zamkniete)
            {
                wynik.Komunikat = "odmowa wyplaty - konto zamknięte";
                return wynik;
            }

            ko.Saldo -= konto.Kwota;
            ko.kontoStatus = KontoStatus.otwarte;

            wynik.Komunikat = "";
            wynik.SaldoPoOperacji = ko.Saldo;
            wynik.KontoStatus = ko.kontoStatus;
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
