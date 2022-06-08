using System.ComponentModel.DataAnnotations;

namespace Mecanillama.API.Customers.Resources;

public class SaveCustomerResource
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
    public string CarMake { get; set; }
    [Required]
    [MaxLength(40)]
    public string Address { get; set; }
}