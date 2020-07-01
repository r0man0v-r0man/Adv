﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Exceptions
{
    public class ImgurException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the ImgurException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ImgurException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ImgurException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public ImgurException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ImgurException()
        {
        }
    }
}
