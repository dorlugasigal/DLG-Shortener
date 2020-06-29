using System.Collections.Generic;
using System.Threading.Tasks;
using DLG_Shortner.Models;

namespace DLG_Shortner.Services
{
    public interface IShortUrlRepository<T>
    {
        Task<List<T>> Get();
        Task<T> Get(string slug);
        Task<T> Create(T shortUrl);
        Task Update(string id, T shortUrlIn);
        Task Remove(T shortUrlIn);
        Task Remove(string id);
    }
}