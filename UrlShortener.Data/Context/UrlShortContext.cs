using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Models;

namespace UrlShortener.Data.Context
{
    public class UrlShortContext: DbContext
    {
        public UrlShortContext(DbContextOptions options) : base(options)  {   }

        public DbSet<Url> Urls { get; set; }
    }
}
