namespace DLG_Shortner.Models
{
    public interface IShorterUrlDatabaseSettings
    {
        string UrlsCollectionName { get; set; }
        string DatabaseName { get; set; }
    }
}