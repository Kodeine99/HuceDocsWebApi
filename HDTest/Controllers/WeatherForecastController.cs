using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HuceDocs.Services.Services;
using HuceDocsWebApi.JWT.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HuceDocsWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthozirationUtility _utility;

        private IWebHostEnvironment _hostingEnvironment;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IUserService userService,
            IAuthozirationUtility utility,
            IWebHostEnvironment environment
            )
        {
            _logger = logger;
            _userService = userService;
            _utility = utility;
            _hostingEnvironment = environment;
        }

        [HttpGet("test")]
        public IActionResult Get()
        {
            var userid = _utility.GetUserId(HttpContext);


            if (userid <= 0)
                return Unauthorized();

            return Ok(userid);
        }

        [HttpPost("uploads")]
        public async Task<IActionResult> Upload(IList<IFormFile> files)
        {
            var x = _hostingEnvironment;
            string y = x.WebRootPath;
            string uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads");
            Directory.CreateDirectory(uploads);
            foreach (IFormFile file in files)
            {
                if (file.Length > 0)
                {
                    string filePath = Path.Combine(uploads, file.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return Ok(uploads);
        }
    }
}