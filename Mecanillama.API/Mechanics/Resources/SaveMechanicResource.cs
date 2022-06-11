using System.ComponentModel.DataAnnotations;
using Mecanillama.API.Shared.Resources;

namespace Mecanillama.API.Mechanics.Resources;

public class SaveMechanicResource : SavePersonResource
{
    
    [Required]
    [MaxLength(200)]
    public string BusinessOwner { get; set; }
    [Required]
    [MaxLength(300)]
    public string Description { get; set; }
    [Required]
    public long Phone { get; set; }

}