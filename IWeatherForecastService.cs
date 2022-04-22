using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radzio
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecastService> Get(); 
    }
}
