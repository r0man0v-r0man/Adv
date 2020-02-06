using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Adv.DAL.Exceptions
{
    public sealed class FlatNotFoundException : Exception
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
