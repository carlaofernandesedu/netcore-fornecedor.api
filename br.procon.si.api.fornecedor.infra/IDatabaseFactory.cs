using System.Data;

namespace br.procon.si.api.fornecedor.infra
{
    public interface IDatabaseFactory
    {
        IDbConnection GetDbConnection { get; }
    }

}