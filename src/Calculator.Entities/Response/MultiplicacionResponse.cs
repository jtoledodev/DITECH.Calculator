using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Entities.Response
{
    public class MultiplicacionResponse
    {
        public double Producto { get; set; }

        public override string ToString()
        {
            return $"{nameof(Producto)}: {Producto}";
        }
    }
}