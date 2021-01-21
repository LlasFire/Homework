// <copyright file="CsvTextWriter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Infrastructure
{
    using System.IO;
    using System.Text;

    /// <summary>
    /// CSV text writer for log4net.
    /// </summary>
    public class CsvTextWriter : TextWriter
    {
        private readonly TextWriter textWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvTextWriter"/> class.
        /// </summary>
        /// <param name="textWriter">Text writer.</param>
        public CsvTextWriter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        /// <inheritdoc/>
        public override Encoding Encoding => this.textWriter.Encoding;

        /// <inheritdoc/>
        public override void Write(char value)
        {
            this.textWriter.Write(value);
            if (value == '"')
            {
                this.textWriter.Write(value);
            }
        }

        /// <summary>
        /// Write quote method.
        /// </summary>
        public void WriteQuote()
        {
            this.textWriter.Write('"');
        }
    }
}
