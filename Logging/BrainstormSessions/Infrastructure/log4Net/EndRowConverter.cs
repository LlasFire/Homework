// <copyright file="EndRowConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Infrastructure
{
    using System.IO;
    using log4net.Util;

    /// <summary>
    /// Converter for end rows in CSV log file.
    /// </summary>
    public class EndRowConverter : PatternConverter
    {
        /// <inheritdoc/>
        protected override void Convert(TextWriter writer, object state)
        {
            var ctw = writer as CsvTextWriter;

            ctw?.WriteQuote();

            writer.WriteLine();
        }
    }
}
