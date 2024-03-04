using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tracksplore.DataAccess.Models;

[Table(nameof(GenreFeature))]
public class GenreFeature : Entity
{
    [Required]
    [StringLength(100)]
    public string Genre { get; set; }

    [MinLength(0)]
    [MaxLength(100)]
    public double Percentage { get; set; }

    public Guid MusicTasteId { get; set; }

    public MusicTaste MusicTaste { get; set; }
}
