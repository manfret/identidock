using Microsoft.AspNetCore.Mvc;

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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
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
            var helloWorld = "Hello World!";
            var input = "Manfret";
            var res = $"<b>{helloWorld}</b>";
            res += @"<form method='POST' action='p'>
<input type='text' name='inp' value=''>
<input type='submit' value='submit'>
</form>
<p>You look like a:</p>";
            res += $"<p><b>{input}</b></p>";
            
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
            var helloWorld = "Hello World!";
            var input = inp ?? "123";
            var res = $"<b>{helloWorld}</b>";
            res += @"<form method='POST'>
<input type='text' name='inp' value=''>
<input type='submit' value='submit'>
</form>
<p>You look like a:</p>";
            res += $"<p><b>{input}</b></p>";

            var response = new ContentResult
            {
                Content = res,
                ContentType = "text/html"
            };
            return response;
        }
    }
}