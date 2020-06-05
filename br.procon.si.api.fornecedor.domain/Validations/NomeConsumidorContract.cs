using br.procon.si.api.fornecedor.infra;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator.Validation;
using br.procon.si.api.fornecedor.domain.VO;

namespace br.procon.si.api.fornecedor.domain.Validations
{
    public class NomeConsumidorContract : BaseValidator
    {
        public NomeConsumidorContract(FiltroAtendimento filtro) : base()
        {
            Contract
                .Requires()
                .HasMinLen(filtro.NomeConsumidor, 5, "nomeconsumidor", "Deve possuir 5 caracteres");
        }
    }
}
