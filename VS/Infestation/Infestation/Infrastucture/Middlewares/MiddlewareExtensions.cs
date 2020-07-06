using Infestation.Infra.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account.Usage.Record;

namespace Infestation.Infrastucture.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseWriteToConsole(this IApplicationBuilder app)
        {
            return app.UseMiddleware<WriteToConsoleMiddleware>();
        }
    }
}
