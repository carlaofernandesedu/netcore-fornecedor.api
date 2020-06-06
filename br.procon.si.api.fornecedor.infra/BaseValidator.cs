using FluentValidator;
using FluentValidator.Validation;

namespace br.procon.si.api.fornecedor.infra
{
    
    public class BaseValidator : IContract
    {
        private ValidationContract _contract = new ValidationContract();    
        public ValidationContract Contract 
        {
            get {return _contract;}
            protected set{ _contract = value;}
        }

        public BaseValidator AdicionarContrato(BaseValidator regra)
        {
            Contract.AddNotifications(regra.Contract.Notifications);
            return this;
        }

        public ResultadoValidator Validar()
        {
             return new ResultadoValidator(sucesso:Contract.Valid,data:Contract.Notifications);

        }
    }
}