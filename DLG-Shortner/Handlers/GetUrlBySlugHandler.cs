using System.Threading;
using System.Threading.Tasks;
using DLG_Shortner.Models;
using DLG_Shortner.Queries;
using DLG_Shortner.Services;
using MediatR;

namespace DLG_Shortner.Handlers
{
    public class GetUrlBySlugHandler : IRequestHandler<GetUrlBySlugQuery, string>
    {
        private readonly IShortUrlRepository<ShortUrl> _repository;

        public GetUrlBySlugHandler(IShortUrlRepository<ShortUrl> repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(GetUrlBySlugQuery request, CancellationToken cancellationToken)
        {
            var shortUrl = await _repository.Get(request.Slug);

            return shortUrl == null ? $"https://dlg-sh.herokuapp.com/err?slug={request.Slug}" : shortUrl.Url;
        }
    }
}