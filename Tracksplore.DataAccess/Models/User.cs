using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tracksplore.DataAccess.Enums;

namespace Tracksplore.DataAccess.Models;

[Table(nameof(User))]
public class User : Entity
{
    [Required]
    [StringLength(50, MinimumLength = 4)]
    public string DisplayName { get; set; }

    [Required]
    [StringLength(300)]
    [EmailAddress]
    public string Email { get; set; }

    public string? PasswordHash { get; set; }

    public DateTime BirthDate { get; set; }

    public Gender Gender { get; set; }

    public string? SpotifyId { get; set; }

    public Guid? SpotifyTokenId { get; set; }

    public SpotifyToken? SpotifyToken { get; set; }

    public ISet<MusicTaste> MusicTastes { get; set; } = new HashSet<MusicTaste>();

    public ISet<ExternalLogin> ExternalLogins { get; set; } = new HashSet<ExternalLogin>();
}
