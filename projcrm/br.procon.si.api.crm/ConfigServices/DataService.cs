using br.procon.si.api.crm.ConfigApp;
using br.procon.si.api.crm.data.Standard.Dapper;
using br.procon.si.api.crm.infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace br.procon.si.api.crm.ConfigServices
{
    public class DataService : IConfigService
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {

                //TODO: Implementar Option Pattern
                // var configDBOptions = new ConfigDBOptions();
                // configuration.GetSection("ConnectionStrings").Bind(configDBOptions);
                // services.AddScoped(typeof(IUnitOfWork),ctx=> new DapperUnitOfWork(configDBOptions));
                       
        }
    }
}