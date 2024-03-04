using System.ComponentModel.DataAnnotations;
using Tracksplore.DataAccess.Models;

namespace Tracksplore.API.Models;

[MetadataType(typeof(ExternalLogin))]
public class AddExternalLoginDto
{
    public string ProviderName { get; set; }

    public string ProviderKey { get; set; }

    public Guid UserId { get; set; }
}
