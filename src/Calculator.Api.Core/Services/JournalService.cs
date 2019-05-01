using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Calculator.Api.Core.IServices;
using Calculator.Entities.Base;
using Calculator.Entities.Request;
using Calculator.Entities.Response;

namespace Calculator.Api.Core.Services
{
    public class JournalService : IJournalService
    {
        private readonly IDataAccessService _dataAccessService;

        public JournalService(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        public async Task GuardarRegistroDiario(RegistroDiario r)
        {
            await _dataAccessService.GuardarRegistroDiario(r);
        }

        public async Task<ConsultaDiarioResponse> CosultarDiario(ConsultaDiarioRequest r)
        {
            return await _dataAccessService.CosultarDiario(r);
        }
    }
}