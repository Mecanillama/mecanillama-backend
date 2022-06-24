
using Mecanillama.API.Mechanics.Domain.Models;

namespace Mecanillama.API.Reviews.Domain.Models;

public class Review
{
    //Properties
    public int Id { get; set; }
    public string Comment { get; set; }
    public int Score { get; set; }
    
    public long MechanicId { get; set; }
    public Mechanic Mechanic { get; set; } 
    
}