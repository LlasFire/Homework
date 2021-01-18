// <copyright file="IdeasController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BrainstormSessions.ClientModels;
    using BrainstormSessions.Core.Interfaces;
    using BrainstormSessions.Core.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for Ideas endpoints.
    /// </summary>
    public class IdeasController : ControllerBase
    {
        private readonly IBrainstormSessionRepository sessionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdeasController"/> class.
        /// </summary>
        /// <param name="sessionRepository">Session repository interface.</param>
        public IdeasController(IBrainstormSessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        /// <summary>
        /// Endpoint for gettingsession idea.
        /// </summary>
        /// <param name="sessionId">Session id.</param>
        /// <returns>Idea model.</returns>
        [HttpGet("forsession/{sessionId}")]
        public async Task<IActionResult> ForSession(int sessionId)
        {
            var session = await this.sessionRepository.GetByIdAsync(sessionId);
            if (session == null)
            {
                return this.NotFound(sessionId);
            }

            var result = session.Ideas.Select(idea => new IdeaDto()
            {
                Id = idea.Id,
                Name = idea.Name,
                Description = idea.Description,
                DateCreated = idea.DateCreated,
            }).ToList();

            return this.Ok(result);
        }

        /// <summary>
        /// Create new session model.
        /// </summary>
        /// <param name="model">Model for filling database entity.</param>
        /// <returns>Created entity.</returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]NewIdeaModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var session = await this.sessionRepository.GetByIdAsync(model.SessionId);
            if (session == null)
            {
                return this.NotFound(model.SessionId);
            }

            var idea = new Idea()
            {
                DateCreated = DateTimeOffset.Now,
                Description = model.Description,
                Name = model.Name,
            };
            session.AddIdea(idea);

            await this.sessionRepository.UpdateAsync(session);

            return this.Ok(session);
        }

        /// <summary>
        /// Return list models for session.
        /// </summary>
        /// <param name="sessionId">Session Id.</param>
        /// <returns>List of results.</returns>
        [HttpGet("forsessionactionresult/{sessionId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<IdeaDto>>> ForSessionActionResult(int sessionId)
        {
            var session = await this.sessionRepository.GetByIdAsync(sessionId);

            if (session == null)
            {
                return this.NotFound(sessionId);
            }

            var result = session.Ideas.Select(idea => new IdeaDto()
            {
                Id = idea.Id,
                Name = idea.Name,
                Description = idea.Description,
                DateCreated = idea.DateCreated,
            }).ToList();

            return result;
        }

        /// <summary>
        /// Create endpoint.
        /// </summary>
        /// <param name="model">Model for creating.</param>
        /// <returns>Create at action link.</returns>
        [HttpPost("createactionresult")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BrainstormSession>> CreateActionResult([FromBody]NewIdeaModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var session = await this.sessionRepository.GetByIdAsync(model.SessionId);

            if (session == null)
            {
                return this.NotFound(model.SessionId);
            }

            var idea = new Idea()
            {
                DateCreated = DateTimeOffset.Now,
                Description = model.Description,
                Name = model.Name,
            };
            session.AddIdea(idea);

            await this.sessionRepository.UpdateAsync(session);

            return this.CreatedAtAction(nameof(this.CreateActionResult), new { id = session.Id }, session);
        }
    }
}
