using Microsoft.Extensions.DependencyInjection;
using service;
using System;

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

            IKontoWeryfikacja konto =_servicesProvider.GetRequiredService<IKontoWeryfikacja>();

            while (Console.ReadKey().KeyChar == '1')
            {
                var kop = konto.Weryfikuj();
                if (kop.WynikPoprawny)
                {
                    Console.WriteLine("wynik ok");
                }
                else
                {
                    Console.WriteLine($"bład: {kop.Komunikat}");
                }
            }
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}
