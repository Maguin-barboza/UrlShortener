using Microsoft.AspNetCore.Mvc;
using UrlShortener.API.Inputs;
using UrlShortener.Domain.DTOs;
using UrlShortener.Domain.Interfaces.Commands;
using UrlShortener.Domain.Interfaces.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlShortener.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("")]
    [ApiController]
    public class UrlShortnerController : ControllerBase
    {
        private readonly IUrlQuery _query;
        private readonly IUrlAddCommand _command;

        public UrlShortnerController(IUrlQuery query, IUrlAddCommand command)
        {
            _query = query;
            _command = command;
        }


        //TODO: Deletar essa parte.
        //[HttpGet("teste")]
        //[ResponseCache(Duration = 120)]
        //public IActionResult GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        [HttpGet("{urlEncurtada}")]
        [ResponseCache(Duration = 120)]
        public async Task<IActionResult> RedirectAsync(string urlEncurtada)
        {
            try
            {
                string urlOriginal;

                urlOriginal = await _query.RetornarUrlOriginal(urlEncurtada);
                return Redirect(urlOriginal);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UrlOriginalInputModel urlInputModel)
        {
            UrlDTO urlDTO;

            try
            {
                urlDTO = await _command.Add(urlInputModel.UrlOriginal);
                return Ok(urlDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
