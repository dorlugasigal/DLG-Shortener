using DLG_Shortner.Models;

namespace DLG_Shortner.Handlers
{
    public class CreateNewShortUrlCommandResponse
    {
        public ShortUrl ShortUrl { get; set; }
        public string ConflictMessage { get; set; }
        public bool IsConflict { get; set; }
    }
}