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

namespace Calculator.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        private const string IdHeader = "X-Evi-Tracking-Id";

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> Get()
        {
            return Ok(await Task.FromResult("Calculator API Status Ok!"));
        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SumaResponse>> SumarAsync([FromBody] SumaRequest r)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            r.IdSeguimiento = Request.Headers[IdHeader] == StringValues.Empty ? string.Empty : Request.Headers[IdHeader].ToString();

            return Ok(await _calculatorService.Sumar(r));
        }

        [HttpPost("Sub")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RestaResponse>> RestarAsync([FromBody] RestaRequest r)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            r.IdSeguimiento = Request.Headers[IdHeader] == StringValues.Empty ? string.Empty : Request.Headers[IdHeader].ToString();

            return Ok(await _calculatorService.Restar(r));
        }

        [HttpPost("Mult")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MultiplicacionResponse>> MultiplicarAsync([FromBody] MultiplicacionRequest r)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            r.IdSeguimiento = Request.Headers[IdHeader] == StringValues.Empty ? string.Empty : Request.Headers[IdHeader].ToString();

            return Ok(await _calculatorService.Multiplicar(r));
        }

        [HttpPost("Div")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DivisionResponse>> MultiplicarAsync([FromBody] DivisionRequest r)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            r.IdSeguimiento = Request.Headers[IdHeader] == StringValues.Empty ? string.Empty : Request.Headers[IdHeader].ToString();

            return Ok(await _calculatorService.Dividir(r));
        }

        [HttpPost("Sqrt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RaizCuadradaResponse>> CalcularRaizCuadradaAsync([FromBody] RaizCuadradaRequest r)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            r.IdSeguimiento = Request.Headers[IdHeader] == StringValues.Empty ? string.Empty : Request.Headers[IdHeader].ToString();

            return Ok(await _calculatorService.CalcularRaizCuadrada(r));
        }
    }
}