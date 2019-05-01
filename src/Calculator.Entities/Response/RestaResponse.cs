using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Entities.Response
{
    public class RestaResponse
    {
        public double Diferencia { get; set; }

        public override string ToString()
        {
            return $"{nameof(Diferencia)}: {Diferencia}";
        }
    }
}