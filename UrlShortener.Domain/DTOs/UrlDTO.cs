using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.DTOs
{
    public class UrlDTO
    {
        public int Id { get; set; }
        public string UrlOriginal { get; set; }
        public string UrlEncurtada { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
