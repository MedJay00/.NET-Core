using Infestation.Infra.Services.Implementations;
using Infestation.Infra.Services.Interfaces;
using Infestation.Infrastucture.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastucture.Middlewares
{
    public class WriteToConsoleMiddleware
    {
        public RequestDelegate _next { get; }

        InfestationConfiguration _infestationConfiguration { get; set; }

        public WriteToConsoleMiddleware(RequestDelegate next, IOptions<InfestationConfiguration> options)
        {
            _next = next;
            _infestationConfiguration = options.Value;
        }


        public async Task InvokeAsync(HttpContext context, IMessageService messageService)
        {


                string bodyM="Host: " + context.Request.Host + " | " +
                             "Method: " + context.Request.Method + " | " +
                             "Date: " + context.Items["RequestStartedOn"];

                
                messageService.SendMessage(_infestationConfiguration.TestEmail, bodyM);
            
            
            ;
            Console.WriteLine(context.Request.Query["ReturnUrl"]);
            await _next.Invoke(context);
        }
        
    }
}
