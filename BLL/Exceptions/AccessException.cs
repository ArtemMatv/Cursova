using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Exceptions
{
    public class AccessException : Exception
    {
        public AccessException()
        { }

        public AccessException(string message)
            : base(message)
        { }

        public AccessException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
