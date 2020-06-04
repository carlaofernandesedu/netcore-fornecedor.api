using br.procon.si.api.fornecedor.domain.Interfaces;
using br.procon.si.api.fornecedor.domain.Validations;
using br.procon.si.api.fornecedor.domain.VO;
using System;
using System.Collections.Generic;
using System.Text;

namespace br.procon.si.api.fornecedor.domain.Services
{
    public class FichaService : BaseService, IFichaService
    {
        public ResultadoServico<IEnumerable<FilaAtendimento>> Listar(FiltroAtendimento filtro)
        {
            var validacao = new NomeConsumidorContract(filtro).Validar();
            if (validacao.Falhou)
            {
                return new ResultadoServico<IEnumerable<FilaAtendimento>>(validacao);
            }

            var retornoEntidade = new FilaAtendimento { NomeConsumidor = "Nome Consumidor 01", NumDocumento = "001" };
            var lista = new List<FilaAtendimento>();
            lista.Add(retornoEntidade);
            return new ResultadoServico<IEnumerable<FilaAtendimento>>(lista,validacao);
        }
    }
}
