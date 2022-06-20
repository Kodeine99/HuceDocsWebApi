using HuceDocs.Services.Services.ChungTu;
using HuceDocs.Services.ViewModel.Filter;
using HuceDocs.Services.ViewModels.ChungTu;
using HuceDocsWebApi.JWT.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuceDocsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiayXacNhanToeicController : ControllerBase
    {
        private readonly IGiayXacNhanToeicService _giayXacNhanToeicService;
        private readonly IAuthozirationUtility _utility;

        public GiayXacNhanToeicController(IAuthozirationUtility utility,
            IGiayXacNhanToeicService giayXacNhanToeicService)
        {
            _utility = utility;
            _giayXacNhanToeicService = giayXacNhanToeicService;
        }

        // Normal user get all
        [HttpPost("search")]
        public IActionResult GetAll([FromBody] ChungTuBaseFilter filter)
        {
            var userId = _utility.GetUserId(HttpContext);
            var GiayXacNhanToeic = _giayXacNhanToeicService.GetAll(filter, userId);

            if (GiayXacNhanToeic.IsOk == true)
            {
                return Ok(GiayXacNhanToeic);
            }
            else return BadRequest();

        }

        // Admin get all
        [HttpPost("search-admin")]
        public IActionResult AdminGetAll([FromBody] ChungTuBaseFilter filter)
        {
            var GiayXacNhanToeic = _giayXacNhanToeicService.AdminGetAll(filter);

            if (GiayXacNhanToeic.IsOk == true)
            {
                return Ok(GiayXacNhanToeic);
            }
            else return BadRequest();
        }

        // GetById
        [HttpGet("getbyId/{Id}")]
        public IActionResult GetById(int id)
        {
            var GiayXacNhanToeic = _giayXacNhanToeicService.GetById(id);

            return Ok(GiayXacNhanToeic);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] GIAY_XAC_NHAN_TOEIC_VM model)
        {
            var userId = _utility.GetUserId(HttpContext);
            if (userId < 0)
            {
                return Unauthorized();
            }
            var result = _giayXacNhanToeicService.Create(model);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest("Tạo mới thất bại");
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] GIAY_XAC_NHAN_TOEIC_VM model)
        {
            var result = _giayXacNhanToeicService.Update(model);
            if (result.IsOk == true)
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }
    }
}
