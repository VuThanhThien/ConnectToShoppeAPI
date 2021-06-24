using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.Model
{
    public class APIResponse
    {
        public int code { get; set; }
        public string message { get; set; }
        public string data { get; set; }
        public string error { get; set; }
    }
}
