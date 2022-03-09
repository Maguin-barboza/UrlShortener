using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Context;
using UrlShortener.Domain.Interfaces.Repositories;
using UrlShortener.Domain.Models;

namespace UrlShortener.Data.Repository
{
    public class UrlRepository : IUrlRepository
    {
        private readonly UrlShortContext _context;

        public UrlRepository(UrlShortContext context)
        {
            _context = context;
        }

        public IQueryable<Url> Select()
        {
            IQueryable<Url> query = _context.Urls.AsNoTracking();
            return query;
        }

        public async Task<Url> Add(Url url)
        {
            _context.Add(url);
            await _context.SaveChangesAsync();
            
            return url;
        }
    }
}
