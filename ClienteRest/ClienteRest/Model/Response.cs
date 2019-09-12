using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteRest.Model
{
    public class Response
    {
        public bool isSuccess { get; set; }
        public String Message { get; set; }
        public Object Result { get; set; }
    }
}
