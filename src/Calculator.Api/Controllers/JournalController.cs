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
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IJournalService _journalService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="journalService"></param>
        public JournalController(IJournalService journalService)
        {
            _journalService = journalService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> Get()
        {
            return Ok(await Task.FromResult("Journal API Status Ok!"));
        }
        /// <summary>
        /// Servicio de consulta operaciones diarias
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost("Query")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ConsultaDiarioResponse>> ConsultarDiarioAsync([FromBody] ConsultaDiarioRequest r)
        {
            return Ok(await _journalService.CosultarDiario(r));
        }
    }
}