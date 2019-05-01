using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Api.Core.IServices;
using Calculator.Entities.Request;
using Calculator.Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Serilog;

namespace Calculator.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        private const string IdHeader = "X-Evi-Tracking-Id";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="calculatorService"></param>
        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> Get()
        {
            return Ok(await Task.FromResult("Calculator API Status Ok!"));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SumaResponse>> SumarAsync([FromBody] SumaRequest r)
        {
            r.IdSeguimiento = Request.Headers[IdHeader] == StringValues.Empty ? string.Empty : Request.Headers[IdHeader].ToString();

            var response = await _calculatorService.Sumar(r);

            Log.Information(r.ToRegistroDiario(response.Suma.ToString()).ToString());

            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost("Sub")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RestaResponse>> RestarAsync([FromBody] RestaRequest r)
        {
            r.IdSeguimiento = Request.Headers[IdHeader] == StringValues.Empty ? string.Empty : Request.Headers[IdHeader].ToString();

            var response = await _calculatorService.Restar(r);

            Log.Information(r.ToRegistroDiario(response.Diferencia.ToString()).ToString());

            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost("Mult")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MultiplicacionResponse>> MultiplicarAsync([FromBody] MultiplicacionRequest r)
        {
            r.IdSeguimiento = Request.Headers[IdHeader] == StringValues.Empty ? string.Empty : Request.Headers[IdHeader].ToString();

            var response = await _calculatorService.Multiplicar(r);

            Log.Information(r.ToRegistroDiario(response.Producto.ToString()).ToString());

            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost("Div")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DivisionResponse>> MultiplicarAsync([FromBody] DivisionRequest r)
        {
            r.IdSeguimiento = Request.Headers[IdHeader] == StringValues.Empty ? string.Empty : Request.Headers[IdHeader].ToString();

            var response = await _calculatorService.Dividir(r);

            Log.Information(r.ToRegistroDiario($"{response.Cociente},{response.Resto}").ToString());

            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost("Sqrt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RaizCuadradaResponse>> CalcularRaizCuadradaAsync([FromBody] RaizCuadradaRequest r)
        {
            r.IdSeguimiento = Request.Headers[IdHeader] == StringValues.Empty ? string.Empty : Request.Headers[IdHeader].ToString();

            var response = await _calculatorService.CalcularRaizCuadrada(r);

            Log.Information(r.ToRegistroDiario(response.Cuadrado.ToString()).ToString());

            return Ok(response);
        }
    }
}