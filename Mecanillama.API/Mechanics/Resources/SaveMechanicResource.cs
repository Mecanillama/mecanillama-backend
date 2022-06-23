using System.ComponentModel.DataAnnotations;
using Mecanillama.API.Shared.Resources;

namespace Mecanillama.API.Mechanics.Resources;

public class SaveMechanicResource
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    [Required]
    [MaxLength(200)]
    public string Address { get; set; }

    [Required]
    [MaxLength(300)]
    public string Description { get; set; }
    
    [Required]
    public long Phone { get; set; }
    
    [Required]
    public long UserId { get; set; }

}