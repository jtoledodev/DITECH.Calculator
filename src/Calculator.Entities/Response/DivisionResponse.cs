using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Entities.Response
{
    public class DivisionResponse
    {
        public double Cociente { get; set; }

        public double Resto { get; set; }

        public override string ToString()
        {
            return $"{nameof(Cociente)}: {Cociente} | {nameof(Resto)}: {Resto}";
        }
    }
}