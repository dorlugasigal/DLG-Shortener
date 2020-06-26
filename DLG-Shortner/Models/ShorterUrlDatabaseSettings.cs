namespace DLG_Shortner.Models
{
    public class ShorterUrlDatabaseSettings : IShorterUrlDatabaseSettings
    {
        public string UrlsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}