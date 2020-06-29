using System;
using System.Threading;
using System.Threading.Tasks;
using DLG_Shortner.Commands;
using DLG_Shortner.Models;
using DLG_Shortner.Services;
using Fare;
using MediatR;

namespace DLG_Shortner.Handlers
{
    public class CreateNewShortUrlHandler : IRequestHandler<CreateNewShortUrlCommand, CreateNewShortUrlCommandResponse>
    {
        private IShortUrlRepository<ShortUrl> _repository;

        public CreateNewShortUrlHandler(IShortUrlRepository<ShortUrl> repository)
        {
            _repository = repository;
        }
        public async Task<CreateNewShortUrlCommandResponse> Handle(CreateNewShortUrlCommand request, CancellationToken cancellationToken)
        {
            var slug = request.ShortUrl.Slug;

            if (!string.IsNullOrEmpty(slug))
            {
                var url = await _repository.Get(slug);
                if (url != null)
                {
                    return new CreateNewShortUrlCommandResponse()
                    { IsConflict = true, ConflictMessage = $"Slug '{url.Slug}' is in use" };
                }
            }

            if (string.IsNullOrEmpty(slug))
            {
                var xeger = new Xeger("[a-z0-9]{5}", new Random());
                slug = xeger.Generate();
            }

            request.ShortUrl.Slug = slug.ToLower();

            var res = await _repository.Create(request.ShortUrl);
            return new CreateNewShortUrlCommandResponse() { ShortUrl = res };
        }
    }
}