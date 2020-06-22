using System;
using System.Reflection;
using AutoMapper;
using br.procon.si.api.crm.domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace br.procon.si.api.crm.ConfigServices
{
    public class InfraService : IConfigService
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(Startup));
        } 
    }
}