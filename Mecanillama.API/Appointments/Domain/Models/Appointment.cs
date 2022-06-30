using Mecanillama.API.Customers.Domain.Model;
using Mecanillama.API.Mechanics.Domain.Models;

namespace Mecanillama.API.Appointments.Domain.Models;

public class Appointment
{
    //Properties
    public long Id { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    //Relationships - many to many
    public long CustomerId { get; set; }
    public long MechanicId { get; set; }
    public Customer Customer { get; set; }
    public Mechanic Mechanic { get; set; } 
    
}