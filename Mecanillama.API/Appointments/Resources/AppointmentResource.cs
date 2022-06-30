namespace Mecanillama.API.Appointments.Resources;

public class AppointmentResource
{
    public long Id { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public long CustomerId { get; set; }
    public long MechanicId { get; set; }
}