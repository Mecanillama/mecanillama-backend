using System.Text.Json.Serialization;

namespace Mecanillama.API.Security.Domain.Models;

public class User
{
    public long Id { get; set; }
    public string Email { get; set; }
    
    //Possible Role Attribute
    [JsonIgnore]
    public string PasswordHash { get; set; }
}