namespace DLG_Shortener.Models
{
    public class ShorterUrlDatabaseSettings : IShorterUrlDatabaseSettings
    {
        public string UrlsCollectionName { get; set; }
        public string DatabaseName { get; set; }
    }
}