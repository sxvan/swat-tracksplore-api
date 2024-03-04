using System.ComponentModel.DataAnnotations.Schema;

namespace Tracksplore.DataAccess.Models;

[Table(nameof(Artist))]
public class Artist : Entity
{
    public string SpotifyId { get; set; }

    public ISet<MusicTaste> MusicTastes { get; set; } = new HashSet<MusicTaste>();
}
