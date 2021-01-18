// <copyright file="StormSessionViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.ViewModels
{
    using System;

    /// <summary>
    /// View model of StormSession.
    /// </summary>
    public class StormSessionViewModel
    {
        /// <summary>
        /// Gets or sets unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets session name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets date of creation.
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// Gets or sets tne count ideas in this session.
        /// </summary>
        public int IdeaCount { get; set; }
    }
}
