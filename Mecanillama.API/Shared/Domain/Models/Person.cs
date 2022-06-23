using Mecanillama.API.Appointments.Domain.Models;

namespace Mecanillama.API.Shared.Domain.Models;

public class Person
{
    // Properties
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    
    public long UserId { get; set; }

    //Relationships
    //One to many
    public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
}