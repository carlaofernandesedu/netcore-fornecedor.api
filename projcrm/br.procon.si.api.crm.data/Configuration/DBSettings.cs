using br.procon.si.api.crm.infra;

namespace br.procon.si.api.crm.data.Configuration
{
    public class DBSettings : IDataSettings
    {
        public const string DBSettingsOptions = "ConnectionStrings";
        public string DefaultConnection { get;set; }
        public int? commandTimeout { get;set;}
    }
}