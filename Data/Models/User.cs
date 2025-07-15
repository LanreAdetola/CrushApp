using Newtonsoft.Json;

namespace CrushApp.Data.Models;

public class User
{
    [JsonProperty("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public string Role { get; set; } = "User";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;

    public int NumericId { get; set; }  // Optional: Only needed if you're using int for lookup



    // 🔥 Match-related fields
    public string Gender { get; set; } = "";
    public int Age { get; set; }
    public string Location { get; set; } = "";
    public string Interests { get; set; } = "";
    public string PreferredGender { get; set; } = "";

}