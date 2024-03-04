using System.ComponentModel.DataAnnotations;

namespace Tracksplore.DataAccess.Models;

public abstract class Entity
{
    [Key]
    public Guid Id { get; set; }

    public DateTime CreationDateTime { get; set; }
}
