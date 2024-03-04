using Tracksplore.DataAccess.Models;

namespace Tracksplore.DataAccess.Services;

public class GenreFeatureService : Service<GenreFeature>
{
    public GenreFeatureService(Repository<GenreFeature> repository)
      : base(repository)
    {
    }
}
