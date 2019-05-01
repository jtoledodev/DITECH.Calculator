using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Entities.Response
{
    public class RaizCuadradaResponse
    {
        public double Cuadrado { get; set; }

        public override string ToString()
        {
            return $"{nameof(Cuadrado)}: {Cuadrado}";
        }
    }
}