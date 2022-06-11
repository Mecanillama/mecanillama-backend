namespace Mecanillama.API.Reviews.Domain.Models;

public class Review
{
    // Properties
    public int Id { get; set; }
    public string Comment { get; set; }
    public double Score { get; set; }

    //Relationships
    //public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
}