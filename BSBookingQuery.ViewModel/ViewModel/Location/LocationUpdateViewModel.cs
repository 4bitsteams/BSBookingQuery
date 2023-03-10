using System.ComponentModel.DataAnnotations;

namespace BSBookingQuery.ViewModel.ViewModel.Location
{
    public class LocationUpdateViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
    }
}
