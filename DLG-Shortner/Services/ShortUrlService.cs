using System.Collections.Generic;
using DLG_Shortner.Models;
using MongoDB.Driver;

namespace DLG_Shortner.Services
{
    public class ShortUrlService
    {
        private readonly IMongoCollection<ShortUrl> _shortUrls;

        public ShortUrlService(IShorterUrlDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _shortUrls = database.GetCollection<ShortUrl>(settings.UrlsCollectionName);
        }

        public List<ShortUrl> Get() =>
            _shortUrls.Find(url => true).ToList();

        public ShortUrl Get(string slug) =>
            _shortUrls.Find<ShortUrl>(url => url.Slug == slug).FirstOrDefault();

        public ShortUrl Create(ShortUrl shortUrl)
        {
            _shortUrls.InsertOne(shortUrl);
            return shortUrl;
        }

        public void Update(string id, ShortUrl shortUrlIn) =>
            _shortUrls.ReplaceOne(url => url.Id == id, shortUrlIn);

        public void Remove(ShortUrl shortUrlIn) =>
            _shortUrls.DeleteOne(url => url.Id == shortUrlIn.Id);

        public void Remove(string id) =>
            _shortUrls.DeleteOne(url => url.Id == id);
    }
}