// <copyright file="IdeaDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.ClientModels
{
    using System;

    /// <summary>
    /// Idea data transfer object.
    /// </summary>
    public class IdeaDto
    {
        /// <summary>
        /// Gets or sets unique identificator.
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
        /// Gets or sets created date.
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }
    }
}
