using Microsoft.AspNetCore.Mvc;
using Tracksplore.API.Models;
using Tracksplore.DataAccess.Services;

namespace Tracksplore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateLimitController : ControllerBase
    {
        private readonly RateLimitService rateLimitService;

        public RateLimitController(RateLimitService rateLimitService)
        {
            this.rateLimitService = rateLimitService;
        }

        [HttpGet]
        public IActionResult Get(string url)
        {
            return Ok(RateLimitDto.FromRateLimit(this.rateLimitService.GetByUrl(url)));
        }

        [HttpPost]
        public IActionResult Add(RateLimitDto rateLimitDto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var rateLimit = this.rateLimitService.GetByUrl(rateLimitDto.Url);
            if (rateLimit != null)
            {
                rateLimit.LimitedUntil = rateLimitDto.LimitedUntil;
                this.rateLimitService.Update(rateLimit);
            }
            else
            {
                rateLimit = this.rateLimitService.Create();
                rateLimit.Url = rateLimitDto.Url;
                rateLimit.LimitedUntil = rateLimitDto.LimitedUntil;
                this.rateLimitService.Add(rateLimit);
            }

            return CreatedAtAction(nameof(this.Add), rateLimit);
        }
    }
}
