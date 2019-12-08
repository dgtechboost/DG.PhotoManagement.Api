﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.PhotoManagement.Business.Albums.GetList;
using DG.PhotoManagement.Contracts;
using DG.PhotoManagement.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Refit;

namespace DG.PhotoManagement.Api
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
            //database
            var defaultConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PhotoManagementDbContext>(options => options.UseSqlServer(defaultConnectionString));


            services.AddScoped<IGetAlbumList, GetAlbumList>();

            services.AddRefitClient<IJSONPlaceholderService>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://jsonplaceholder.typicode.com"));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

                //.AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
