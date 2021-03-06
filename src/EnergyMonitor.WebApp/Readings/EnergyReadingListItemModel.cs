﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitor.WebApp.Readings
{
    public class EnergyReadingListItemModel
    {
        public int Id { get; set; }
        public DateTime DateUtc { get; set; }
        public decimal? Gas { get; set; }
        public decimal? ElectricityHighRate { get; set; }
        public decimal? ElectricityLowRate { get; set; }
    }
}
