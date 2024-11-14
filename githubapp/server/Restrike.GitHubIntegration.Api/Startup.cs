using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Security.Claims;
using System.Text;
using Restrike.GitHubIntegration.EFDAL;
using Restrike.GitHubIntegration.Api.Exceptions;

namespace Restrike.GitHubIntegration.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;
        private const string ApiName = "Restrike.GitHubIntegration.Api API";

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }
        private readonly string MyAllowSpecificOrigins = "CorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = long.MaxValue;
                o.MemoryBufferThreshold = 5000000;
            });


            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            });

            //Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = ApiName, Version = "v1" });
                c.EnableAnnotations();
                c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");
                c.AddSecurityDefinition("oauth2",
                         new OpenApiSecurityScheme
                         {
                             In = ParameterLocation.Header,
                             Description = "Please enter into field the word 'Bearer' following by space and JWT",
                             Name = "Authorization",
                             Type = SecuritySchemeType.ApiKey
                         });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                          {
                                new OpenApiSecurityScheme
                                {
                                     Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2"}
                                },
                                new List<string>()
                          }
                 });
            });

            // support api versioning
            services.AddApiVersioning();
            services.AddVersionedApiExplorer(
                 options =>
                 {
                     // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                     // note: the specified format code will format the version as "'v'major[.minor][-status]"
                     options.GroupNameFormat = "'v'VVV";

                     // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                     // can also be used to control the format of the API version in route templates
                     options.SubstituteApiVersionInUrl = true;
                 });

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.WithExposedHeaders("Location");
                    });
            });

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            // Register EF context as a request-scoped dependency.
            // Doesn't use AddDbContext because that only deals with DbContextOptions,
            // which does not handle the tenantId injection.
            services.AddScoped<GitHubIntegrationEntities>(provider =>
            {
                var user = provider.GetRequiredService<IHttpContextAccessor>().HttpContext.User;
                if (Guid.TryParse(ClaimsPrincipalExtensions.GetTenantId(user), out var userTenantId))
                {
                    var userId = ClaimsPrincipalExtensions.GetUserId(user).ToString();
                    return DatabaseHelper.GetContext(userTenantId, userId);
                }

                // TODO dangerous; if calling code expects a tenant-based context, there is no warning/error
                return DatabaseHelper.GetContextWithNoTenantId();
            });

            // scan for any lifetime-annotated classes and register them with the appropriate lifetime
            services.Scan(scan => scan.FromAssemblyOf<DatabaseHelper>()
                 .AddClasses(c => c.WithAttribute<TransientLifetimeAttribute>()).AsImplementedInterfaces().WithTransientLifetime()
                 .AddClasses(c => c.WithAttribute<ScopedLifetimeAttribute>()).AsImplementedInterfaces().WithScopedLifetime()
                 .AddClasses(c => c.WithAttribute<SingletonLifetimeAttribute>()).AsImplementedInterfaces().WithSingletonLifetime());

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                         .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                         .RequireAuthenticatedUser()
                         .Build());
            });

            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                var clientMappingOptions = options.ClientErrorMapping;
                options.InvalidModelStateResponseFactory = context => new CustomUnprocessableEntityObjectResult(context.ModelState, clientMappingOptions, context.HttpContext);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api/swagger";
                c.SwaggerEndpoint("v1/swagger.json", ApiName);
            });


            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }


            app.ConfigureExceptionHandler();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



            #region Configure Database
            var connectionString = Configuration["ConnectionString"];
            if (Configuration["DataServer"]?.ToLower() == "postgres")
                DatabaseHelper.SetupPostgres(connectionString);
            else if (Configuration["DataServer"]?.ToLower() == "sql")
                DatabaseHelper.SetupSqlServer(connectionString);
            else
                throw new Exception("Invalid configuration");
            #endregion
        }

    }
}
