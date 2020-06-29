using DLG_Shortener.Models;
using MediatR;

namespace DLG_Shortener.Queries
{
    public class GetUrlBySlugQuery : IRequest<string>
    {
        public string Slug { get; set; }

        public GetUrlBySlugQuery(string slug)
        {
            Slug = slug;
        }
    }
}