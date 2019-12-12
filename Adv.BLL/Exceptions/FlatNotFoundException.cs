using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Adv.BLL.Exceptions
{
    public class FlatNotFoundException : Exception
    {
        public FlatNotFoundException()
        {
        }

        public FlatNotFoundException(string message) : base(message)
        {
        }

        public FlatNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FlatNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
