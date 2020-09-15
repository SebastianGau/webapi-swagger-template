using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;


namespace webapi_template_2
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
            services.AddControllers();
            //.AddNewtonsoftJson(); //uncomment to use newtonsoft json serializer
            services.AddSwaggerGen();
            services.AddSwaggerDocument();
            services.AddSwaggerGenNewtonsoftSupport();

            AddJagerIfNecessary(services);
        }

        private static void AddJagerIfNecessary(IServiceCollection services)
        {
            var jagerhost = Environment.GetEnvironmentVariable("OT_JAEGER_HOST");
            if (String.IsNullOrEmpty(jagerhost))
            {
                return;
            }
            var jaegerport = Environment.GetEnvironmentVariable("OT_JAEGER_PORT");
            jaegerport = jaegerport ?? "16686";
            var jagerservicename = Environment.GetEnvironmentVariable("OT_JAEGER_SERVICENAME") ?? Assembly.GetCallingAssembly().GetName().Name;


            services.AddOpenTelemetryTracerProvider(
                            (builder) => builder
                                    .AddAspNetCoreInstrumentation()
                                    .AddJaegerExporter(ex =>
                                    {
                                        ex.AgentHost = jagerhost;
                                        ex.AgentPort = Convert.ToInt32(jaegerport);
                                        ex.ServiceName = jagerservicename;
                                    })
                            );
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseStaticFiles();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
