using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EnergyMonitor.WebApp.Readings
{
    public class GetEnergyReadingsQuery : IRequest<IEnumerable<EnergyReadingListItemModel>>
    {
    }
}
