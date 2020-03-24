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

        public KontoInformacje Info(int kontoNr);
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

        public KontoInformacje Info(int kontoNr)
        {
            KontoInformacje informacje = BazaKont.konta.Where(k => k.Numer == kontoNr).FirstOrDefault();
            informacje.kontoStatusOpis = informacje.kontoStatus.ToString();
            return informacje;
        }


        public WynikOperacjiNaKoncie Zamrozenie(Konto konto)
        {
            KontoInformacje informacje = BazaKont.konta.Where(k => k.Numer == konto.Numer).FirstOrDefault();
            informacje.kontoStatus = KontoStatus.zamrozone;
            return new WynikOperacjiNaKoncie { Komunikat = "", SaldoPoOperacji = konto.Kwota, KontoStatus = KontoStatus.zamrozone };
        }

        public WynikOperacjiNaKoncie Zamkniecie(Konto konto)
        {
            KontoInformacje informacje = BazaKont.konta.Where(k => k.Numer == konto.Numer).FirstOrDefault();
            informacje.kontoStatus = KontoStatus.zamkniete;
            return new WynikOperacjiNaKoncie { Komunikat = "", SaldoPoOperacji = 0, KontoStatus = KontoStatus.zamkniete };
        }


    }
}
