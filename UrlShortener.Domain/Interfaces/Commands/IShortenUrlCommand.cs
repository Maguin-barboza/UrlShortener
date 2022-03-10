using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Interfaces.Commands
{
    public interface IShortenUrlCommand
    {
        Task<string> ShortenUrl(string urlOriginal);
    }
}
