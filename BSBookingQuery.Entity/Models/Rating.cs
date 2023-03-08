namespace BSBookingQuery.Entity.Models
{
    public class Rating : BaseEntity
    {
        //Ex. 3 stars, 7 stars
        public string Name { get; set; }
        //Ex. 3, 7
        public int Rank { get; set; }
    }
}
