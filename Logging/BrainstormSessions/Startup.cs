// <copyright file="Startup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using BrainstormSessions.Core.Interfaces;
    using BrainstormSessions.Core.Model;
    using BrainstormSessions.Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// The startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Method for configuring services.
        /// </summary>
        /// <param name="services">Collection services for configuring.</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(
                optionsBuilder => optionsBuilder.UseInMemoryDatabase("InMemoryDb"));

            services.AddControllersWithViews();

            services.AddScoped<IBrainstormSessionRepository,
                EFStormSessionRepository>();
        }

        /// <summary>
        /// Method for configuring application.
        /// </summary>
        /// <param name="app">ApplicationBuilder interface.</param>
        /// <param name="env">WebHostEnvironment interface.</param>
        /// <param name="serviceProvider">ServiceProvider interface.</param>
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            Logger.InitLogger();
            if (env.IsDevelopment())
            {
                var repository = serviceProvider.GetRequiredService<IBrainstormSessionRepository>();

                InitializeDatabaseAsync(repository).Wait();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// Method for initialize database.
        /// </summary>
        /// <param name="repo">Interface of repository.</param>
        /// <returns>Nothing.</returns>
        public static async Task InitializeDatabaseAsync(IBrainstormSessionRepository repo)
        {
            if (repo is null)
            {
                throw new ArgumentNullException(nameof(repo));
            }

            var sessionList = await repo.ListAsync();
            if (!sessionList.Any())
            {
                await repo.AddAsync(GetTestSession());
            }
        }

        /// <summary>
        /// Method that creates initial session for test.
        /// </summary>
        /// <returns>Initial test datas.</returns>
        public static BrainstormSession GetTestSession()
        {
            var session = new BrainstormSession()
            {
                Name = "Test Session 1",
                DateCreated = new DateTime(2016, 8, 1),
            };

            var idea = new Idea()
            {
                DateCreated = new DateTime(2016, 8, 1),
                Description = "Totally awesome idea",
                Name = "Awesome idea",
            };

            session.AddIdea(idea);

            return session;
        }
    }
}
