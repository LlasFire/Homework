// <copyright file="CsvPatternLayout.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Infrastructure
{
    using System.IO;
    using log4net.Core;
    using log4net.Layout;

    /// <summary>
    /// Csv pattern layout for log4net logger.
    /// </summary>
    public class CsvPatternLayout : PatternLayout
    {
        /// <inheritdoc/>
        public override void ActivateOptions()
        {
            this.AddConverter("newfield", typeof(NewFieldConverter));
            this.AddConverter("endrow", typeof(EndRowConverter));
            base.ActivateOptions();
        }

        /// <inheritdoc/>
        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            using var ctw = new CsvTextWriter(writer);
            ctw.WriteQuote();
            base.Format(ctw, loggingEvent);
        }
    }
}
