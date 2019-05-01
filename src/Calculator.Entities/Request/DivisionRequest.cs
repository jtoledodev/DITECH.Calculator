using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Entities.Base;

namespace Calculator.Entities.Request
{
    public class DivisionRequest : Base.Request
    {
        public double Dividendo { get; set; }

        public double Divisor { get; set; }

        public override string ToString()
        {
            return $"{Dividendo} / {Divisor}";
        }
    }
}