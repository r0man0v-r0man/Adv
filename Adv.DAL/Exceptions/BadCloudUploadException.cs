using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Adv.DAL.Exceptions
{
    public sealed class BadCloudUploadException : Exception
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
