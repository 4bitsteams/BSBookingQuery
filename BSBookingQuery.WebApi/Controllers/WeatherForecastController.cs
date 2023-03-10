using BSBookingQuery.BLL.IManager;
using BSBookingQuery.ViewModel.ViewModel.Location;
using Microsoft.AspNetCore.Mvc;

namespace BSBookingQuery.WebApi.Controllers
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
        private readonly ILocationManager locationManager;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILocationManager locationManager)
        {
            _logger = logger;
            this.locationManager = locationManager;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<LocationViewModel> GetLocationById(int id)
        {
            return await locationManager.GetAsync(id);
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}