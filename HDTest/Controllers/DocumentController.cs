using HuceDocs.Services;
using HuceDocs.Services.ViewModels.Document;
using HuceDocsWebApi.JWT.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HuceDocsWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private IDocumentService _documentService;
        private readonly IAuthozirationUtility _securityUtility;
        private readonly IConfiguration _config;
        private readonly ILogger<DocumentController> _logger;

        public DocumentController(
            IDocumentService documentService,
            IAuthozirationUtility sercurityUtility,
            IConfiguration config,
            ILogger<DocumentController> logger)
        {
            _documentService = documentService;
            _securityUtility = sercurityUtility;
            _config = config;
            _logger = logger;
        }


        [HttpPost("create/extraction")]
        public async Task<IActionResult> Extraction([FromForm] ExtractionRequest request)
        {
            //request.UserId = await _securityUtility.GetUserIdAsync(HttpContext);
            //if (request.UserId <= 0) return Unauthorized();

            var result = await _documentService.CreateExtraction(request);
            return Ok(result);
        }
    }
}
