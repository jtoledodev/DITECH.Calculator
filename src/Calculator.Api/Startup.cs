﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Calculator.Api.Core.IServices;
using Calculator.Api.Core.Services;
using Calculator.Api.Extensions;
using Calculator.Entities.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Calculator.Api
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
            services.AddTransient<IDataAccessService, DataAccessService>();
            services.AddTransient<IJournalService, JournalService>();
            services.AddTransient<ICalculatorService, CalculatorService>();

            services.Configure<ApiBehaviorOptions>(a => 
            {
                a.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new HttpError
                    {
                        ErrorCode = HttpStatusCode.BadRequest.ToString(),
                        ErrorStatus = (int)HttpStatusCode.BadRequest,
                        ErrorMessage = $"The inputs supplied to the API are invalid. Details: {JsonConvert.SerializeObject(context.ModelState)}"
                    };

                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Manejo personalizado de excepciones.
            app.ConfigureExceptionHandler();

            app.UseMvc();
        }
    }
}