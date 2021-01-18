// <copyright file="NewSessionModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.ClientModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Session model for set in database.
    /// </summary>
    public class NewSessionModel
    {
        /// <summary>
        /// Gets or sets session name.
        /// </summary>
        [Required]
        public string SessionName { get; set; }
    }
}
