using Tracksplore.DataAccess.Models;

namespace Tracksplore.DataAccess.Services
{
    public class RateLimitService : Service<RateLimit>
    {
        public RateLimitService(Repository<RateLimit> repository) 
            : base(repository)
        {
        }

        public RateLimit? GetByUrl(string url)
        {
            return this.Query().SingleOrDefault(rl => rl.Url == url);
        }
    }
}
