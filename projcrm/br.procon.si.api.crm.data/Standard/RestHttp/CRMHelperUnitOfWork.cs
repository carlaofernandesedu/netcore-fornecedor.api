﻿using br.procon.si.api.crm.infra;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace br.procon.si.api.crm.data.Standard.RestHttp
{
    public class CRMHelperUnitOfWork : IUnitOfWork
    {
        private readonly int _timeoutSegundos;
        private readonly CRMHelperDictionary _dicionario;
        private Autenticacao _conexaoSessao;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public CRMHelperUnitOfWork(CRMHelperDictionary dicionario, int timeoutSegundos = 300)
        {
            _timeoutSegundos = timeoutSegundos;
            _dicionario = dicionario;
        }

        public CRMHelperUnitOfWork(CRMHelperDictionary dicionario, string clientId, string secretId, int timeoutSegundos = 300)
        {
            _timeoutSegundos = timeoutSegundos;
            _dicionario = dicionario;
            _clientId = clientId;
            _clientSecret = secretId;
        }


        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        private class Autenticacao
        {
            public string access_token { get; set; }
            public string token_type { get; set; }

            public Dictionary<string, string> GerarCabecalhoAutenticacao()
            {
                var header = new Dictionary<string, string>();
               header.Add("Authorization",string.Concat(token_type," ",access_token));
                return header; 
            }
        }

        public T Get<T>(string chave, object parametrosEntidade = null, bool autenticar = true) where T : new()
        {
            Dictionary<string, string> cabecalho = null;

            if (autenticar)
                cabecalho = ObterCabecalhoDeAutenticacao(); 

           CRMHelperUriDetail recurso = _dicionario[chave];
           string url = recurso.Url;
           HttpMethod verboHttp = recurso.ObterMetodoHttp();
            string mediaType = recurso.ObterMediaType();

           string body = verboHttp != HttpMethod.Get ? Serializar(parametrosEntidade) : "";
           
           var cliente = CRMHelperServerComunication.Construir(_timeoutSegundos);
           var respostaServico = cliente.Enviar<T>(url, verboHttp, cabecalho, body,mediaType).Result;
           return respostaServico.Resultado;
        }

        public bool Execute(string chave, object parametrosEntidade = null,bool autenticar = true) 
        {
            Dictionary<string, string> cabecalho = null;

            if (autenticar)
                cabecalho = ObterCabecalhoDeAutenticacao();

            CRMHelperUriDetail recurso = _dicionario[chave];
            string url = recurso.Url;
            HttpMethod verboHttp = recurso.ObterMetodoHttp();
            string mediaType = recurso.ObterMediaType();

            string body = Serializar(parametrosEntidade);

            var cliente = CRMHelperServerComunication.Construir(_timeoutSegundos);
            var respostaServico = cliente.Enviar(url, verboHttp, cabecalho, body, mediaType).Result;
            return respostaServico.ExecutadoComSucesso;
        }

        public T Get<T>(string[] parametrosQuery, string chave, bool autenticar = false) where T : new()
        {
            Dictionary<string, string> cabecalho = null;

            if (autenticar)
                cabecalho = ObterCabecalhoDeAutenticacao();

            CRMHelperUriDetail recurso = _dicionario[chave];
            string url = recurso.Url;
            string body = "";
            HttpMethod verboHttp = recurso.ObterMetodoHttp();
            string mediaType = recurso.ObterMediaType();

            if (verboHttp == HttpMethod.Get)
                url = SubstituirQueryString(url, parametrosQuery);
         

            var cliente = CRMHelperServerComunication.Construir(_timeoutSegundos);
            var respostaServico = cliente.Enviar<T>(url, verboHttp, cabecalho, body, mediaType).Result;
            return respostaServico.Resultado;
        }

        private Dictionary<string,string> ObterCabecalhoDeAutenticacao()
        {
            if (_conexaoSessao == null)
            {
                var objeto = String.Concat("username=", _clientId, "&password=", _clientSecret, "&grant_type=password");
                _conexaoSessao = Get<Autenticacao>("POST001", objeto,false);
            }
            return _conexaoSessao.GerarCabecalhoAutenticacao();
        }


        private string SubstituirQueryString(string url, string[] parametros)
        {
            var retorno = url;
            if (parametros != null && parametros.Any())
                retorno = String.Format(url, parametros);

            return retorno;
        }

        private string Serializar(object parametros)
        {

            if (parametros != null)
            {
                return !(parametros is string) ?  JsonConvert.SerializeObject(parametros) : (string)parametros;
            }
            return "";
        }

       
    }

   
}
