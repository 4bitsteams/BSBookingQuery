using System.ComponentModel.DataAnnotations;

namespace BSBookingQuery.ViewModel.ViewModel.Comment
{
    public class CommentCreateViewModel
    {
        [Required]
        public string CommentText { get; set; }
        [Required]
        public int HotelId { get; set; }
        [Required]
        public int PageId { get; set; }
        public int? ParentId { get; set; }
        [Required]
        public int CommentBy { get; set; }
        public string Description { get; set; }
    }
}
