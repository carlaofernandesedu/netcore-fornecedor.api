using br.procon.si.api.crm.domain.Interfaces;
using br.procon.si.api.crm.domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace br.procon.si.api.crm.ConfigServices
{
    public class AppService : IConfigService
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            // services.AddTransient<IFichaService, FichaService>();
            // services.AddTransient<IFichaRepository, FichaRepository>();
        }
    }
}
