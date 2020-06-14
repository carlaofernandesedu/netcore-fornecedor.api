using br.procon.si.api.fornecedor.ConfigApp;
using br.procon.si.api.fornecedor.data.Standard.Dapper;
using br.procon.si.api.fornecedor.DataX
;
using br.procon.si.api.fornecedor.infra;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace br.procon.si.api.fornecedor.ConfigServices
{
    public class DataService : IConfigService
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {

                //TODO: Implementar Option Pattern
                var configDBOptions = new ConfigDBOptions();
                configuration.GetSection("ConnectionStrings").Bind(configDBOptions);
                services.AddScoped(typeof(IUnitOfWork),ctx=> new DapperUnitOfWork(configDBOptions));

                   services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();      
        }
    }
}