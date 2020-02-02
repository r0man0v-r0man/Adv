using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Adv.DAL.Exceptions
{
    public class UserBadPasswordException
            : Exception
    {
        public UserBadPasswordException()
        {
        }

        public UserBadPasswordException(string message) : base(message)
        {
        }

        public UserBadPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserBadPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
