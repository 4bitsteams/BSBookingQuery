using AutoMapper;
using BSBookingQuery.Entity.Models;
using BSBookingQuery.ViewModel.ViewModel;

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
        }
    }
}
