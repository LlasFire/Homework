// <copyright file="AppDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Infrastructure
{
    using BrainstormSessions.Core.Model;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Application Db context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="dbContextOptions">Options for context.</param>
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        /// <summary>
        /// Gets or sets db entity presents BrainstormSession table in SQL.
        /// </summary>
        public DbSet<BrainstormSession> BrainstormSessions { get; set; }
    }
}
