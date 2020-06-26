namespace DLG_Shortner.Models
{
    public class ShorterUrlDatabaseSettings : IShorterUrlDatabaseSettings
    {
        public string UrlsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IShorterUrlDatabaseSettings
    {
        string UrlsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}