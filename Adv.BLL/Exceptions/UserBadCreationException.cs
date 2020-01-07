using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Adv.BLL.Exceptions
{
    public class UserBadCreationException
        : Exception
    {
        public UserBadCreationException()
        {
        }

        public UserBadCreationException(string message) : base(message)
        {
        }

        public UserBadCreationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserBadCreationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
