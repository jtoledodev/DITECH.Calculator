using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Entities.Base
{
    public class RegistroDiario
    {
        public int Id { get; set; }

        public string IdSeguimiento { get; set; }

        public string Operacion { get; set; }

        public string Calculo { get; set; }

        public DateTime FechaHora { get; set; }

        public override string ToString()
        {
            return $"{nameof(IdSeguimiento)}:{IdSeguimiento}|{nameof(Operacion)}:{Operacion}|{nameof(Calculo)}:{Calculo}|{nameof(FechaHora)}:{FechaHora:d}";
        }
    }
}