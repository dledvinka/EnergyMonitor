using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnergyMonitor.WebApp.WeatherForecast;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EnergyMonitor.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<EnergyMonitor.WebApp.WeatherForecast.WeatherForecast>> Get()
        {
            return await _mediator.Send(new GetWeatherForecasts());
        }
    }
}
