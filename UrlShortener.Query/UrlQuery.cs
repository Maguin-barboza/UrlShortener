using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.DTOs;
using UrlShortener.Domain.Interfaces.Queries;
using UrlShortener.Domain.Interfaces.Repositories;
using UrlShortener.Domain.Models;

namespace UrlShortener.Query
{
    public class UrlQuery : IUrlQuery
    {
        private readonly IUrlRepository _repository;
        private readonly IMapper _mapper;

        public UrlQuery(IUrlRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> RetornarUrlOriginal(string urlEncurtada)
        {
            try
            {
                UrlDTO urlDTO = await GetByUrlEncurtada(urlEncurtada);
                return urlDTO.UrlOriginal;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<UrlDTO> GetByUrlEncurtada(string urlEncurtada)
        {
            try
            {
                Url urlEncontrada = await _repository.Select().FirstOrDefaultAsync(url => url.UrlEncurtada.Contains(urlEncurtada));

                if (urlEncontrada is null)
                    throw new Exception("Url inexistente.");

                UrlDTO urlDTO = _mapper.Map<UrlDTO>(urlEncontrada);
                return urlDTO;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
