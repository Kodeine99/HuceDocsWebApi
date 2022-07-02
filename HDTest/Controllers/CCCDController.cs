using HuceDocs.Services.Services.ChungTu;
using HuceDocs.Services.ViewModels.ChungTu;
using HuceDocsWebApi.JWT.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuceDocsWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CCCDController : ControllerBase
    {
        private readonly ICCCDService _cccdService;
        private readonly IAuthozirationUtility _utility;

        public CCCDController(IAuthozirationUtility utility,
            ICCCDService cccdService)
        {
            _utility = utility;
            _cccdService = cccdService;
        }

        // Normal user get all
        [HttpPost("search")]
        public IActionResult GetAll([FromBody] ChungTuBaseFilter filter)
        {
            var userId = _utility.GetUserId(HttpContext);
            var cccd = _cccdService.GetAll(filter, userId);

            if (cccd.IsOk == true)
            {
                return Ok(cccd);
            }
            else return BadRequest(cccd);

        }

        // Admin get all
        [HttpPost("search-admin")]
        public IActionResult AdminGetAll([FromBody] ChungTuBaseFilter filter)
        {
            var cccd = _cccdService.AdminGetAll(filter);

            if (cccd.IsOk == true)
            {
                return Ok(cccd);
            }
            else return BadRequest(cccd);
        }

        // GetById
        [HttpGet("getbyId/{Id}")]
        public IActionResult GetById(int id)
        {
            var cccd = _cccdService.GetById(id);

            return Ok(cccd);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CCCD_VM model)
        {
            var userId = _utility.GetUserId(HttpContext);
            if (userId < 0)
            {
                return Unauthorized();
            }
            var result = _cccdService.Create(model);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest("Tạo mới thất bại");
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] CCCD_VM model)
        {
            var result = _cccdService.Update(model);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
