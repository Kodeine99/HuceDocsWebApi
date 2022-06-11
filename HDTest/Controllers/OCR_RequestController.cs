using HuceDocs.Services;
using HuceDocs.Services.ViewModels.OcrRequest;
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

        public OCR_RequestController(
            IOCR_RequestService ocrRequestService)
        {
            _ocrRequestService = ocrRequestService;
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
    }
}
