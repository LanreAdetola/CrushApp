namespace CrushApp.Data.Models;

public class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public string Role { get; set; } = "User";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
}
