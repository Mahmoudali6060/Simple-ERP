using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
//using Case.DataAccessLayer;
//using Case.DataServiceLayer;
//using Case.RepositoryLayer;
//using Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Account.DataServiceLayer;
using Account.DataAccessLayer;
using App.Helper;

namespace App
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

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //services.AddMvc().AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //});

            services.AddCors();

            //>>>>> Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            //>>>>End Auto Mapper Configurations

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers(options => options.EnableEndpointRouting = false);
            ////>>>Add JWT Authentication
            //services.AddAuthentication(opt =>
            //{
            //    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})

            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = "http://localhost:54095",
            //        ValidAudience = "http://localhost:54095",
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
            //    };
            //});
            ////>>>END Add JWT Authentication

            ////>>>DB Context
            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            //    b => b.MigrationsAssembly("Data")));
            /////>>>END Db Context

            //>>>Add JWT Authentication And DbContext
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, IdentityRole>()
              .AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();

            services.AddIdentityServer().AddDeveloperSigningCredential()
               // this adds the operational data from DB (codes, tokens, consents)
               .AddOperationalStore(options =>
               {
                   options.ConfigureDbContext = builder => builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                   // this enables automatic token cleanup. this is optional.
                   options.EnableTokenCleanup = true;
                   options.TokenCleanupInterval = 30; // interval in seconds
               })
               .AddAspNetIdentity<AppUser>();
            // >>> END Add JWT Authentication And DbContext

            DependencyInjection.AddTransient(services);

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
                //app.UseExceptionHandler("/Error");
                app.Use(async (context, next) =>
                {
                    await next();
                    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                    {
                        context.Request.Path = "/index.html";
                        await next();
                    }
                });
                app.UseHsts();
            }

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthentication();//JWT Auth

            app.UseStaticFiles();
            app.UseCookiePolicy();
            //app.UseIdentityServer();//Add IdentityServer to our request processing pipeline
            app.UseMvc();
        }
    }
}
