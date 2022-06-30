using System.ComponentModel.DataAnnotations;

namespace Mecanillama.API.Appointments.Resources;

public class SaveAppointmentResource
{
    [Required]
    public string Date { get; set; }
        
    [Required]
    public string Time { get; set; }

    [Required]
    public long CustomerId { get; set; }

    [Required]
    public long MechanicId { get; set; }
    
}