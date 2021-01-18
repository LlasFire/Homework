// <copyright file="IBrainstormSessionRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BrainstormSessions.Core.Model;

    /// <summary>
    /// Repository for BrainstormSession models.
    /// </summary>
    public interface IBrainstormSessionRepository
    {
        /// <summary>
        /// Get session by id.
        /// </summary>
        /// <param name="id">Id for search.</param>
        /// <returns>BrainstormSession model.</returns>
        Task<BrainstormSession> GetByIdAsync(int id);

        /// <summary>
        /// Get list all of BrainstormSession models.
        /// </summary>
        /// <returns>List all of BrainstormSession models.</returns>
        Task<List<BrainstormSession>> ListAsync();

        /// <summary>
        /// Asynchronus adding for new BrainstormSession model.
        /// </summary>
        /// <param name="session">Model for adding to database.</param>
        /// <returns>Nothing.</returns>
        Task AddAsync(BrainstormSession session);

        /// <summary>
        /// Asynchronus updating model in database.
        /// </summary>
        /// <param name="session">Model for updating in database.</param>
        /// <returns>Nothing.</returns>
        Task UpdateAsync(BrainstormSession session);
    }
}
