using System.ComponentModel.DataAnnotations.Schema;

namespace Tracksplore.DataAccess.Models;

[Table(nameof(MusicTaste))]
public class MusicTaste : Entity
{
    public bool IsDisabled { get; set; }

    public ISet<Artist> Artists { get; set; } = new HashSet<Artist>();

    public ISet<GenreFeature> GenreFeatures { get; set; } = new HashSet<GenreFeature>();

    public Guid UserId { get; set; }

    public User? User { get; set; }
}
