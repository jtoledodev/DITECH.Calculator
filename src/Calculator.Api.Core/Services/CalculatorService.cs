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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="journalService"></param>
        public CalculatorService(IJournalService journalService)
        {
            _journalService = journalService;
        }
        /// <summary>
        /// Metodo que realiza suma 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public async Task<SumaResponse> Sumar(SumaRequest r)
        {
            var result = await Task.Run(() => r.Sumandos.Sum());

            await GuardarDiario(r, result.ToString());

            return new SumaResponse {Suma = result};
        }
        /// <summary>
        /// Metodo que realiza la resta 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public async Task<RestaResponse> Restar(RestaRequest r)
        {
            var result = await Task.Run(() => r.Minuendo - r.Sustraendo);

            await GuardarDiario(r, result.ToString());

            return new RestaResponse { Diferencia = result };
        }
        /// <summary>
        /// Metodo que realiza la Multiplicación 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public async Task<MultiplicacionResponse> Multiplicar(MultiplicacionRequest r)
        {
            var result = await Task.Run(() => r.Factores.Aggregate((x, y) => x * y));

            await GuardarDiario(r, result.ToString());

            return new MultiplicacionResponse { Producto = result };
        }
        /// <summary>
        /// Metodo que realiza la División 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public async Task<DivisionResponse> Dividir(DivisionRequest r)
        {
            var result = await Task.Run(() => new KeyValuePair<double, double>(r.Dividendo / r.Divisor, r.Dividendo % r.Divisor));

            await GuardarDiario(r, $"{result.Key},{result.Value}");

            return new DivisionResponse { Cociente = result.Key, Resto = result.Value };
        }
        /// <summary>
        /// Metodo que calcula la raiz cuadrada
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public async Task<RaizCuadradaResponse> CalcularRaizCuadrada(RaizCuadradaRequest r)
        {
            var result = await Task.Run(() => Math.Sqrt(r.Numero));

            await GuardarDiario(r, result.ToString());

            return new RaizCuadradaResponse {Cuadrado = result};
        }
        /// <summary>
        /// Metodo para guardar el diario de las operaciones
        /// </summary>
        /// <param name="r"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task GuardarDiario(Request r, string result)
        {
            if (!string.IsNullOrEmpty(r.IdSeguimiento))
                await _journalService.GuardarRegistroDiario(r.ToRegistroDiario(result));
        }
    }
}