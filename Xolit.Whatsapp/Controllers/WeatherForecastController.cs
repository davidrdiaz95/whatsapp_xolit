using Microsoft.AspNetCore.Mvc;
using Xolit.Whatsapp.Contracts.Invokers.Conversation;

namespace Xolit.Whatsapp.Controllers
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
        private readonly ISendConversationInvoker conversationInvoker;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            ISendConversationInvoker conversationInvoker)
        {
            _logger = logger;
            this.conversationInvoker = conversationInvoker;
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
    }
}