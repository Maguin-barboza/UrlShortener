using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlShortener.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortnerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{urlEncurtada}")]
        public IActionResult GetAll(string urlEncurtada)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Post(string url)
        {
            throw new NotImplementedException();
        }
    }
}
