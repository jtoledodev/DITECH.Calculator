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
    public class ApiConsumerService : IApiConsumerService
    {
        private readonly string _apiUrl;
        private const string CalculatorApiResource = "calculator";
        private const string JournalApiResource = "journal";
        private const string IdHeader = "X-Evi-Tracking-Id";

        public ApiConsumerService(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        public async Task<SumaResponse> Sumar(SumaRequest r)
        {
            var client = new RestClient(_apiUrl);

            var request = new RestRequest($"{CalculatorApiResource}/add", Method.POST, DataFormat.Json);

            if (!string.IsNullOrEmpty(r.IdSeguimiento))
                request.AddHeader(IdHeader, r.IdSeguimiento);

            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(r), ParameterType.RequestBody);

            return await client.PostAsync<SumaResponse>(request);
        }

        public async Task<RestaResponse> Restar(RestaRequest r)
        {
            throw new NotImplementedException();
        }

        public async Task<MultiplicacionResponse> Multiplicar(MultiplicacionRequest r)
        {
            throw new NotImplementedException();
        }

        public async Task<DivisionResponse> Dividir(DivisionRequest r)
        {
            throw new NotImplementedException();
        }

        public async Task<RaizCuadradaResponse> CalcularRaizCuadrada(RaizCuadradaRequest r)
        {
            throw new NotImplementedException();
        }

        public async Task<ConsultaDiarioResponse> CosultarDiario(ConsultaDiarioRequest r)
        {
            var client = new RestClient(_apiUrl);

            var request = new RestRequest($"{JournalApiResource}/query", Method.POST, DataFormat.Json);

            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(r), ParameterType.RequestBody);

            return await client.PostAsync<ConsultaDiarioResponse>(request);
        }
    }
}