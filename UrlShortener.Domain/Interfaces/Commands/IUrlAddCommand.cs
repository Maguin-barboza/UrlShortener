using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.DTOs;

namespace UrlShortener.Domain.Interfaces.Commands
{
    public interface IUrlAddCommand
    {
        Task<UrlDTO> Add(string url);
    }
}
