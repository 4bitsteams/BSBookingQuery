using System.ComponentModel.DataAnnotations;

namespace BSBookingQuery.ViewModel.ViewModel.Rating
{
    public class RatingUpdateViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        //Ex. 3 stars, 7 stars
        public string Name { get; set; }
        [Required]
        //Ex. 3, 7
        public int Rank { get; set; }
        public string Description { get; set; }
    }
}
