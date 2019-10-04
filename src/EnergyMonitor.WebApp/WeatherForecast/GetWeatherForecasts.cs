using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EnergyMonitor.WebApp.WeatherForecast
{
    public class GetWeatherForecasts : IRequest<IEnumerable<WeatherForecast>>
    {
    }

    public class GetWeatherForecastsHandler : IRequestHandler<GetWeatherForecasts, IEnumerable<WeatherForecast>>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILogger<GetWeatherForecastsHandler> _logger;

        public GetWeatherForecastsHandler(ILogger<GetWeatherForecastsHandler> logger)
        {
            _logger = logger;
        }

        public Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecasts request, CancellationToken cancellationToken)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }));
        }
    }
}
