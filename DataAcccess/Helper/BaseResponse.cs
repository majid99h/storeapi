using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helper
{
    public class BaseResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public decimal Total { get; set; }
        public string Type { get; set; }

    }
}
