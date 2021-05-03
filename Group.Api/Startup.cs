using Adm.Api.Config;
using Adm.Aplication;
using Adm.Infra.Context;
using Adm.Infra.CrossCutting.Identity;
using Adm.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using NetDevPack.Identity;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.User;

namespace Adm.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAplication();

            services.AddMvc()
                .AddFluentValidation(fvc =>
                fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            // Setting the interactive AspNetUser (logged in)
            services.AddAspNetUserConfiguration();

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            // Ours JWT configuration
            services.AddJwtConfiguration(Configuration, "AppSettings");

            services.AddCustomIdentity<User, int>(options =>
                {
                    options.SignIn.RequireConfirmedEmail = false;
                    options.Lockout.MaxFailedAccessAttempts = 5;
                })
                .AddErrorDescriber<PortugueseIdentityErrorDescriber>()
                .AddCustomRoles<Role, int>()
                .AddCustomEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.AddSwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration();

            app.UseRouting();

            app.UseAuthConfiguration();
            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
