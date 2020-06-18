using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace br.procon.si.api.crm.data.Standard.RestHttp
{
    //Codigo baseado artigo https://johnthiriet.com/efficient-api-calls/
    public class CRMHelperServerComunication
    {

        #region "Atributos"
        private readonly TimeSpan _timeout;
        private bool _redefinirCabecalhos;
        private bool _headerNoCache;
        #endregion

        #region "Construtores"
        protected CRMHelperServerComunication(int timeoutSeconds = 300)
        {
            _timeout = TimeSpan.FromSeconds(timeoutSeconds);
        }
        public static CRMHelperServerComunication Construir(int timeoutSeconds)
        {
            return new CRMHelperServerComunication(timeoutSeconds);
        }

        public static CRMHelperServerComunication Construir()
        {
            return new CRMHelperServerComunication();
        }

        #endregion

        #region "Operacoes Envio"

        public async Task<RespostaServico<T>> Enviar<T>(string url, HttpMethod verboHttp, Dictionary<string, string> headers = null, string body = "", string mediaType = "") where T : new()
        {
            var resposta = new RespostaServico<T>();
            using (var client = new HttpClient() { Timeout = _timeout })
            {

                try
                {

                    using (var request = new HttpRequestMessage())
                    {
                        request.Method = verboHttp;
                        request.RequestUri = new Uri(url);

                        if (_redefinirCabecalhos)
                        {
                            client.DefaultRequestHeaders.Accept.Clear();
                            if (_headerNoCache)
                                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };
                        }

                        if (headers != null)
                        {
                            foreach (var key in headers.Keys)
                            {
                                request.Headers.Add(key, headers[key]);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(body))
                        {
                            request.Content = string.IsNullOrWhiteSpace(mediaType) ? new StringContent(body, Encoding.UTF8) : new StringContent(body, Encoding.UTF8, mediaType);
                        }

                        var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                        resposta.CodigoRetorno = response.StatusCode;
                        resposta.ExecutadoComSucesso = response.IsSuccessStatusCode;
                        var stream = await response.Content.ReadAsStreamAsync();
                        if (response.IsSuccessStatusCode)
                        {

                            resposta.Resultado = DeserializeJsonFromStream<T>(stream);
                        }
                        else
                        {
                            resposta.InfoResponse = await StreamToStringAsync(stream);
                        }
                    }
                }
                catch (WebException webex)
                {
                    resposta.ClasseException = webex.GetType().ToString();
                    resposta.MensagemException = webex.InnerException != null ? string.Concat(webex.Message, "|", webex.InnerException.Message) : webex.Message;
                    resposta.ExecutadoComSucesso = false;
                }
                catch (Exception ex)
                {
                    resposta.ClasseException = ex.GetType().ToString();
                    resposta.MensagemException = ex.InnerException != null ? string.Concat(ex.Message, "|", ex.InnerException.Message) : ex.Message;
                    resposta.ExecutadoComSucesso = false;
                }


            }
            return resposta;
        }


        public async Task<RespostaServico<string>> Enviar(string url, HttpMethod verboHttp, Dictionary<string, string> headers = null, string body = "", string mediaType = "")
        {
            var resposta = new RespostaServico<string>();
            using (var client = new HttpClient() { Timeout = _timeout })
            {
                try
                {
                    using (var request = new HttpRequestMessage())
                    {
                        request.Method = verboHttp;
                        request.RequestUri = new Uri(url);
                        if (_redefinirCabecalhos)
                        {
                            client.DefaultRequestHeaders.Accept.Clear();
                            if (_headerNoCache)
                                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };
                        }
                        if (headers != null)
                        {
                            foreach (var key in headers.Keys)
                            {
                                request.Headers.Add(key, headers[key]);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(body))
                        {
                            request.Content = string.IsNullOrWhiteSpace(mediaType) ? new StringContent(body, Encoding.UTF8) : new StringContent(body, Encoding.UTF8, mediaType);
                        }

                        var response = await client.SendAsync(request);
                        resposta.CodigoRetorno = response.StatusCode;
                        var content = await response.Content.ReadAsStringAsync();
                        resposta.ExecutadoComSucesso = response.IsSuccessStatusCode;
                        if (response.IsSuccessStatusCode)
                        {
                            resposta.Resultado = content;
                        }
                        else
                        {
                            resposta.InfoResponse = content;
                        }


                    }

                }
                catch (WebException webex)
                {
                    resposta.ClasseException = webex.GetType().ToString();
                    resposta.MensagemException = webex.InnerException != null ? string.Concat(webex.Message, "|", webex.InnerException.Message) : webex.Message;
                    resposta.ExecutadoComSucesso = false;
                }
                catch (Exception ex)
                {
                    resposta.ClasseException = ex.GetType().ToString();
                    resposta.MensagemException = ex.InnerException != null ? string.Concat(ex.Message, "|", ex.InnerException.Message) : ex.Message;
                    resposta.ExecutadoComSucesso = false;
                }
            }
            return resposta;
        }
        #endregion

        #region "Operacoes Deserializacao"
        private static T DeserializeJsonFromStream<T>(Stream stream)
        {
            try
            {
                if (stream == null || stream.CanRead == false)
                    return default(T);

                using (var sr = new StreamReader(stream))
                using (var jtr = new JsonTextReader(sr))
                {
                    var js = new JsonSerializer();
                    var searchResult = js.Deserialize<T>(jtr);
                    return searchResult;
                }

            }
            catch 
            {
                throw;
  
            }
        }

        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }
        #endregion


        public CRMHelperServerComunication RedefinirCabecalhos(bool headerNoCache = true)
        {
            this._redefinirCabecalhos = true;
            this._headerNoCache = headerNoCache;
            return this;
        }
    }
    public class RespostaServico<T>
    {
        public HttpStatusCode CodigoRetorno { get; set; }
        public T Resultado { get; set; }
        public string ClasseException { get; set; }
        public string MensagemException { get; set; }
        public string InfoResponse { get; set; }
        public bool ExecutadoComSucesso { get; set; }
    }

   
   

   
    
}

