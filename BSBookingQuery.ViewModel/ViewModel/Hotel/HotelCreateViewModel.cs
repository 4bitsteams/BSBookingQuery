using System.ComponentModel.DataAnnotations;

namespace BSBookingQuery.ViewModel.ViewModel.Hotel
{
    public class HotelCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int RatingId { get; set; }
        [Required]
        public int LocationId { get; set; }
        public string Description { get; set; }
    }
}
