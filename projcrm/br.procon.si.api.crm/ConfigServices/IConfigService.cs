using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace br.procon.si.api.crm.ConfigServices
{
    public interface IConfigService
    {
         void Install(IServiceCollection services,IConfiguration configuration);
    }
}