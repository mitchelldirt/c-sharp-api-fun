using Microsoft.AspNetCore.Mvc;

namespace Test_API.Controllers;

[ApiController]
[Route("weather")]
public class WeatherForecastForMeController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastForMeController> _logger;

    public WeatherForecastForMeController(ILogger<WeatherForecastForMeController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "dumbWeather")]
    public IEnumerable<WeatherForecastForMe> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecastForMe
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

