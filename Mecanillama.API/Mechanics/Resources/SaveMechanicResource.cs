using System.ComponentModel.DataAnnotations;
using Mecanillama.API.Shared.Resources;

namespace Mecanillama.API.Mechanics.Resources;

public class SaveMechanicResource : SavePersonResource
{

    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    [MaxLength(10)]
    public long PhoneNumber { get; set; }
}