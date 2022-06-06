using System.ComponentModel.DataAnnotations;

namespace Mecanillama.API.Customers.Resources;

public class SaveCustomerResource
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
}