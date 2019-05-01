using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Entities.Base;

namespace Calculator.Entities.Request
{
    public class MultiplicacionRequest : Base.Request
    {
        public List<double> Factores { get; set; }

        public MultiplicacionRequest()
        {
            Factores = new List<double>();
        }

        public override string ToString()
        {
            return string.Join(" * ", Factores);
        }
    }
}