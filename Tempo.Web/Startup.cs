using Gymify.Data.Entities;
using Gymify.Data.Enums;
using Gymify.Domain.Models.Configurations;
using Gymify.Web.Infrastructure;
using Gymify.Web.Infrastructure.AuthorizationRequirements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Gymify.Web
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
            System.Console.WriteLine(Configuration.GetConnectionString("Gymify"));

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            services.AddDbContext<TempoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Tempo")));


            var jwtConfiguration = new JwtConfiguration();
            Configuration.GetSection(nameof(JwtConfiguration)).Bind(jwtConfiguration);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtConfiguration.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtConfiguration.AudienceId,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(jwtConfiguration.GetAudienceSecretBytes())
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.Admin, policy => policy.Requirements.Add(new RoleRequirement(Role.Admin)));
                options.AddPolicy(Policies.Employee, policy => policy.Requirements.Add(new RoleRequirement(Role.Employee)));
                options.AddPolicy(Policies.RegularUser, policy => policy.Requirements.Add(new RoleRequirement(Role.RegularUser)));
            });

            services.AddSingleton<IAuthorizationHandler, RoleRequirementHandler>();

            services.Configure<JwtConfiguration>(Configuration.GetSection(nameof(JwtConfiguration)));

            //services.AddTransient<IClaimProvider, ClaimProvider>();
            //services.AddTransient<IJwtService, JwtService>();
            //
            //services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IStudentRepository, StudentRepository>();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/Build";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
