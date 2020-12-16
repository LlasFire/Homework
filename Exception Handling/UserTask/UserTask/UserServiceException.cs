// <copyright file="UserServiceException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserTask
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Custem exception class for User service.
    /// </summary>
    [Serializable]
    public class UserServiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserServiceException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public UserServiceException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserServiceException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public UserServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserServiceException"/> class.
        /// </summary>
        public UserServiceException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserServiceException"/> class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected UserServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
