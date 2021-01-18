// <copyright file="NewIdeaModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.ClientModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Idea model for creating.
    /// </summary>
    public class NewIdeaModel
    {
        /// <summary>
        /// Gets or sets idea model name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets idea model description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets idea session id.
        /// </summary>
        [Range(1, 1000000)]
        public int SessionId { get; set; }
    }
}
