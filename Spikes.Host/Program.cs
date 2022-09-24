using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Spikes.Host.Healthchecks;

namespace Spikes.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();


            builder.Services
                .AddHealthChecks()
                .AddCheck<SampleHealthCheck>("Sample");


            var app = builder.Build();

            app.MapHealthChecks("/sysinfo/health",
                new HealthCheckOptions
                {
                    ResponseWriter =
                    HealthCheckResponseWriter.WriteResponse
                });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}