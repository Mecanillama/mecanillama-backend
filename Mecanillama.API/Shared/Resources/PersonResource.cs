namespace Mecanillama.API.Shared.Resources;

public class PersonResource
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    //Useful in the future when implementing JWT
    //public long UserId { get; set; }
}