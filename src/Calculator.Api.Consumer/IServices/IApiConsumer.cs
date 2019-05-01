using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Calculator.Entities.Base;
using Calculator.Entities.Request;
using Calculator.Entities.Response;

namespace Calculator.Api.Consumer.IServices
{
    public interface IApiConsumerService
    {
        Task<SumaResponse> Sumar(SumaRequest r);

        Task<RestaResponse> Restar(RestaRequest r);

        Task<MultiplicacionResponse> Multiplicar(MultiplicacionRequest r);

        Task<DivisionResponse> Dividir(DivisionRequest r);

        Task<RaizCuadradaResponse> CalcularRaizCuadrada(RaizCuadradaRequest r);

        Task GuardarRegistroDiario(RegistroDiario r);

        Task<ConsultaDiarioResponse> CosultarDiario(ConsultaDiarioRequest r);
    }
}