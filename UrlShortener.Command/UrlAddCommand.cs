using AutoMapper;

using UrlShortener.Domain.DTOs;
using UrlShortener.Domain.Interfaces.Commands;
using UrlShortener.Domain.Interfaces.Repositories;
using UrlShortener.Domain.Models;

namespace UrlShortener.Command
{
    public class UrlAddCommand: IUrlAddCommand
    {
        private readonly IShortenUrlCommand _shortenUrl;
        private readonly IUrlRepository _repository;
        private readonly IMapper _mapper;

        public UrlAddCommand(IShortenUrlCommand shortenUrl, IUrlRepository repository, IMapper mapper)
        {
            _shortenUrl = shortenUrl;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UrlDTO> Add(string originalUrl)
        {
            string shortUrl;
            Url url;
            UrlDTO urlDTO;

            try
            {
                //TODO: Validar se url é válida
                //      Verificar se url já existe
                shortUrl = await _shortenUrl.ShortenUrl(originalUrl);
                url = new Url() { UrlOriginal = originalUrl, UrlEncurtada = shortUrl, DtCriacao = DateTime.Now };
                await _repository.Add(url);

                urlDTO = _mapper.Map<UrlDTO>(url);
                return urlDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

        }
    }
}
