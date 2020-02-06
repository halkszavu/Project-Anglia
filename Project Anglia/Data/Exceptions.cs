using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Anglia.Data
{
    class NoSuitorException : Exception
    {
        public NoSuitorException() : base() { }

        public NoSuitorException(string message) : base(message) { }

        public NoSuitorException(string message, Exception exception) : base(message, exception) { }
    }
}
