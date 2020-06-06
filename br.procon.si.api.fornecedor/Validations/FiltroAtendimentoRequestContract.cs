using System.Collections.Generic;
using System.Linq;
using br.procon.si.api.fornecedor.Contracts.V1.Requests;
using br.procon.si.api.fornecedor.infra;
using FluentValidator.Validation;

namespace br.procon.si.api.fornecedor.Validations
{
    public class FiltroAtendimentoRequestContract : BaseValidator
    {
        public FiltroAtendimentoRequestContract(FiltroAtendimentoRequest itemValidacao)
        {
            List<string> camposObrigatorios = new List<string>
            {
                itemValidacao.NomeConsumidor,
                itemValidacao.NumDocumento
            };

            if (!camposObrigatorios.Any(x => !string.IsNullOrWhiteSpace(x)))
                Contract.AddNotification("todos","Informe pelo um campo para pesquisa");

            Contract
                .Requires()
                .HasMinLen(itemValidacao.NomeConsumidor,2,"nomeconsumidor","Nome do Consumidor deve ter no minimo 2 caracteres");
        }
    }
}