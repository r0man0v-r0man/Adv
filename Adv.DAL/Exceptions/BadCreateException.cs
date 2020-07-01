using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Exceptions
{
    public class BadCreateException : Exception
    {
        public BadCreateException(string message) : base(message)
        {
        }

        public BadCreateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
