using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infestation.Infra.Services.Implementations;
using Infestation.Infra.Services.Interfaces;
using Infestation.Models;
using Infestation.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            //services.AddScoped<IMessageService<Sms>, SmsService>();

            services.AddDbContext<InfestationContext>(builder => builder.UseSqlServer(_configuration.GetConnectionString("InfestationDbConnectionNew"))
            .UseLazyLoadingProxies());
            services.AddControllersWithViews();
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Human}/{action=Index}/{id?}");
            });
        }
    }
}
