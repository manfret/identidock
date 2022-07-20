using docker_test.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace docker_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("t")]
        public async Task<ActionResult> HelloWorld()
        {
            var header = "Try reverse";
            var placeholder = "result will be here";
            var res = $"<p>{header}</p>";
            res += @"<form method='POST' action='p'>
<input type='text' name='inp' value=''>
<input type='submit' value='submit'>
</form>
<p>You look like a:</p>";
            res += $"<p>{placeholder}</p>";
            
            var response = new ContentResult
            {
                Content = res,
                ContentType = "text/html"
            };
            return response;
        }

        [HttpPost("p")]
        public async Task<ActionResult> HelloWorld([FromForm]string? inp)
        {
            var header = "Try reverse";
            var output = inp == null ? "provide some value" : _weatherService.GetLooksLike(inp);
            var res = $"<b>{header}</b>";
            res += @"<form method='POST'>
<input type='text' name='inp' value=''>
<input type='submit' value='submit'>
</form>
<p>You look like a:</p>";
            res += $"<p><b>{output}</b></p>";

            var response = new ContentResult
            {
                Content = res,
                ContentType = "text/html"
            };
            return response;
        }
    }
}