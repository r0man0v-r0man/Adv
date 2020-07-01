using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Exceptions
{
    public class NotFoundAdvertException : Exception
    {
        public NotFoundAdvertException(string message) : base(message)
        {
        }

        public NotFoundAdvertException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotFoundAdvertException() : base("Такого объявления мы не нашли")
        {
        }
    }
}
