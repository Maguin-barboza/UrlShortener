namespace UrlShortener.Domain.Interfaces.Queries
{
    public interface IUrlQuery
    {
        Task<string> RetornarUrlOriginal(string urlEncurtada);
        Task<bool> UrlShortExists(string urlEncurtada);
    }
}
