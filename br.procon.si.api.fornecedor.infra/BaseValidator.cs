using FluentValidator;
using FluentValidator.Validation;

namespace br.procon.si.api.fornecedor.infra
{
    public class BaseValidator : IContract
    {
        public ValidationContract Contract {get;protected set;}

        public  ResultadoValidator Validar()
        {
            if (!Contract.Valid)     
             return new ResultadoValidator(sucesso:false,data:Contract.Notifications,mensagem:"Existem criticas");

             return new ResultadoValidator(sucesso:true);

        }
    }
}