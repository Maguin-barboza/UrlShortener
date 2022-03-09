using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.DTOs;
using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Interfaces.Services
{
    public interface IUrlService
    {
        Task Redirecionar(string urlEncurtada);
        Task<UrlDTO> GetByUrlEncurtada(string urlEncurtada);

        Task<UrlDTO> Add(string url);
    }
}
