using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyMonitor.WebApp.Readings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnergyMonitor.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnergyReadingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnergyReadingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<EnergyReadingListItemModel>> Get()
        {
            return await _mediator.Send(new GetEnergyReadingsQuery());
        }
    }
}
