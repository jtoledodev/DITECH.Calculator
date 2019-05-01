using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Calculator.Api.Consumer.IServices;
using Calculator.Entities.Base;
using Calculator.Entities.Request;
using Calculator.Entities.Response;

namespace Calculator.Api.Consumer.Services
{
    public class ApiConsumerService : IApiConsumerService
    {
        private readonly string _apiUrl;
        private readonly string _calculatorApiUrl;
        private readonly string _journalApiUrl;

        public ApiConsumerService(string apiUrl)
        {
            _apiUrl = apiUrl;
            _calculatorApiUrl = $"{_apiUrl}/calculator";
            _journalApiUrl = $"{_apiUrl}/journal";
        }

        public async Task<SumaResponse> Sumar(SumaRequest r)
        {
            throw new NotImplementedException();
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

        public async Task GuardarRegistroDiario(RegistroDiario r)
        {
            throw new NotImplementedException();
        }

        public async Task<ConsultaDiarioResponse> CosultarDiario(ConsultaDiarioRequest r)
        {
            throw new NotImplementedException();
        }
    }
}