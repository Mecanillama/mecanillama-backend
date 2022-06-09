using System.ComponentModel.DataAnnotations;

namespace Mecanillama.API.Mechanics.Resources;

public class SaveMechanicResource
{
    [Required]
    [MaxLength(40)]
    public string Name { get; set; }
    [Required]
    [MaxLength(40)]
    public string Email { get; set; }
    [Required]
    [MaxLength(40)]
    public string Password { get; set; }
    [Required]
    [MaxLength(40)]
    public string Address { get; set; }
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    [MaxLength(10)]
    public long PhoneNumber { get; set; }
}