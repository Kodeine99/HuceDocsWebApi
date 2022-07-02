using HuceDocs.Services.Services.ChungTu;
using HuceDocs.Services.ViewModels.ChungTu;
using HuceDocsWebApi.JWT.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuceDocsWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BangDiemTiengAnhController : ControllerBase
    {
        private readonly IBangDiemTiengAnhService _bangDiemTiengAnhService;
        private readonly IAuthozirationUtility _utility;

        public BangDiemTiengAnhController(IAuthozirationUtility utility,
            IBangDiemTiengAnhService bangDiemTiengAnhService)
        {
            _utility = utility;
            _bangDiemTiengAnhService = bangDiemTiengAnhService;
        }

        // Normal user get all
        [HttpPost("search")]
        public IActionResult GetAll([FromBody] BANG_DIEM_TIENG_ANH_Filter filter)
        {
            var userId = _utility.GetUserId(HttpContext);
            var BangDiemTiengAnh = _bangDiemTiengAnhService.GetAll(filter, userId);

            if (BangDiemTiengAnh.IsOk == true)
            {
                return Ok(BangDiemTiengAnh);
            }
            else return BadRequest();

        }

        // Admin get all
        [HttpPost("search-admin")]
        public IActionResult AdminGetAll([FromBody] BANG_DIEM_TIENG_ANH_Filter filter)
        {
            var BangDiemTiengAnh = _bangDiemTiengAnhService.AdminGetAll(filter);

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
            var BangDiemTiengAnh = _bangDiemTiengAnhService.GetById(id);

            return Ok(BangDiemTiengAnh);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] BANG_DIEM_TIENG_ANH_VM model)
        {
            var userId = _utility.GetUserId(HttpContext);
            if (userId < 0)
            {
                return Unauthorized();
            }
            var result = _bangDiemTiengAnhService.Create(model);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest("Tạo mới thất bại");
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] BANG_DIEM_TIENG_ANH_VM model)
        {
            var result = _bangDiemTiengAnhService.Update(model);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("delete/{docId}")]
        public IActionResult Delete(int docId)
        {
            var userId = _utility.GetUserId(HttpContext);
            if (userId < 0)
            {
                return Unauthorized();
            }
            var result = _bangDiemTiengAnhService.Delete(docId);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
