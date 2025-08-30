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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using VetClinic.Data;
using VetClinic.Options;
using VetClinic.Data.Interfaces;
using VetClinic.Data.MsSqlStore;
using VetClinic.Business.Interfaces;
using VetClinic.Business.Services;

namespace VetClinic
{
    public class Startup
    {
        readonly string VetClinicAllowSpecificOrigins = "_vetClinicAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Turtleman's Vet Clinic", Version = "v1" });
            });

            services.AddTransient<IVetClinicBusinessService, VetClinicBusinessService>();
            services.AddTransient<IVetClinicStore, VetClinicMsSqlStore>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: VetClinicAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });

            //AddNewtonsoftJson to enable patch
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(options =>
            {
                options.RouteTemplate = swaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI( options => 
            {
                options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(VetClinicAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
