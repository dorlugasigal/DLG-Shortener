using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DLG_Shortner.Models;
using DLG_Shortner.Services;
using Fare;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DLG_Shortner.Controllers
{
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
    [Route("/url/")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly ShortUrlService _shortUrlService;

        public UrlController(ShortUrlService shortUrlService)

        {
            _shortUrlService = shortUrlService;
        }

        // GET: api/Url
        [HttpGet]
        public ActionResult<List<ShortUrl>> Get() => _shortUrlService.Get();

        [HttpGet("{slug}")]
        public ActionResult<ShortUrl> Get(string slug)
        {
            //  return Redirect("https://weather.com/he-IL/weather/today/l/ISXX0010:1:IS");

            var shortUrl = _shortUrlService.Get(slug);

            if (shortUrl == null)
            {
                return NotFound();
            }

            return shortUrl;
        }

        [HttpPost]
        public IActionResult Create([FromBody]ShortUrl shortUrl)
        {
            if (!string.IsNullOrEmpty(shortUrl.Slug))
            {
                var url = _shortUrlService.Get(shortUrl.Slug);
                if (url != null)
                {
                    return Conflict($"Slug '{url.Slug}' is in use");
                }
            }

            if (string.IsNullOrEmpty(shortUrl.Slug))
            {
                var xeger = new Xeger("[a-z0-9]{5}", new Random());
                shortUrl.Slug = xeger.Generate();
            }

            shortUrl.Slug = shortUrl.Slug.ToLower();

            try
            {
                var res = _shortUrlService.Create(shortUrl);
                return Ok(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }
    }
}
