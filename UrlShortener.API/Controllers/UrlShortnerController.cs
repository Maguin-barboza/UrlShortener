using Microsoft.AspNetCore.Mvc;
using UrlShortener.Domain.DTOs;
using UrlShortener.Domain.Interfaces.Commands;
using UrlShortener.Domain.Interfaces.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlShortener.API.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("teste")]
        [ResponseCache(Duration = 120)]
        public IActionResult GetAll()
        {
            throw new NotImplementedException();
        }

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
        public async Task<IActionResult> Post([FromBody]string url)
        {
            UrlDTO urlDTO;

            //TODO: Criar uma ModelView para receber a informação do Front-End;
            //      Tal ModelView só passará a urloriginal para o command.
            try
            {
                urlDTO = await _command.Add(url);
                return Ok(urlDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
