﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UrlShortener.Domain.DTOs;
using UrlShortener.Domain.Interfaces.Repositories;
using UrlShortener.Domain.Interfaces.Services;
using UrlShortener.Domain.Models;

namespace UrlShortener.Service.Services
{
    public class UrlService : IUrlQuery
    {
        private readonly IUrlRepository _repository;
        private readonly IMapper _mapper;

        public UrlService(IUrlRepository repository, IMapper mapper)
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
