using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrpcClient.SampleApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class GreetController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public GreetController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [MapToApiVersion("1.0")]
        [HttpPost(Name = "GetGreet")]
        public string Post([FromBody] string Name)
        {
            return $"Hello {Name} How are you doing today? I hope you're doing well. It's great to see you again. I hope you're having a fantastic day so far. I'm excited to chat with you today and catch up on what's been going on in your life. Let me know if there's anything new or exciting that you'd like to share with me. I'm always here to listen and support you in any way that I can. Have a wonderful day! blush";
        }
    }
}
