using br.procon.si.api.fornecedor.domain.Interfaces;
using br.procon.si.api.fornecedor.domain.Queries;
using br.procon.si.api.fornecedor.domain.Validations;
using br.procon.si.api.fornecedor.domain.VO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace br.procon.si.api.fornecedor.domain.Services
{
    public class FichaService : BaseService, 
        IFichaService
    {
        public ResultadoServico<IEnumerable<FilaAtendimento>> Listar(FiltroAtendimento filtro)
        {
            var validacao = new ListarValidation(filtro).Validar();
            
            if (validacao.Falhou)
            {
                return new ResultadoServico<IEnumerable<FilaAtendimento>>(validacao);
            }

            var retornoEntidade = new FilaAtendimento { NomeConsumidor = "Nome Consumidor 01", NumDocumento = "001" };
            var lista = new List<FilaAtendimento>();
            lista.Add(retornoEntidade);
            return new ResultadoServico<IEnumerable<FilaAtendimento>>(lista);
        }

        
    }
}
