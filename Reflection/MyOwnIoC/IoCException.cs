// <copyright file="IoCException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyOwnIoC
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Custom exception for my Io container.
    /// </summary>
    [Serializable]
    public class IoCException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IoCException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public IoCException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoCException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public IoCException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoCException"/> class.
        /// </summary>
        public IoCException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoCException"/> class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected IoCException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
