using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherForecastApi.Models
{
    public static class InitDb
    {
        public static void Prepopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<WeatherForecastContext>());
            }
        }

        public static void SeedData(WeatherForecastContext context)
        {
            System.Console.WriteLine("Applying Db migrations...");

            context.Database.Migrate();

            if (!context.WeatherForecasts.Any())
            {
                System.Console.WriteLine("Seeding Db with some data");
                context.WeatherForecasts.AddRange(new[]
                {
                    new WeatherForecast { Date = new DateTime(2021,1,2), TemperatureC = 1, Summary = "Cloudy with some snow" },
                    new WeatherForecast { Date = new DateTime(2021,1,3), TemperatureC = -1, Summary = "Cloudy with much snow" },
                    new WeatherForecast { Date = new DateTime(2021,1,4), TemperatureC = -2, Summary = "Cloudy" },
                    new WeatherForecast { Date = new DateTime(2021,1,5), TemperatureC = 2, Summary = "Partly cloudy" },
                    new WeatherForecast { Date = new DateTime(2021,1,6), TemperatureC = 3, Summary = "Sunny" }
                });
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Db already contains some data");
            }
        }
    }
}