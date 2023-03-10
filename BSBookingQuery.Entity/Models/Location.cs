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
