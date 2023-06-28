using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<Location>> GetLocations(string query);
        Task<WeatherResponse> GetWeather(Coordinate location);
    }
}
