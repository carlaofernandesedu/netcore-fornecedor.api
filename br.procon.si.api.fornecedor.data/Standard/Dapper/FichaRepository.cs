using System.Collections.Generic;
using br.procon.si.api.fornecedor.domain.Entities;
using br.procon.si.api.fornecedor.domain.Interfaces;
using br.procon.si.api.fornecedor.domain.Queries;
using br.procon.si.api.fornecedor.domain.VO;
using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.data.Standard.Dapper
{
    public class FichaRepository : ExtensionRepository<FichaAtendimento>, IFichaRepository
    {
        
        public FichaRepository(IUnitOfWork providerDB) : base(providerDB)
        {
        }
        public IEnumerable<FilaAtendimento> Listar(FichasPorFiltroQuery filtro)
        {
            var retornoEntidade = new FilaAtendimento { NomeConsumidor = "Nome Consumidor 01", NumDocumento = "001" };
            var lista = new List<FilaAtendimento>();
            lista.Add(retornoEntidade);
            return lista;
        }
    }
}