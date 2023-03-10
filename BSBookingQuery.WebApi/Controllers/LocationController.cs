using BSBookingQuery.BLL.IManager;
using BSBookingQuery.ViewModel.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BSBookingQuery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationManager locationManager;
        private readonly ILogger<LocationController> _iLogger;
        public LocationController(ILocationManager locationManager, ILogger<LocationController> iLogger)
        {
            this.locationManager = locationManager;
            _iLogger = iLogger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var _data = await this.locationManager.GetAllAsync();
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("LocationController - Task<IActionResult> GetAll()", ex);
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

                var _data = await this.locationManager.GetAsync(id);
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("LocationController - Task<IActionResult> GetById(int id)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(LocationCreateViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var _data = await this.locationManager.Add(model);
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
                _iLogger.LogError("LocationController - Task<IActionResult> Create(LocationCreateViewModel model)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(LocationUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _data = await this.locationManager.Update(model);
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
                _iLogger.LogError("LocationController - Task<IActionResult> Update(LocationUpdateViewModel model)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var _data = await this.locationManager.Delete(id);
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("LocationController - Task<IActionResult> Remove(int id)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }
    }
}
