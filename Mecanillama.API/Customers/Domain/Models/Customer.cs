using Mecanillama.API.Appointments.Domain.Models;
using Mecanillama.API.Shared.Domain.Models;

namespace Mecanillama.API.Customers.Domain.Model;

public class Customer : Person
{
    // Properties
    public long Id { get; set; }
    public string CarMake { get; set; }

    //Relationships (specified in Person.cs)
}