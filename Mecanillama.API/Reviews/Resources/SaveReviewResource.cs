using System.ComponentModel.DataAnnotations;
namespace Mecanillama.API.Reviews.Resources;

public class SaveReviewResource
{
    
    [Required]
    [MaxLength(200)]
    public string Comment { get; set; }
    [Required]
    public int Score { get; set; }

}