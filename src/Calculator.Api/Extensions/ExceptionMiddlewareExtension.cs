using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Calculator.Entities.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Calculator.Api.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new HttpError()
                        {
                            ErrorCode = HttpStatusCode.InternalServerError.ToString(),
                            ErrorStatus = context.Response.StatusCode,
                            ErrorMessage = $"Ocurrió un error en la aplicación. Exception: {contextFeature.Error}"
                        }.ToString());
                    }
                });
            });
        }
    }
}