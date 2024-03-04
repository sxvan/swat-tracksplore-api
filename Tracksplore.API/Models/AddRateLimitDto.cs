using System.ComponentModel.DataAnnotations;
using Tracksplore.DataAccess.Models;

namespace Tracksplore.API.Models
{
    [MetadataType(typeof(RateLimit))]
    public class AddRateLimitDto
    {
        public string Url { get; set; }

        public DateTime LimitedUntil { get; set; }
    }
}
