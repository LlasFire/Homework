// <copyright file="EFStormSessionRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BrainstormSessions.Core.Interfaces;
    using BrainstormSessions.Core.Model;
    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc/>
    public class EFStormSessionRepository : IBrainstormSessionRepository
    {
        private readonly AppDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EFStormSessionRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Application database context.</param>
        public EFStormSessionRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public Task<BrainstormSession> GetByIdAsync(int id)
        {
            return this.dbContext.BrainstormSessions
                .Include(s => s.Ideas)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <inheritdoc/>
        public Task<List<BrainstormSession>> ListAsync()
        {
            return this.dbContext.BrainstormSessions
                .Include(s => s.Ideas)
                .OrderByDescending(s => s.DateCreated)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public Task AddAsync(BrainstormSession session)
        {
            this.dbContext.BrainstormSessions.Add(session);
            return this.dbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public Task UpdateAsync(BrainstormSession session)
        {
            this.dbContext.Entry(session).State = EntityState.Modified;
            return this.dbContext.SaveChangesAsync();
        }
    }
}
