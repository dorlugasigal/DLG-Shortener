using DLG_Shortner.Handlers;
using DLG_Shortner.Models;
using MediatR;

namespace DLG_Shortner.Commands
{
    public class CreateNewShortUrlCommand : IRequest<CreateNewShortUrlCommandResponse>
    {
        public readonly ShortUrl ShortUrl;
        public CreateNewShortUrlCommand(ShortUrl shortUrl)
        {
            ShortUrl = shortUrl;
        }

    }
}