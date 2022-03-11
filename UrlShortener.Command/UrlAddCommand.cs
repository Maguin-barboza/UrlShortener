using AutoMapper;
using System.Text.RegularExpressions;
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
                if (!urlValidation(originalUrl))
                    throw new Exception("Url não é válida.");

                shortUrl = _shortenUrl.ShortenUrl(originalUrl);
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

        private bool urlValidation(string originalUrl)
        {
            string pattern = @"^(http|ftp|https|www)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$";
            Regex urlRegex = new Regex(pattern, RegexOptions.IgnoreCase);

            Match urlTest = urlRegex.Match(originalUrl);
            return urlTest.Success;
        }


    }
}
