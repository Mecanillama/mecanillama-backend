using Mecanillama.API.Appointments.Domain.Models;
using Mecanillama.API.Shared.Domain.Models;

namespace Mecanillama.API.Mechanics.Domain.Models;

public class Mechanic : Person
{
    //Properties
    public long Id { get; set; }
    public long Phone { get; set; }
    public string BusinessOwner { get; set; }
    public string Description { get; set; }

    //Relationships
    public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
    //public IList<Review> Reviews {get; set;} = new List<Review>();
}