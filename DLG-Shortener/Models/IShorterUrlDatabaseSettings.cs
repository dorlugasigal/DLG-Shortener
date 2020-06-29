namespace DLG_Shortener.Models
{
    public interface IShorterUrlDatabaseSettings
    {
        string UrlsCollectionName { get; set; }
        string DatabaseName { get; set; }
    }
}