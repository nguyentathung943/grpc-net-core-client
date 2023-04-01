using Microsoft.AspNetCore.Mvc;

namespace GrpcClient.SampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var forecastData = new List<WeatherForecast>();

            for (int i = 0; i < 100000; i++)
            {
                forecastData.Add(new()
                {
                    Timestamp = DateTime.Now.ToString(),
                    Summary = $"Forecast {i}",
                    TemperatureC = Random.Shared.Next(-20, 55)
                });
            }


            return forecastData;
        }
    }
}