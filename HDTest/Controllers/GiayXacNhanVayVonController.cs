using HuceDocs.Services.Services.ChungTu;
using HuceDocs.Services.ViewModels.ChungTu;
using HuceDocsWebApi.JWT.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuceDocsWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GiayXacNhanVayVonController : ControllerBase
    {

        private readonly IGiayXacNhanVayVonService _giayXacNhanVayVon;
        private readonly IAuthozirationUtility _utility;

        public GiayXacNhanVayVonController(IAuthozirationUtility utility,
            IGiayXacNhanVayVonService giayXacNhanVayVonService)
        {
            _utility = utility;
            _giayXacNhanVayVon = giayXacNhanVayVonService;
        }

        // Normal user get all
        [HttpPost("search")]
        public IActionResult GetAll([FromBody] ChungTuBaseFilter filter)
        {
            var userId = _utility.GetUserId(HttpContext);
            var giayXacNhanVayVon = _giayXacNhanVayVon.GetAll(filter, userId);

            if (giayXacNhanVayVon.IsOk == true)
            {
                return Ok(giayXacNhanVayVon);
            }
            else return BadRequest(giayXacNhanVayVon);

        }

        // Admin get all
        [HttpPost("search-admin")]
        public IActionResult AdminGetAll([FromBody] ChungTuBaseFilter filter)
        {
            var giayXacNhanVayVon = _giayXacNhanVayVon.AdminGetAll(filter);

            if (giayXacNhanVayVon.IsOk == true)
            {
                return Ok(giayXacNhanVayVon);
            }
            else return BadRequest(giayXacNhanVayVon);
        }

        // GetById
        [HttpGet("getbyId/{Id}")]
        public IActionResult GetById(int id)
        {
            var giayXacNhanVayVon = _giayXacNhanVayVon.GetById(id);

            return Ok(giayXacNhanVayVon);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] GIAY_XAC_NHAN_VAY_VON_VM model)
        {
            var userId = _utility.GetUserId(HttpContext);
            if (userId < 0)
            {
                return Unauthorized();
            }
            var result = _giayXacNhanVayVon.Create(model);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest("Tạo mới thất bại");
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] GIAY_XAC_NHAN_VAY_VON_VM model)
        {
            var result = _giayXacNhanVayVon.Update(model);
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
            var result = _giayXacNhanVayVon.Delete(docId);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
