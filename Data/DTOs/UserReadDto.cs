namespace CrushApp.Data.DTOs;

public class UserReadDto
{
    public string Id { get; set; } = string.Empty; // ✅ Change from int to string
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = "User";
    public DateTime CreatedAt { get; set; }

    public int NumericId { get; set; }



public string Gender { get; set; } = "";
public int Age { get; set; }
public string Location { get; set; } = "";
public string Interests { get; set; } = "";
public string PreferredGender { get; set; } = "";
}
