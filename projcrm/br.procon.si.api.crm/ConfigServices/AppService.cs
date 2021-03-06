﻿using br.procon.si.api.crm.data.Standard.Dapper;
using br.procon.si.api.crm.data.Standard.RestHttp;
using br.procon.si.api.crm.domain.Interfaces;
using br.procon.si.api.crm.domain.Services;
using br.procon.si.api.crm.HostApp;
using br.procon.si.api.crm.infra.HostApp;
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
            services.AddTransient<IEventoService, EventoService>();
            //services.AddHostedService<EventoBackgroundService>();
            services.AddHostedService<ConsumeScopedServiceHostedService>();
            services.AddScoped<IScopedProcessingService, EventoScopedService>();

        }
    }
}
