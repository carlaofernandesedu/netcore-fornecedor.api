using br.procon.si.api.fornecedor.domain.Queries;
using br.procon.si.api.fornecedor.domain.VO;
using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.domain.Validations
{
    public class ListarValidation : BaseValidator
    {
        public ListarValidation(FiltroAtendimento filtro) 
        {
             AdicionarContrato(new NomeConsumidorContract(filtro));
             AdicionarContrato(new NumDocumentoContract(filtro));
        }

        public ListarValidation(FichasPorFiltroQuery filtro)  
        {
            Contract
                .Requires()
                .HasMinLen(filtro.NomeConsumidor, 5, "nomeconsumidor", "Deve possuir 5 caracteres");

            Contract
                .Requires()
                .IsNotNullOrEmpty(filtro.NumDocumento, "numdocumento", "Nao pode ser vazio");
        }
    }
}