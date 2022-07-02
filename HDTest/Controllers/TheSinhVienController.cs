using HuceDocs.Services.Services.ChungTu;
using HuceDocs.Services.ViewModels.ChungTu;
using HuceDocsWebApi.JWT.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuceDocsWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TheSinhVienController : ControllerBase
    {
        private readonly ITheSinhVienService _theSinhVienService;
        private readonly IAuthozirationUtility _utility;

        public TheSinhVienController(IAuthozirationUtility utility,
            ITheSinhVienService theSinhVienService)
        {
            _utility = utility;
            _theSinhVienService = theSinhVienService;
        }

        // Normal user get all
        [HttpPost("search")]
        public IActionResult GetAll([FromBody] ChungTuBaseFilter filter)
        {
            var userId = _utility.GetUserId(HttpContext);
            var theSinhVien = _theSinhVienService.GetAll(filter, userId);

            if (theSinhVien.IsOk == true)
            {
                return Ok(theSinhVien);
            }
            else return BadRequest();

        }

        // Admin get all
        [HttpPost("search-admin")]
        public IActionResult AdminGetAll([FromBody] ChungTuBaseFilter filter)
        {
            var theSinhVien = _theSinhVienService.AdminGetAll(filter);

            if (theSinhVien.IsOk == true)
            {
                return Ok(theSinhVien);
            }
            else return BadRequest();
        }

        // GetById
        [HttpGet("getbyId/{Id}")]
        public IActionResult GetById(int id)
        {
            var theSinhVien = _theSinhVienService.GetById(id);

            return Ok(theSinhVien);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] THE_SINH_VIEN_VM model)
        {
            var userId = _utility.GetUserId(HttpContext);
            if (userId < 0)
            {
                return Unauthorized();
            }
            var result = _theSinhVienService.Create(model);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest("Tạo mới thất bại");
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] THE_SINH_VIEN_VM model)
        {
            var result = _theSinhVienService.Update(model);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
