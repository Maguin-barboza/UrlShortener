using UrlShortener.Domain.Interfaces.Commands;
using UrlShortener.Domain.Interfaces.Queries;
using UrlShortener.Domain.Interfaces.Repositories;

namespace UrlShortener.Command
{
    public class ShortenUrlCommand : IShortenUrlCommand
    {
        private List<string> base64Characters;
        private readonly IUrlRepository _repository;

        public IUrlQuery _query { get; }

        public ShortenUrlCommand(IUrlQuery query)
        {
            base64Characters = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "/" };
            _query = query;
        }

        public async Task<string> ShortenUrl(string urlOriginal)
        {
            string urlEncurtada = string.Empty;
            Random random = new Random();

            do
            {
                for (int i = 0; i <= 5; i++)
                {
                    int numRaffle = random.Next(base64Characters.Count - 1);
                    urlEncurtada += base64Characters[numRaffle];
                }
            } while (await ShortenUrlExist(urlEncurtada));
            
            return urlEncurtada;
        }

        private async Task<bool> ShortenUrlExist(string urlShort)
        {
            return await _query.UrlShortExists(urlShort);
        }
    }
}
