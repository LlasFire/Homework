// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using BrainstormSessions.ClientModels;
    using BrainstormSessions.Core.Interfaces;
    using BrainstormSessions.Core.Model;
    using BrainstormSessions.Infrastructure;
    using BrainstormSessions.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IBrainstormSessionRepository sessionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="sessionRepository">Interface of repository.</param>
        public HomeController(IBrainstormSessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        /// <summary>
        /// Start action.
        /// </summary>
        /// <returns>All initial session models.</returns>
        public async Task<IActionResult> Index()
        {
            var sessionList = await this.sessionRepository.ListAsync();

            var model = sessionList.Select(session => new StormSessionViewModel()
            {
                Id = session.Id,
                DateCreated = session.DateCreated,
                Name = session.Name,
                IdeaCount = session.Ideas.Count,
            });

            Logger.Log.Info(model);
            return this.View(model);
        }

        /// <summary>
        /// Start action.
        /// </summary>
        /// <param name="model">New session model.</param>
        /// <returns>All initial session models.</returns>
        [HttpPost]
        public async Task<IActionResult> Index(NewSessionModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (!this.ModelState.IsValid)
            {
                Logger.Log.Warn($"Modelstate in method {nameof(this.Index)} has {this.ModelState.ErrorCount} errors");
                return this.BadRequest(this.ModelState);
            }
            else
            {
                await this.sessionRepository.AddAsync(new BrainstormSession()
                {
                    DateCreated = DateTimeOffset.Now,
                    Name = model.SessionName,
                });
            }

            return this.RedirectToAction(actionName: nameof(this.Index));
        }
    }
}
