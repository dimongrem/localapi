using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Jaeger;
using Jaeger.Samplers;
using OpenTracing.Util;
using System;
using System.Threading;
using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using Jaeger.Senders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTracing.Contrib.NetCore.Configuration;
using OpenTracing.Util;
using OpenTracing;
using Serilog;
using Serilog.Sinks.Seq;
using localapi.Services;
using localapi.Services.Implementations;

namespace localapi
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
            services.AddOpenTracing();
            services.AddSingleton<ITracer>(serviceProvider =>
            {
                string serviceName = serviceProvider.GetRequiredService<IWebHostEnvironment>().ApplicationName;

                // This will log to a default localhost installation of Jaeger.
                var tracer = new Tracer.Builder(serviceName)
                    .WithSampler(new ConstSampler(true))
                    .Build();

                // Allows code that can't use DI to also access the tracer.
                GlobalTracer.Register(tracer);

                return tracer;
            });
            services.AddSingleton<ILoggingService, LoggingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Log.Logger = new LoggerConfiguration()
            //     .WriteTo.Seq("http://localhost:5341")
            //     .CreateLogger();
            // Log.Debug("Hello Logger!");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
