using Microsoft.EntityFrameworkCore;

namespace WeatherForecastApi.Models
{
    public class WeatherForecastContext : DbContext
    {
        public WeatherForecastContext(DbContextOptions<WeatherForecastContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}