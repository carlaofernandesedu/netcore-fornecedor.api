using br.procon.si.api.fornecedor.Contracts.V1.Requests;
using br.procon.si.api.fornecedor.infra;
using FluentValidator.Validation;

namespace br.procon.si.api.fornecedor.Validations
{
    public class FiltroAtendimentoRequestContract : BaseValidator
    {
        public FiltroAtendimentoRequestContract(FiltroAtendimentoRequest itemValidacao)
        {
            Contract
                .Requires()
                .IsNotNullOrEmpty(itemValidacao.NomeConsumidor,"nomeconsumidor","Nome do Consumidor deve ser preenchido");
        }
    }
}