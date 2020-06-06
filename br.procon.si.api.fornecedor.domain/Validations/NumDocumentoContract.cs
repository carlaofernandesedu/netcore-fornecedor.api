

using br.procon.si.api.fornecedor.domain.VO;
using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.domain.Validations
{
    public class NumDocumentoContract : BaseValidator
    {
        public NumDocumentoContract(FiltroAtendimento filtro) 
        {
            Contract
                .Requires()
                .IsNotNullOrEmpty(filtro.NumDocumento, "numdocumento", "Nao pode ser vazio");
        }
    }
}