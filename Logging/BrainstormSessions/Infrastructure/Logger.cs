// <copyright file="Logger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Infrastructure
{
    using System.IO;
    using System.Reflection;
    using log4net;
    using log4net.Config;

    /// <summary>
    /// log4net log handler.
    /// </summary>
    public class Logger
    {
        private static readonly ILog LogValue = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Gets current logger object.
        /// </summary>
        public static ILog Log
        {
            get { return LogValue; }
        }

        /// <summary>
        /// Init method for set up logger.
        /// </summary>
        public static void InitLogger()
        {
            var repository = LogManager.GetRepository(Assembly.GetCallingAssembly());
            var fileInfo = new FileInfo(@"log4net.config");

            XmlConfigurator.Configure(repository, fileInfo);
        }
    }
}
