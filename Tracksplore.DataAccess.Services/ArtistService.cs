using Tracksplore.DataAccess.Models;

namespace Tracksplore.DataAccess.Services;

public class ArtistService : Service<Artist>
{
    public ArtistService(Repository<Artist> repository)
      : base(repository)
    {
    }

    public Artist? GetBySpotifyId(string spotifyId)
    {
        return this.Query().SingleOrDefault(a => a.SpotifyId == spotifyId);
    }
}
