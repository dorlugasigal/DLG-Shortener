using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DLG_Shortner.Models;
using MongoDB.Driver;

namespace DLG_Shortner.Services
{
    public class ShortUrlRepository : IShortUrlRepository<ShortUrl>
    {
        private readonly IMongoCollection<ShortUrl> _repository;

        public ShortUrlRepository(IShorterUrlDatabaseSettings settings)
        {
            var connStr = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
            var client = new MongoClient(connStr);
            var database = client.GetDatabase(settings.DatabaseName);

            _repository = database.GetCollection<ShortUrl>(settings.UrlsCollectionName);
        }

        public async Task<List<ShortUrl>> Get() =>
            await _repository.FindAsync(url => true).Result.ToListAsync();

        public async Task<ShortUrl> Get(string slug) =>
            await _repository.FindAsync<ShortUrl>(url => url.Slug == slug).Result.FirstOrDefaultAsync();

        public async Task<ShortUrl> Create(ShortUrl shortUrl)
        {
            await _repository.InsertOneAsync(shortUrl);
            return shortUrl;
        }

        public async Task Update(string id, ShortUrl shortUrlIn) =>
            await _repository.ReplaceOneAsync(url => url.Id == id, shortUrlIn);


        public async Task Remove(ShortUrl shortUrlIn) =>
            await _repository.DeleteOneAsync(url => url.Id == shortUrlIn.Id);

        public async Task Remove(string id) =>
            await _repository.DeleteOneAsync(url => url.Id == id);
    }
}