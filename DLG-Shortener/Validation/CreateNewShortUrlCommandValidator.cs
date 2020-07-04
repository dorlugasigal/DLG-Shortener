using System.Security.Cryptography.X509Certificates;
using DLG_Shortener.Commands;
using FluentValidation;

namespace DLG_Shortener.Validation
{
    public class CreateNewShortUrlCommandValidator : AbstractValidator<CreateNewShortUrlCommand>
    {
        public CreateNewShortUrlCommandValidator()
        {
            RuleFor(x => x.ShortUrl.Url).NotEmpty();
        }
    }
}