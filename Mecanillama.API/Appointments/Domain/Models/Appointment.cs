using Mecanillama.API.Customers.Domain.Model;

namespace Mecanillama.API.Appointments.Domain.Models;

public class Appointment
{
    //Properties
    public long Id { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public bool Done { get; set; }
    
    //Relationships - many to many
    public long CustomerId { get; set; }
    public long Mechanicd { get; set; }
    //public long ApplianceId { get; set; }
    public Customer Customer { get; set; }
    //public Mechanic Mechanic { get; set; } 


}