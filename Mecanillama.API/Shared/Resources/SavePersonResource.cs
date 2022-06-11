using System.ComponentModel.DataAnnotations;

namespace Mecanillama.API.Shared.Resources;

public class SavePersonResource
{
    [Required]
    [MaxLength(80)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(80)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(80)]
    public string Address { get; set; }
    
    [Required]
    public long UserId { get; set; }
}