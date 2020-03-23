using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using service;

namespace bank
{
    public class _Container
    {
        public void Reg(IServiceCollection services)
        {
            services.AddSingleton<IKontoWeryfikacja, KontoWeryfikacja>();
            services.AddSingleton<IKontoOperacje, KontoOperacje>();
        }

    }
}
