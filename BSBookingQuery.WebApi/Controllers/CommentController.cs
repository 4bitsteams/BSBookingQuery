using BSBookingQuery.BLL.IManager;
using BSBookingQuery.ViewModel.ViewModel.Comment;
using BSBookingQuery.ViewModel.ViewModel.Hotel;
using Microsoft.AspNetCore.Mvc;

namespace BSBookingQuery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentManager CommentManager;
        private readonly ILogger<CommentController> _iLogger;
        public CommentController(ICommentManager CommentManager, ILogger<CommentController> iLogger)
        {
            this.CommentManager = CommentManager;
            _iLogger = iLogger;
        }
        [HttpPost("GetCommentByHotelId")]
        public async Task<IActionResult> GetCommentByHotelId(SearchModel searchModel)
        {
            try
            {
                var _data = await this.CommentManager.GetCommentByHotelIdAsync(searchModel);
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("CommentController - Task<IActionResult> GetCommentByHotelId(SearchModel searchModel)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var _data = await this.CommentManager.GetAllAsync();
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("CommentController - Task<IActionResult> GetAll()", ex);
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

                var _data = await this.CommentManager.GetAsync(id);
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("CommentController - Task<IActionResult> GetById(int id)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CommentCreateViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var _data = await this.CommentManager.Add(model);
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
                _iLogger.LogError("CommentController - Task<IActionResult> Create(CommentCreateViewModel model)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(CommentUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _data = await this.CommentManager.Update(model);
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
                _iLogger.LogError("CommentController - Task<IActionResult> Update(CommentUpdateViewModel model)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var _data = await this.CommentManager.Delete(id);
                return Ok(_data);
            }
            catch (System.Exception ex)
            {
                _iLogger.LogError("CommentController - Task<IActionResult> Remove(int id)", ex);
                //TODO Need to Send Message And Status Code
                return null;
            }
        }
    }
}
