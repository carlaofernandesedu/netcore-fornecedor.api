using FluentValidator;
using FluentValidator.Validation;

namespace br.procon.si.api.fornecedor.infra
{
    public class BaseValidator : IContract
    {
        public ValidationContract Contract {get;protected set;}

        protected BaseValidator()
        {
            Contract = new ValidationContract();
        }
        public BaseValidator AdicionarContrato(BaseValidator regra)
        {
            Contract.AddNotifications(regra.Contract.Notifications);
            return this;
        }

        public ResultadoValidator Validar()
        {
            if (!Contract.Valid)     
             return new ResultadoValidator(sucesso:false,data:Contract.Notifications);

             return new ResultadoValidator(sucesso:true);

        }
    }
}