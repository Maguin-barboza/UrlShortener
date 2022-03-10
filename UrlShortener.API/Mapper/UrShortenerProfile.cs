using AutoMapper;
using UrlShortener.Domain.DTOs;
using UrlShortener.Domain.Models;

namespace UrlShortener.API.Mapper
{
    public class UrShortenerProfile: Profile
    {
        public UrShortenerProfile()
        {
            CreateMap<Url, UrlDTO>();
        }
    }
}
