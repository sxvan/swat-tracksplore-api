using System.ComponentModel.DataAnnotations;

namespace Tracksplore.DataAccess.Models
{
    public class RateLimit : Entity
    {
        [Required]
        [MaxLength(3000)]
        public string Url { get; set; }

        public DateTime LimitedUntil { get; set; }
    }
}
