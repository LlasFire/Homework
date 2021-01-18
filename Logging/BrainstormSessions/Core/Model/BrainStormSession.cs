// <copyright file="BrainStormSession.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Core.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// BrainstormSession model.
    /// </summary>
    public class BrainstormSession
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
        /// Gets the list of ideas.
        /// </summary>
        public List<Idea> Ideas { get; } = new List<Idea>();

        /// <summary>
        /// Method for adding idea in Ideas list.
        /// </summary>
        /// <param name="idea">New model of Idea.</param>
        public void AddIdea(Idea idea)
        {
            this.Ideas.Add(idea);
        }
    }
}
