using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DLG_Shortener.Commands;
using DLG_Shortener.Models;
using DLG_Shortener.Queries;
using Fare;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DLG_Shortener.Controllers
{
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
    [Route("/u")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UrlController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetUrlBySlug(string slug)
        {
            var query = new GetUrlBySlugQuery(slug);

            if (slug == null)
            {
                return NoContent();
            }

            var result = await _mediator.Send(query);

            return Redirect(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewShortUrl([FromBody]ShortUrl shortUrl)
        {
            var command = new CreateNewShortUrlCommand(shortUrl);
            try
            {
                var result = await _mediator.Send(command);
                return result.IsConflict
                    ? (IActionResult)Conflict(result.ConflictMessage)
                    : Ok(result.ShortUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }

        }
    }
}
