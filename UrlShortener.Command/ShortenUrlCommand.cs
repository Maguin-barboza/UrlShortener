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
        public string ShortenUrl(string urlOriginal)
        {
            string urlEncurtada;

            byte[] toEncodeAsByte = ASCIIEncoding.UTF8.GetBytes(urlOriginal);
            urlEncurtada = Convert.ToBase64String(toEncodeAsByte, 0, 5);
            return urlEncurtada;
        }
    }
}
