using System.ComponentModel.DataAnnotations;
using Tracksplore.DataAccess.Models;

namespace Tracksplore.API.Models
{
    [MetadataType(typeof(RateLimit))]
    public class RateLimitDto
    {
        public Guid Id { get; set; }

        public string Url { get; set; }

        public DateTime LimitedUntil { get; set; }

        public static RateLimitDto? FromRateLimit(RateLimit? rateLimit)
        {
            if (rateLimit == null)
            {
                return null;
            }

            return new RateLimitDto
            {
                Id = rateLimit.Id,
                Url = rateLimit.Url,
                LimitedUntil = rateLimit.LimitedUntil
            };
        }
    }
}
