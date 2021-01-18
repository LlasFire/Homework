// <copyright file="Idea.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Core.Model
{
    using System;

    /// <summary>
    /// The model of idea.
    /// </summary>
    public class Idea
    {
        /// <summary>
        /// Gets or sets unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets idea name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets idea description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date of creation.
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }
    }
}
