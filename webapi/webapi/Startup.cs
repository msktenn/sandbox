using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace webapi
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

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://restrak.local:4000";
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "api1";
                });


            var builder = services.AddMvcCore();
            builder.AddAuthorization();
            builder.AddJsonFormatters();
            builder.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //------ AddMVC ------
            //builder.AddApiExplorer();
            //AddDefaultFrameworkParts(builder.PartManager);
            //builder.AddFormatterMappings();
            //builder.AddViews();
            //builder.AddRazorViewEngine();
            //builder.AddCacheTagHelper();
            //builder.AddDataAnnotations(); // +1 order
            //builder.AddCors();
            //builder.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //return new MvcBuilder(builder.Services, builder.PartManager);
            //--------------------



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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
