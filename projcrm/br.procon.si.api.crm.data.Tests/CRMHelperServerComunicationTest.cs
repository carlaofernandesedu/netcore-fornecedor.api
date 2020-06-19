﻿using br.procon.si.api.crm.data.Standard.RestHttp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace br.procon.si.api.crm.data.Tests
{
   
    public class CRMHelperServerComunicationTest
    {
        private CRMHelperServerComunication _cliente;
        private string _url;
        private HttpMethod _metodo;
        private string _body;

        [Fact]
        [Trait("Category","ComunicacaoSimples")]
        public void QuandoSolicitoPorGETSimplesEntaoOK()
        {
            ///ARRANGE
            _url = "http://www.g1.com.br";
            _metodo = HttpMethod.Get;
            _cliente = CRMHelperServerComunication.Construir();
            ///
            ///ACT
            var response = _cliente.Enviar(_url, _metodo).Result;
            ///ASSERT
            var mensagemRetorno = ((int)response.CodigoRetorno) == 0 ? response.MensagemException : ((int)response.CodigoRetorno).ToString();
            Assert.True(response.ExecutadoComSucesso,mensagemRetorno);
        }

        [Fact]
        [Trait("Category","ComunicacaoObjeto")]
        public void QuandoSolicitorPorGETObjetoEntaoRetornoObjetoOK()
        {
            ///ARRANGE
            _url = "http://desenv.mobile.sp.gov.br:90/servicosweb/api/atendimento/dominios/meiosaquisicoes";
            _metodo = HttpMethod.Get;
            _cliente = CRMHelperServerComunication.Construir();
            ///
            ///ACT
            var response = _cliente.Enviar<List<DominioTestDados>>(_url, _metodo).Result;
            ///ASSERT
            var mensagemRetorno = ((int)response.CodigoRetorno) == 0 ? response.MensagemException : ((int)response.CodigoRetorno).ToString();
            Assert.True(response.ExecutadoComSucesso, mensagemRetorno);
        }

        [Fact]
        [Trait("Category","ComunicacaoObjeto")]
        public void QuandoSolicitorPorGETObjeto_E_RedefinirCabecalhoEntaoRetornoObjetoOK()
        {
            ///ARRANGE
            _url = "http://desenv.mobile.sp.gov.br:90/servicosweb/api/atendimento/dominios/meiosaquisicoes";
            _metodo = HttpMethod.Get;
            _cliente = CRMHelperServerComunication.Construir().RedefinirCabecalhos();
            ///
            ///ACT
            var response = _cliente.Enviar<List<DominioTestDados>>(_url, _metodo).Result;
            ///ASSERT
            var mensagemRetorno = ((int)response.CodigoRetorno) == 0 ? response.MensagemException : ((int)response.CodigoRetorno).ToString();
            Assert.True(response.ExecutadoComSucesso,mensagemRetorno);
        }

        [Fact]
        [Trait("Category","ComunicacaoSimples")]
        public void QuandoSolicitoPorPostSimplesRetornarOK()
        {
            ///ARRANGE
            _url = "http://desenv.mobile.sp.gov.br:90/servicosweb/api/seguranca/token";
            _metodo = HttpMethod.Post;
            _cliente = CRMHelperServerComunication.Construir();
            var usuario = "carlos21@gmail.com";
            var senha = "123456";
            var encondingUsuarioHtml = usuario.Replace("@", "%40");
            _body = String.Concat("username=", encondingUsuarioHtml, "&password=", senha, "&grant_type=password");
            ///
            ///ACT
            var response = _cliente.Enviar(_url, _metodo, null, _body).Result;
            ///ASSERT
            var mensagemRetorno = ((int)response.CodigoRetorno) == 0 ? response.MensagemException : ((int)response.CodigoRetorno).ToString();
            Assert.True(response.ExecutadoComSucesso, mensagemRetorno);
        }

        [Fact]
        [Trait("Category","ComunicacaoSimples")]
        public void QuandoSolicitoPorPostObjetoRetornarTokenAutenticacao()
        {
            ///ARRANGE
            _url = "http://desenv.mobile.sp.gov.br:90/servicosweb/api/seguranca/token";
            _metodo = HttpMethod.Post;
            _cliente = CRMHelperServerComunication.Construir();
            var usuario = "carlos21@gmail.com";
            var senha = "123456";
            var encondingUsuarioHtml = usuario.Replace("@", "%40");
            _body = String.Concat("username=", encondingUsuarioHtml, "&password=", senha, "&grant_type=password");
            ///
            ///ACT
            var response = _cliente.Enviar<AutenticacaoTestDados>(_url, _metodo, null, _body).Result;
            ///ASSERT
            var mensagemRetorno = ((int)response.CodigoRetorno) == 0 ? response.MensagemException : ((int)response.CodigoRetorno).ToString();
            Assert.True(response.ExecutadoComSucesso,mensagemRetorno);
        }

        [Fact]
        [Trait("Category","ComunicacaoSimples")]
        public void QuandoSolicitorPorPUTSimplesEntaoOK()
        {
            ///ARRANGE
            _url = "http://desenv.mobile.sp.gov.br:90/servicosweb/api/atendimento/dominios/fornecedores";
            _metodo = HttpMethod.Put;
            _cliente = CRMHelperServerComunication.Construir();
            var objeto = new FornecedorTestDados() { Nome = "vivo", EhCNPJ = true, NumDocumento = null };
            _body = JsonConvert.SerializeObject(objeto);

            ///
            ///ACT
            var response = _cliente.Enviar(_url, _metodo,null,_body,"application/json").Result;
            ///ASSERT
            var mensagemRetorno = ((int)response.CodigoRetorno) == 0 ? response.MensagemException : ((int)response.CodigoRetorno).ToString();
            Assert.True(response.ExecutadoComSucesso, mensagemRetorno);
        }

        [Fact]
        [Trait("Category","ComunicacaoSimples")]
        public void QuandoSolicitorPorPUTObjetoEntaoRetornoObjetoOK()
        {
            ///ARRANGE
            _url = "http://desenv.mobile.sp.gov.br:90/servicosweb/api/atendimento/dominios/fornecedores";
            _metodo = HttpMethod.Put;
            _cliente = CRMHelperServerComunication.Construir();
            var objeto = new FornecedorTestDados() { Nome = "vivo", EhCNPJ = true, NumDocumento = null };
            _body = JsonConvert.SerializeObject(objeto);

            ///
            ///ACT
            var response = _cliente.Enviar<List<FornecedorTestDados>>(_url, _metodo, null, _body, "application/json").Result;
            ///ASSERT
            var mensagemRetorno = ((int)response.CodigoRetorno) == 0 ? response.MensagemException : ((int)response.CodigoRetorno).ToString();
            Assert.True(response.ExecutadoComSucesso, mensagemRetorno);
        }

        [Fact]
        [Trait("Category","ComunicacaoSimples")]
        public void QuandoSolicitorPorPUTObjetoRegistroNaoExisteEntao404()
        {
            ///ARRANGE
            _url = "http://desenv.mobile.sp.gov.br:90/servicosweb/api/atendimento/dominios/fornecedores";
            _metodo = HttpMethod.Put;
            _cliente = CRMHelperServerComunication.Construir();
            var objeto = new FornecedorTestDados() { Nome = "zzzz", EhCNPJ = true, NumDocumento = null };
            _body = JsonConvert.SerializeObject(objeto);

            ///
            ///ACT
            var response = _cliente.Enviar(_url, _metodo, null, _body, "application/json").Result;
            ///ASSERT
            var mensagemRetorno = ((int)response.CodigoRetorno) == 0 ? response.MensagemException : ((int)response.CodigoRetorno).ToString();
            Assert.True(404 == (int)response.CodigoRetorno,mensagemRetorno);
        }
    }
}
