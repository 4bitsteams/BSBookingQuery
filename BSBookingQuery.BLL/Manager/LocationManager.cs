using AutoMapper;
using BSBookingQuery.BLL.IManager;
using BSBookingQuery.DAL.UnitOfWork;
using BSBookingQuery.Entity.Models;
using BSBookingQuery.ViewModel.ViewModel;

namespace BSBookingQuery.BLL.Manager
{
    public class LocationManager : ILocationManager
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        public LocationManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task Add(CreateViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRange(IEnumerable<CreateViewModel> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(DeleteViewModel entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<DeleteViewModel> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LocationViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<LocationViewModel> GetById(int id)
        {
            var result=await this.unitOfWork.Location.GetById(id);
            var pp = _mapper.Map<Location, LocationViewModel>(result);
            return pp;
        }

        public void Update(UpdateViewModel entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<UpdateViewModel> entities)
        {
            throw new NotImplementedException();
        }
    }
}
