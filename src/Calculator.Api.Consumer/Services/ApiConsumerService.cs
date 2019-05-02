using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Calculator.Api.Consumer.IServices;
using Calculator.Entities.Base;
using Calculator.Entities.Request;
using Calculator.Entities.Response;
using Newtonsoft.Json;
using RestSharp;

namespace Calculator.Api.Consumer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiConsumerService : IApiConsumerService
    {
        private readonly string _apiUrl;
        private const string CalculatorApiResource = "calculator";
        private const string JournalApiResource = "journal";
        private const string IdHeader = "X-Evi-Tracking-Id";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiUrl"></param>
        public ApiConsumerService(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        /// <summary>
        /// Implementación de llamado al servicio de suma de la calculadora 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public async Task<SumaResponse> Sumar(SumaRequest r)
        {
            var client = new RestClient(_apiUrl);

            var request = new RestRequest($"{CalculatorApiResource}/add", Method.POST, DataFormat.Json);

            if (!string.IsNullOrEmpty(r.IdSeguimiento))
                request.AddHeader(IdHeader, r.IdSeguimiento);

            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(r), ParameterType.RequestBody);

            return await client.PostAsync<SumaResponse>(request);
        }
        /// <summary>
        /// Implementación de llamado al servicio de resta de la calculadora 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public async Task<RestaResponse> Restar(RestaRequest r)
        {
            var client = new RestClient(_apiUrl);

            var request = new RestRequest($"{CalculatorApiResource}/sub", Method.POST, DataFormat.Json);

            if (!string.IsNullOrEmpty(r.IdSeguimiento))
                request.AddHeader(IdHeader, r.IdSeguimiento);

            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(r), ParameterType.RequestBody);

            return await client.PostAsync<RestaResponse>(request);
        }
        /// <summary>
        /// Implementación de llamado al servicio de multiplicar de la calculadora 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public async Task<MultiplicacionResponse> Multiplicar(MultiplicacionRequest r)
        {
            var client = new RestClient(_apiUrl);

            var request = new RestRequest($"{CalculatorApiResource}/Mult", Method.POST, DataFormat.Json);

            if (!string.IsNullOrEmpty(r.IdSeguimiento))
                request.AddHeader(IdHeader, r.IdSeguimiento);

            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(r), ParameterType.RequestBody);

            return await client.PostAsync<MultiplicacionResponse>(request);
        }
        /// <summary>
        /// Implementación de llamado al servicio de dividir de la calculadora 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public async Task<DivisionResponse> Dividir(DivisionRequest r)
        {
            var client = new RestClient(_apiUrl);

            var request = new RestRequest($"{CalculatorApiResource}/Div", Method.POST, DataFormat.Json);

            if (!string.IsNullOrEmpty(r.IdSeguimiento))
                request.AddHeader(IdHeader, r.IdSeguimiento);

            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(r), ParameterType.RequestBody);

            return await client.PostAsync<DivisionResponse>(request);
        }
        /// <summary>
        /// Implementación de llamado al servicio de raiz cuadrada de la calculadora 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public async Task<RaizCuadradaResponse> CalcularRaizCuadrada(RaizCuadradaRequest r)
        {
            var client = new RestClient(_apiUrl);

            var request = new RestRequest($"{CalculatorApiResource}/Sqrt", Method.POST, DataFormat.Json);

            if (!string.IsNullOrEmpty(r.IdSeguimiento))
                request.AddHeader(IdHeader, r.IdSeguimiento);

            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(r), ParameterType.RequestBody);

            return await client.PostAsync<RaizCuadradaResponse>(request);
        }
        /// <summary>
        /// Implementación de llamado al servicio de consulta de operaciones diarias
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public async Task<ConsultaDiarioResponse> CosultarDiario(ConsultaDiarioRequest r)
        {
            var client = new RestClient(_apiUrl);

            var request = new RestRequest($"{JournalApiResource}/query", Method.POST, DataFormat.Json);

            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(r), ParameterType.RequestBody);

            return await client.PostAsync<ConsultaDiarioResponse>(request);
        }
    }
}