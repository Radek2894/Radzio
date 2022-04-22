using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radzio
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
       };

        public IEnumerable<WeatherForecast> Get(int count, int minTemperature, int maxTemperature)
        {
            var rng = new Random();
            return Enumerable.Range(1, count).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(minTemperature, maxTemperature),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        IEnumerable<WeatherForecastService> IWeatherForecastService.Get(int count, int minTemperature, int maxTemperature)
        {
            throw new NotImplementedException();
        }
    }
}
