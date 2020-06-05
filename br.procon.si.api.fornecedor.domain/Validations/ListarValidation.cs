using br.procon.si.api.fornecedor.domain.VO;
using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.domain.Validations
{
    public class ListarValidation : BaseValidator
    {
        public ListarValidation(FiltroAtendimento filtro) : base()
        {
             AdicionarContrato(new NomeConsumidorContract(filtro));
             AdicionarContrato(new NumDocumentoContract(filtro));
        }
    }
}