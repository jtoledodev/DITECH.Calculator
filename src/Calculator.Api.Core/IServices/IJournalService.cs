using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Calculator.Entities.Base;
using Calculator.Entities.Request;
using Calculator.Entities.Response;

namespace Calculator.Api.Core.IServices
{
    public interface IJournalService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        Task GuardarRegistroDiario(RegistroDiario r);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        Task<ConsultaDiarioResponse> CosultarDiario(ConsultaDiarioRequest r);
    }
}