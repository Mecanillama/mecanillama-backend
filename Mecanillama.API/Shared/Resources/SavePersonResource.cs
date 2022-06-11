using System.ComponentModel.DataAnnotations;

namespace Mecanillama.API.Shared.Resources;

public class SavePersonResource
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Address { get; set; }
    
    //Useful in the future when implementing JWT
    //[Required]
    //public long UserId { get; set; }
}