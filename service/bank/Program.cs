using data;
using Microsoft.Extensions.DependencyInjection;
using service;
using System;
using System.Linq;

namespace bank
{
    class Program
    {

        

        static void Main(string[] args)
        {
            ServiceCollection _services = new ServiceCollection();
            ServiceProvider _servicesProvider;


            _Container container = new _Container();
            container.Reg(_services);
            _servicesProvider = _services.BuildServiceProvider();

            IKontoWeryfikacja kontoWeryfikacja =_servicesProvider.GetRequiredService<IKontoWeryfikacja>();


            Konto konto = BazaKont.konta.Where(k => k.Numer == 1).FirstOrDefault();


            while (Console.ReadKey().KeyChar == '1')
            {
                var kop = kontoWeryfikacja.Weryfikuj(konto);
                if (kop.WynikPoprawny)
                {
                    Console.WriteLine("wynik ok");
                    konto.CzyZweryfikowane = true;
                }
                else
                {
                    Console.WriteLine($"bład: {kop.Komunikat}");
                    konto.CzyZweryfikowane = false;
                }
            }
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}
