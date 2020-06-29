using DLG_Shortener.Handlers;
using DLG_Shortener.Models;
using MediatR;

namespace DLG_Shortener.Commands
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