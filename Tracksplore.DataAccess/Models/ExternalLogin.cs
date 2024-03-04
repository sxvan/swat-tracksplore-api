using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tracksplore.DataAccess.Models;

[Table(nameof(ExternalLogin))]
public class ExternalLogin : Entity
{
    [Required]
    [StringLength(100)]
    public string ProviderName { get; set; }

    [Required]
    [StringLength(100)]
    public string ProviderKey { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }
}
