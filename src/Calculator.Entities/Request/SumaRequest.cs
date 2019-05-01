using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Entities.Request
{
    public class SumaRequest : Base.Request
    {
        public List<double> Sumandos { get; set; }

        public SumaRequest()
        {
            Sumandos = new List<double>();
        }

        public override string ToString()
        {
            return string.Join(" + ", Sumandos);
        }
    }
}