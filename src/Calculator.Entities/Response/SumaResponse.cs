using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Entities.Response
{
    public class SumaResponse
    {
        public double Suma { get; set; }

        public override string ToString()
        {
            return $"{nameof(Suma)}: {Suma}";
        }
    }
}