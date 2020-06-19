using br.procon.si.api.crm.infra;

namespace br.procon.si.api.crm.ConfigApp
{
    public class ConfigDBOptions : IDataSettings
    {
        public string DefaultConnection { get;set; }
        public int? commandTimeout { get;set;}
    }
}