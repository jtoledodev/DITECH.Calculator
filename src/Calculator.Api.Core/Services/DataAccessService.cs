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
    public class DataAccessService : IDataAccessService
    {
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