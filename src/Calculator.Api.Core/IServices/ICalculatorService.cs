using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Calculator.Entities.Request;
using Calculator.Entities.Response;

namespace Calculator.Api.Core.IServices
{
    public interface ICalculatorService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        Task<SumaResponse> Sumar(SumaRequest r);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        Task<RestaResponse> Restar(RestaRequest r);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        Task<MultiplicacionResponse> Multiplicar(MultiplicacionRequest r);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        Task<DivisionResponse> Dividir(DivisionRequest r);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        Task<RaizCuadradaResponse> CalcularRaizCuadrada(RaizCuadradaRequest r);
    }
}