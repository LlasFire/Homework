// <copyright file="SessionController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Controllers
{
    using System.Threading.Tasks;
    using BrainstormSessions.Core.Interfaces;
    using BrainstormSessions.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for actions with session.
    /// </summary>
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository sessionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionController"/> class.
        /// </summary>
        /// <param name="sessionRepository">Interface of session repository.</param>
        public SessionController(IBrainstormSessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        /// <summary>
        /// Start action.
        /// </summary>
        /// <param name="id">Nullable id for search.</param>
        /// <returns>Session model.</returns>
        public async Task<IActionResult> Index(int? id)
        {
            if (!id.HasValue)
            {
                return this.RedirectToAction(
                    actionName: nameof(this.Index),
                    controllerName: "Home");
            }

            var session = await this.sessionRepository.GetByIdAsync(id.Value);
            if (session == null)
            {
                return this.Content("Session not found.");
            }

            var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id,
            };

            return this.View(viewModel);
        }
    }
}
