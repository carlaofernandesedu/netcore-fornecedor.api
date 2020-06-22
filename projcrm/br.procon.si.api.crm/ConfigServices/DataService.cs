using System;
using br.procon.si.api.crm.Adapters;
using br.procon.si.api.crm.ConfigApp;
using br.procon.si.api.crm.data.Standard;
using br.procon.si.api.crm.data.Standard.Dapper;
using br.procon.si.api.crm.data.Standard.RestHttp;
using br.procon.si.api.crm.domain.Interfaces;
using br.procon.si.api.crm.infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static br.procon.si.api.crm.data.Standard.BaseRepositoryAsync;

namespace br.procon.si.api.crm.ConfigServices
{
    public class DataService : IConfigService
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
                //TODO: Implementar Option Pattern
                var configDBOptions = new ConfigDBOptions();
                 configuration.GetSection("ConnectionStrings").Bind(configDBOptions);

                var crmAPIOptions = new CrmAPIOptions();
                 configuration.GetSection("ApiCrmOptions").Bind(crmAPIOptions);
                var mapeamentoUrls = ParaCRMHelper.ConverterParaCRMHelperDictionary(crmAPIOptions);
                
                services.AddScoped(ctx => new DapperUnitOfWork(configDBOptions));
                services.AddScoped(ctx => new CRMHelperUnitOfWork(mapeamentoUrls,crmAPIOptions.ClientId,crmAPIOptions.Secret));
                services.AddTransient<ServiceResolver>(serviceProvider => key =>  
                    {  
                        switch (key)  
                        {  
                            case RepositorieTypesEnum.Dapper:  
                                return serviceProvider.GetService<DapperUnitOfWork>();  
                            case RepositorieTypesEnum.CRM:  
                                return serviceProvider.GetService<CRMHelperUnitOfWork>();  
                            default:  
                                return null;   
                        }  
                    });      
                services.AddTransient<IProconRepository, ProconRepository>();
                services.AddTransient<ICrmRepository, CrmRepository>();

        }

    }
}