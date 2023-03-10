using BSBookingQuery.BLL.IManager;
using BSBookingQuery.ViewModel.ViewModel.Rating;
using Microsoft.AspNetCore.Mvc;

namespace BSBookingQuery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingManager RatingManager;
        private readonly ILogger<RatingController> _iLogger;
        public RatingController(IRatingManager RatingManager, ILogger<RatingController> iLogger)
        {
            this.RatingManager = RatingManager;
            _iLogger = iLogger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var _data = await this.RatingManager.GetAllAsync();
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("RatingController - Task<IActionResult> GetAll()", ex);
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

                var _data = await this.RatingManager.GetAsync(id);
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("RatingController - Task<IActionResult> GetById(int id)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(RatingCreateViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var _data = await this.RatingManager.Add(model);
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
                _iLogger.LogError("RatingController - Task<IActionResult> Create(RatingCreateViewModel model)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(RatingUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _data = await this.RatingManager.Update(model);
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
                _iLogger.LogError("RatingController - Task<IActionResult> Update(RatingUpdateViewModel model)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var _data = await this.RatingManager.Delete(id);
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("RatingController - Task<IActionResult> Remove(int id)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }
    }
}
