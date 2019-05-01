using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Entities.Base
{
    public class HttpError
    {
        public string ErrorCode { get; set; }

        public int ErrorStatus { get; set; }

        public string ErrorMessage { get; set; }
    }
}