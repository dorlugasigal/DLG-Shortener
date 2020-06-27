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
    [Route("/u")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly ShortUrlService _shortUrlService;

        public UrlController(ShortUrlService shortUrlService)
        {
            _shortUrlService = shortUrlService;
        }

        [HttpGet("{slug}")]
        public ActionResult<ShortUrl> Get(string slug)
        {
            if (slug == null)
            {
                return NoContent();
            }

            var shortUrl = _shortUrlService.Get(slug);

            return Redirect(shortUrl == null ? $"https://dlg-shortner.herokuapp.com/err?slug={slug}" : shortUrl.Url);
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
