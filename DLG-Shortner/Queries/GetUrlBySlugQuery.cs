using DLG_Shortner.Models;
using MediatR;

namespace DLG_Shortner.Queries
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