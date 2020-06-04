﻿using br.procon.si.api.fornecedor.infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace br.procon.si.api.fornecedor.domain
{
    public class ResultadoServico<T>
    {
        public ResultadoValidator Validacao{get; private set;}

        public ResultadoServico()
        {

        }

        public ResultadoServico(ResultadoValidator resultado)
        {
            Validacao = resultado;
        }
        public ResultadoServico(T response) => Data = response;

        public T Data { get; set; }

        public void DefinirResultadoValidacao(ResultadoValidator resultado)
        {
            Validacao = resultado;
        }
    }
}