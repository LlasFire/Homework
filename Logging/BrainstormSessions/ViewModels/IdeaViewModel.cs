// <copyright file="IdeaViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.ViewModels
{
    using System;

    /// <summary>
    /// View model of Idea.
    /// </summary>
    public class IdeaViewModel
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
