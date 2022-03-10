using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Interfaces.Commands;

namespace UrlShortener.Command
{
    public class ShortenUrlCommand : IShortenUrlCommand
    {
        public Task<string> ShortenUrl(string urlOriginal)
        {
            throw new NotImplementedException();
        }
    }
}
