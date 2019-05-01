using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Entities.Request
{
    public class RestaRequest : Base.Request
    {
        public double Minuendo { get; set; }

        public double Sustraendo { get; set; }

        public override string ToString()
        {
            return $"{Minuendo} - {Sustraendo}";
        }
    }
}