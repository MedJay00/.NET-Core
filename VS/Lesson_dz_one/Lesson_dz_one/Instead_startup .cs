using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_dz_one
{
    public class Instead_startup
    {
        private IConfiguration _config { get; }

        public Instead_startup(IConfiguration config) 
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        { 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(_config["Logging:LogLevel:Microsoft.Hosting.Lifetime"]);
                });

            });
        }
    }
}
