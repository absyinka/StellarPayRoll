using System;

namespace StellarPayRoll.Core.Exceptions
{
    public class BadGatewayException : Exception
    {
        public BadGatewayException()
        { 
        }

        public BadGatewayException(string message) : base(message)
        { 
        }

        public BadGatewayException(string message, Exception innerException) : base(message, innerException)
        { 
        }
    }
}
