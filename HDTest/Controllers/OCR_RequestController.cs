using HuceDocs.Services;
using HuceDocs.Services.ViewModels.OcrRequest;
using HuceDocsWebApi.Attributes;
using HuceDocsWebApi.JWT.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HuceDocsWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OCR_RequestController : ControllerBase
    {
        private readonly IOCR_RequestService _ocrRequestService;
        private readonly IAuthozirationUtility _utility;

        public OCR_RequestController(
            IOCR_RequestService ocrRequestService,
            IAuthozirationUtility utility)
        {
            _ocrRequestService = ocrRequestService;
            _utility = utility;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UpdateOCR_RequestVM request)
        {
     
            // Create OCR_Request

            var ocr_RqVM = await _ocrRequestService.CreateAsync(request);


            if (ocr_RqVM.IsOk == false)
            {
                return BadRequest(ocr_RqVM);
            }
            return Ok(ocr_RqVM);
        }

        [HttpGet("abc")]
        public IActionResult GetAbc()
        {
            return Ok("abc");
        }

        [HttpPost("update")]
        public  IActionResult Update([FromBody] UpdateOCR_RequestVM request)
        {
            var updateSuccess =  _ocrRequestService.Update(request);

            if (updateSuccess.IsOk == false)
            {
                return BadRequest(updateSuccess);
            }
            return Ok(updateSuccess);
        }

        [HttpPost("getall")]
        //[CustomAuthorization(Policy = "admin,manager")]
        public IActionResult GetAll([FromBody]OCR_RequestFilter filter)
        {
            var result = _ocrRequestService.GetAll(filter);

            return Ok(result);
        }

        [HttpPost("usergetall")]
        public IActionResult UserGetAll([FromBody] OCR_RequestFilter filter)
        {
            var userId = _utility.GetUserId(HttpContext);
            if (userId <= 0) 
                return Unauthorized();

            var result = _ocrRequestService.UserGetAll(filter, userId);
            return Ok(result);
        }
    }

}
