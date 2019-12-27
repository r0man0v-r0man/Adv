using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Adv.BLL.Exceptions
{
    public class FlatBadCreateException : Exception
    {
        public FlatBadCreateException()
        {
        }

        public FlatBadCreateException(string message) : base(message)
        {
        }

        public FlatBadCreateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FlatBadCreateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
