using Microsoft.AspNetCore.Mvc;

namespace GrpcClient.SampleApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [MapToApiVersion("1.0")]
        [HttpPost(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Post([FromBody] int dataLimit)
        {
            var forecastData = new List<WeatherForecast>();
            var limit = dataLimit;

            for (int i = 0; i < limit; i++)
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
