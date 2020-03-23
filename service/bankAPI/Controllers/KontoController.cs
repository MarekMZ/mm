using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service;

namespace bankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontoController : ControllerBase
    {
        private readonly IKontoWeryfikacja _kontoWeryfikacja;
        private readonly IKontoOperacje _kontoOperacje;

        public KontoController(IKontoWeryfikacja kontoWeryfikacja, IKontoOperacje kontoOperacje)
        {
            _kontoWeryfikacja = kontoWeryfikacja;
            _kontoOperacje = kontoOperacje;
        }


        [HttpGet("wplac/{nrKonta:int}/{kwota:decimal}")]
        public IActionResult wplac (int nrKonta, decimal kwota)
        {
            Konto konto = new Konto();
            konto.Numer = nrKonta;
            konto.Kwota = kwota;
            WynikOperacjiNaKoncie wynik = _kontoOperacje.Wplata(konto);
            
            return Ok(wynik);
            
        }

        [HttpGet("wyplac/{nrKonta:int}/{kwota:decimal}")]
        public IActionResult wyplac(int nrKonta, decimal kwota)
        {
            Konto konto = new Konto();
            konto.Numer = nrKonta;
            konto.Kwota = kwota;

            var weryfikacja = _kontoWeryfikacja.Weryfikuj(konto);

            if (weryfikacja.WynikPoprawny == false)
            {
                return Ok(weryfikacja);
            }
            else
            {
                konto.CzyZweryfikowane = true;
                return Ok(_kontoOperacje.Wplata(konto));
            }
        }

        [HttpGet("info/{nrKonta:int}")]
        public IActionResult info(int nrKonta)
        {
            KontoInformacje konto = BazaKont.konta.Where(k => k.Numer == nrKonta).FirstOrDefault();
            return Ok(konto);
        }


    }
}