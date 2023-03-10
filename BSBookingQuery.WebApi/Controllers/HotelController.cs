using BSBookingQuery.BLL.IManager;
using BSBookingQuery.ViewModel.ViewModel.Hotel;
using Microsoft.AspNetCore.Mvc;

namespace BSBookingQuery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelManager HotelManager;
        private readonly ILogger<HotelController> _iLogger;
        public HotelController(IHotelManager HotelManager, ILogger<HotelController> iLogger)
        {
            this.HotelManager = HotelManager;
            _iLogger = iLogger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var _data = await this.HotelManager.GetAllAsync();
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("HotelController - Task<IActionResult> GetAll()", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }

        [HttpPost("SearchHotel")]
        public async Task<IActionResult> Search(SearchModel searchModel)
        {
            try
            {
                var _data = await this.HotelManager.Search(searchModel);
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("HotelController - Task<IActionResult> Search(SearchModel searchModel)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id == 0 || id.ToString() == null)
                {
                    //TODO Need to Send Message And Status Code
                    return null;
                }

                var _data = await this.HotelManager.GetAsync(id);
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("HotelController - Task<IActionResult> GetById(int id)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(HotelCreateViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var _data = await this.HotelManager.Add(model);
                    return Ok(_data);
                }
                else
                {
                    //TODO Need to Send Message And Status Code
                    return null;
                }
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("HotelController - Task<IActionResult> Create(HotelCreateViewModel model)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(HotelUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _data = await this.HotelManager.Update(model);
                    return Ok(_data);
                }
                else
                {
                    //TODO Need to Send Message And Status Code
                    return null;
                }
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("HotelController - Task<IActionResult> Update(HotelUpdateViewModel model)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var _data = await this.HotelManager.Delete(id);
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("HotelController - Task<IActionResult> Remove(int id)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }
    }
}
