using DLG_Shortener.Models;

namespace DLG_Shortener.Handlers
{
    public class CreateNewShortUrlCommandResponse
    {
        public ShortUrl ShortUrl { get; set; }
        public string ConflictMessage { get; set; }
        public bool IsConflict { get; set; }
    }
}