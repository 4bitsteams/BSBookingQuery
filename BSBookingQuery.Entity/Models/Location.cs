﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSBookingQuery.Entity.Models
{
    public class Location :BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
    }
}
