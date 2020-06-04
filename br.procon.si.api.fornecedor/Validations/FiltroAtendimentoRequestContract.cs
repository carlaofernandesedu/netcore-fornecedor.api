using br.procon.si.api.fornecedor.Contracts.V1.Requests;
using FluentValidator.Validation;

namespace br.procon.si.api.fornecedor.Validations
{
    public class FiltroAtendimentoRequestContract : BaseValidator
    {
        public FiltroAtendimentoRequestContract(FiltroAtendimentoRequest itemValidacao)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .IsNotNullOrEmpty(itemValidacao.NomeConsumidor,"NomeConsumidor","Nome do Consumidor deve ser preenchido");
        }
    }
}