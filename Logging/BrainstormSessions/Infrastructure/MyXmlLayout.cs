// <copyright file="MyXmlLayout.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Infrastructure
{
    using System;
    using System.Xml;
    using log4net.Core;
    using log4net.Layout;

    /// <inheritdoc/>
    public class MyXmlLayout : XmlLayoutBase
    {
        /// <inheritdoc/>
        protected override void FormatXml(XmlWriter writer, LoggingEvent loggingEvent)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (loggingEvent is null)
            {
                throw new ArgumentNullException(nameof(loggingEvent));
            }

            writer.WriteStartElement("LogEntry");

            writer.WriteStartElement("Level");
            writer.WriteString(loggingEvent.Level.DisplayName);
            writer.WriteEndElement();

            writer.WriteStartElement("Time");
            writer.WriteString(loggingEvent.TimeStamp.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Message");
            writer.WriteString(loggingEvent.RenderedMessage);
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}
