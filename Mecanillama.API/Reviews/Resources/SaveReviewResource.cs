using System.ComponentModel.DataAnnotations;

namespace Mecanillama.API.Reviews.Resources;

public class SaveReviewResource
{
    [Required]
    [MaxLength(40)]
    public string Comment { get; set; }
    [Required]
    public string Score { get; set; }
}