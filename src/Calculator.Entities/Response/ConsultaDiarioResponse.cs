using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Entities.Base;

namespace Calculator.Entities.Response
{
    public class ConsultaDiarioResponse
    {
        public List<RegistroDiario> Operaciones { get; set; }

        public ConsultaDiarioResponse()
        {
            Operaciones = new List<RegistroDiario>();
        }

        public override string ToString()
        {
            return string.Join("\r\n", Operaciones);
        }
    }
}