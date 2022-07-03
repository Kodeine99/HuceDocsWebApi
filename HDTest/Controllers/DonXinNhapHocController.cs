using HuceDocs.Services.Services.ChungTu;
using HuceDocs.Services.ViewModels.ChungTu;
using HuceDocsWebApi.JWT.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuceDocsWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DonXinNhapHocController : ControllerBase
    {
        private readonly IDonXinNhapHocService _donXinNhapHocService;
        private readonly IAuthozirationUtility _utility;

        public DonXinNhapHocController(IAuthozirationUtility utility,
            IDonXinNhapHocService donXinNhapHocService)
        {
            _utility = utility;
            _donXinNhapHocService = donXinNhapHocService;
        }

        // Normal user get all
        [HttpPost("search")]
        public IActionResult GetAll([FromBody] ChungTuBaseFilter filter)
        {
            var userId = _utility.GetUserId(HttpContext);
            var donXinNhapHoc = _donXinNhapHocService.GetAll(filter, userId);

            if (donXinNhapHoc.IsOk == true)
            {
                return Ok(donXinNhapHoc);
            }
            else return BadRequest(donXinNhapHoc);

        }

        // Admin get all
        [HttpPost("search-admin")]
        public IActionResult AdminGetAll([FromBody] ChungTuBaseFilter filter)
        {
            var donXinNhapHoc = _donXinNhapHocService.AdminGetAll(filter);

            if (donXinNhapHoc.IsOk == true)
            {
                return Ok(donXinNhapHoc);
            }
            else return BadRequest(donXinNhapHoc);
        }

        // GetById
        [HttpGet("getbyId/{Id}")]
        public IActionResult GetById(int id)
        {
            var donXinNhapHoc = _donXinNhapHocService.GetById(id);

            return Ok(donXinNhapHoc);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DON_XIN_NHAP_HOC_VM model)
        {
            var userId = _utility.GetUserId(HttpContext);
            if (userId < 0)
            {
                return Unauthorized();
            }
            var result = _donXinNhapHocService.Create(model);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest("Tạo mới thất bại");
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] DON_XIN_NHAP_HOC_VM model)
        {
            var result = _donXinNhapHocService.Update(model);
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
            var result = _donXinNhapHocService.Delete(docId);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
