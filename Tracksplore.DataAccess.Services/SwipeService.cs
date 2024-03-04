using Tracksplore.DataAccess.Models;

namespace Tracksplore.DataAccess.Services;

public class SwipeService : Service<Swipe>
{
    public SwipeService(Repository<Swipe> repository)
      : base(repository)
    {
    }

    public IEnumerable<Swipe> GetAllByUserId(Guid userId)
    {
        return this.Query().Where(s => s.UserId == userId).AsEnumerable();
    }

    public Swipe? GetByUserIdAndSpotifyTrackId(Guid userId, string spotifyTrackId)
    {
        return this.Query().SingleOrDefault(s => s.UserId == userId && s.SpotifyTrackId == spotifyTrackId);
    }
}
