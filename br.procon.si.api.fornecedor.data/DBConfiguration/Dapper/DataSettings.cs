using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.data.DBConfiguration.Dapper
{
    public class DataSettings : IDataSettings
    {
        public string DefaultConnection { get; set;}
        public int? commandTimeout { get;set;}
    }
}