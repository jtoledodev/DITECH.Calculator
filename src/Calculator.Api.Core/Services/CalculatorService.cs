using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Api.Core.IServices;
using Calculator.Entities.Base;
using Calculator.Entities.Request;
using Calculator.Entities.Response;

namespace Calculator.Api.Core.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IJournalService _journalService;

        public CalculatorService(IJournalService journalService)
        {
            _journalService = journalService;
        }

        public async Task<SumaResponse> Sumar(SumaRequest r)
        {
            var result = await Task.Run(() => r.Sumandos.Sum());

            await GuardarDiario(r, result.ToString());

            return new SumaResponse {Suma = result};
        }

        public async Task<RestaResponse> Restar(RestaRequest r)
        {
            var result = await Task.Run(() => r.Minuendo - r.Sustraendo);

            await GuardarDiario(r, result.ToString());

            return new RestaResponse { Diferencia = result };
        }

        public async Task<MultiplicacionResponse> Multiplicar(MultiplicacionRequest r)
        {
            throw new NotImplementedException();
        }

        public async Task<DivisionResponse> Dividir(DivisionRequest r)
        {
            var result = await Task.Run(() => new KeyValuePair<double, double>(r.Dividendo / r.Divisor, r.Dividendo % r.Divisor));

            await GuardarDiario(r, $"{result.Key},{result.Value}");

            return new DivisionResponse { Cociente = result.Key, Resto = result.Value };
        }

        public async Task<RaizCuadradaResponse> CalcularRaizCuadrada(RaizCuadradaRequest r)
        {
            var result = await Task.Run(() => Math.Sqrt(r.Numero));

            await GuardarDiario(r, result.ToString());

            return new RaizCuadradaResponse {Cuadrado = result};
        }

        private async Task GuardarDiario(Request r, string result)
        {
            if (!string.IsNullOrEmpty(r.IdSeguimiento))
                await _journalService.GuardarRegistroDiario(r.ToRegistroDiario(result));
        }
    }
}