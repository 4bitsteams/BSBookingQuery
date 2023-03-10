namespace BSBookingQuery.Entity.Models
{
    public class Hotel :BaseEntity
    {
        public string Name { get; set; }
        public int RatingId { get; set; }
        public int LocationId { get; set; }
        public Rating Rating { get; set; }
        public Location Location { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
