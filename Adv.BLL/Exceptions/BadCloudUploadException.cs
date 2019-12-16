using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Adv.BLL.Exceptions
{
    public class BadCloudUploadException : Exception
    {
        public BadCloudUploadException()
        {
        }

        public BadCloudUploadException(string message) : base(message)
        {
        }

        public BadCloudUploadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadCloudUploadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
