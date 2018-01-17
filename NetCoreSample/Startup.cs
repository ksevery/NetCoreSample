﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NetCoreSample.Data;
using NetCoreSample.Clients;
using System.Net.Http;
using CommonLibrary;

namespace NetCoreSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<MovieContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MovieContext")));

            services.AddTransient<HttpClient, HttpClient>();
            services.AddTransient<IMoviesApiClient, MoviesApiClient>(provider => 
            {
                return new MoviesApiClient("http://localhost:3732", provider.GetService<HttpClient>());
            });

            services.AddSingleton<IDependentClass, DependentClass>();
            services.AddSingleton<IDependencyClass, DependencyClass>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Movies/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Movies}/{action=Index}/{id?}");
            });
        }
    }
}