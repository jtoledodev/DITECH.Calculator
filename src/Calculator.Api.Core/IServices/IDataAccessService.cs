using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Calculator.Entities.Base;
using Calculator.Entities.Request;
using Calculator.Entities.Response;

namespace Calculator.Api.Core.IServices
{
    public interface IDataAccessService
    {
        Task GuardarRegistroDiario(RegistroDiario r);

        Task<ConsultaDiarioResponse> CosultarDiario(ConsultaDiarioRequest r);
    }
}