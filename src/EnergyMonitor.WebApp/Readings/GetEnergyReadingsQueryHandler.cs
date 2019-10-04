using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EnergyMonitor.WebApp.Data;
using EnergyMonitor.WebApp.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EnergyMonitor.WebApp.Readings
{
    public class GetEnergyReadingsQueryHandler : IRequestHandler<GetEnergyReadingsQuery, IEnumerable<EnergyReadingListItemModel>>
    {
        private readonly EnergyMonitorContext _dbContext;
        private readonly ILogger<GetEnergyReadingsQueryHandler> _logger;

        public GetEnergyReadingsQueryHandler(EnergyMonitorContext dbContext, ILogger<GetEnergyReadingsQueryHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public Task<IEnumerable<EnergyReadingListItemModel>> Handle(GetEnergyReadingsQuery request, CancellationToken cancellationToken)
        {
            var tt = _dbContext.EnergyReadings.ToList();
            
            var er = new EnergyReading()
            {
                DateUtc = DateTime.UtcNow,
                Gas = 1,
                ElectricityHighRate = 2,
                ElectricityLowRate = 3
            };
            _dbContext.EnergyReadings.Add(er);

            int i = 0;
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new EnergyReadingListItemModel
            {
                Id = i++,
                DateUtc = DateTime.Now.AddDays(index),
                ElectricityHighRate = rng.Next(-20, 55),
                ElectricityLowRate = rng.Next(-20, 55),
                Gas = rng.Next(-20, 55),
            })); 
        }
    }
}
