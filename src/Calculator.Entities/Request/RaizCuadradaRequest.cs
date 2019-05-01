using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Entities.Base;

namespace Calculator.Entities.Request
{
    public class RaizCuadradaRequest : Base.Request
    {
        public double Numero { get; set; }

        public override string ToString()
        {
            return $"{Numero}^(1/2)";
        }
    }
}