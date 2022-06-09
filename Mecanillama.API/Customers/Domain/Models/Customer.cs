using Mecanillama.API.Appointments.Domain.Models;

namespace Mecanillama.API.Customers.Domain.Model;

public class Customer
{
    // Properties
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string CarMake { get; set; }
    public string Address { get; set; }

    //Relationships
    public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
}