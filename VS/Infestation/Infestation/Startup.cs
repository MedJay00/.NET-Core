using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infestation.Infra.Services.Implementations;
using Infestation.Infra.Services.Interfaces;
using Infestation.Infrastucture.BackgroundServices;
using Infestation.Infrastucture.Configuration;
using Infestation.Infrastucture.Middlewares;
using Infestation.Infrastucture.Services;
using Infestation.Infrastucture.Services.Implementations;
using Infestation.Infrastucture.Services.Interfaces;
using Infestation.Models;
using Infestation.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infestation
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INewsRepository, SqlNewsRepository>();
            services.AddScoped<IHumanRepository, SqlHumanRepository>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddSingleton <IHelper, Helper>();
            services.AddScoped<IExampleRestClient, ExampleRestClient>();
            services.AddScoped<IFileProcessingChannel, FileProcessingChannel>();
            //services.AddScoped<IMessageService<Sms>, SmsService>();

            services.AddMemoryCache();

            services.AddDbContext<InfestationContext>(builder => builder.UseSqlServer(_configuration.GetConnectionString("InfestationDbConnectionNew"))
            .UseLazyLoadingProxies());
            services.AddControllersWithViews();
            services.AddHostedService<LoadFileServicecs>();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<InfestationContext>();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;

                
            });


            //services.AddConfiguration();
            //var config = new InfestationConfiguration();
            //_configuration.Bind("Infestation", config);      //  <--- This
            //services.AddSingleton(config);


            var section = _configuration.GetSection("Infestation");
            services.Configure<InfestationConfiguration>(section);

            services.AddControllersWithViews(configure =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                configure.Filters.Add(new AuthorizeFilter(policy));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.Use(async (context, next) =>
            {
                context.Items.Add("RequestStartedOn", DateTime.UtcNow);
                await next();
            });

            app.UseStaticFiles();

            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWhen(context => context.Request.Path.ToString().Equals("/Human/Create") && context.Request.Method == "POST",
                builder => { builder.UseWriteToConsole(); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Human}/{action=Index}/{id?}");
            });
        }
    }
}
