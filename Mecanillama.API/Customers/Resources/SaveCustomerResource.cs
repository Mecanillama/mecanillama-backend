using System.ComponentModel.DataAnnotations;
using Mecanillama.API.Shared.Resources;

namespace Mecanillama.API.Customers.Resources;

public class SaveCustomerResource: SavePersonResource
{
    [Required]
    [MaxLength(40)]
    public string CarMake { get; set; }

}