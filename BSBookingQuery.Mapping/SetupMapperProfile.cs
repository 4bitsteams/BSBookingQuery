using AutoMapper;
using BSBookingQuery.Entity.Models;
using BSBookingQuery.ViewModel.ViewModel.Location;
using BSBookingQuery.ViewModel.ViewModel.Rating;

namespace BSBookingQuery.Mapping
{
    public class SetupMapperProfile : Profile
    {
        public SetupMapperProfile()
        {
            #region map entity for location
            CreateMap<LocationViewModel, Location>().ReverseMap();
            CreateMap<LocationCreateViewModel, Location>().ReverseMap();
            CreateMap<LocationUpdateViewModel, Location>().ReverseMap();
            #endregion

            #region map entity for rating
            CreateMap<RatingViewModel, Rating>().ReverseMap();
            CreateMap<RatingCreateViewModel, Rating>().ReverseMap();
            CreateMap<RatingUpdateViewModel, Rating>().ReverseMap();
            #endregion
        }
    }
}
