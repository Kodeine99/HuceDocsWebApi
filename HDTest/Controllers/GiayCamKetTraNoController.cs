using HuceDocs.Services.Services.ChungTu;
using HuceDocs.Services.ViewModels.ChungTu;
using HuceDocsWebApi.JWT.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuceDocsWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GiayCamKetTraNoController : ControllerBase
    {
        private readonly IGiayCamKetTraNoService _giayCamKetTraNoService;
        private readonly IAuthozirationUtility _utility;

        public GiayCamKetTraNoController(IAuthozirationUtility utility,
            IGiayCamKetTraNoService giayCamKetTraNoService)
        {
            _utility = utility;
            _giayCamKetTraNoService = giayCamKetTraNoService;
        }

        // Normal user get all
        [HttpGet("search")]
        public IActionResult GetAll([FromBody] ChungTuBaseFilter filter)
        {
            var userId = _utility.GetUserId(HttpContext);
            var BangDiemTiengAnh = _giayCamKetTraNoService.GetAll(filter, userId);

            if (BangDiemTiengAnh.IsOk == true)
            {
                return Ok(BangDiemTiengAnh);
            }
            else return BadRequest();

        }

        // Admin get all
        [HttpGet("search-admin")]
        public IActionResult AdminGetAll([FromBody] ChungTuBaseFilter filter)
        {
            var BangDiemTiengAnh = _giayCamKetTraNoService.AdminGetAll(filter);

            if (BangDiemTiengAnh.IsOk == true)
            {
                return Ok(BangDiemTiengAnh);
            }
            else return BadRequest();
        }

        // GetById
        [HttpGet("getbyId/{Id}")]
        public IActionResult GetById(int id)
        {
            var BangDiemTiengAnh = _giayCamKetTraNoService.GetById(id);

            return Ok(BangDiemTiengAnh);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] GIAY_CAM_KET_TRA_NO_VM model)
        {
            var userId = _utility.GetUserId(HttpContext);
            if (userId < 0)
            {
                return Unauthorized();
            }
            var result = _giayCamKetTraNoService.Create(model);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest("Tạo mới thất bại");
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] GIAY_CAM_KET_TRA_NO_VM model)
        {
            var result = _giayCamKetTraNoService.Update(model);
            if (result.IsOk == true)
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }
    }
}
