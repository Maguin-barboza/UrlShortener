using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Interfaces.Repositories
{
    public interface IUrlRepository
    {
        IQueryable<Url> Select();

        Task<Url> Add(Url url);
    }
}
