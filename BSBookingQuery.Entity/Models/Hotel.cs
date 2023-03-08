using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSBookingQuery.Entity.Models
{
    public class Hotel :BaseEntity
    {
        public string Name { get; set; }

        public Rating Rating { get; set; }
        public Location Location { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
