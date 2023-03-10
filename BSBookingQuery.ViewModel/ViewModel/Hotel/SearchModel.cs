namespace BSBookingQuery.ViewModel.ViewModel.Hotel
{
    public class SearchModel
    {
        public string SearchText { get; set; }

        public int? FromRating { get; set; }

        public int? ToRating { get; set; }

        public int? HotelId { get; set; }
        public int? PageId { get; set; }
    }
}
