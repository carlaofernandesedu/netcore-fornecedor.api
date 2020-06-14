using System.Reflection;
using AutoMapper;
using br.procon.si.api.fornecedor.domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace br.procon.si.api.fornecedor.ConfigServices
{
    public class InfraService : IConfigService
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup),typeof(FichaQueriesHandler));
        } 
    }
}