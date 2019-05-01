using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Entities.Base
{
    public class RegistroDiario
    {
        public string IdSeguimiento { get; set; }

        public string Operacion { get; set; }

        public string Calculo { get; set; }

        public DateTime FechaHora { get; set; }
    }
}