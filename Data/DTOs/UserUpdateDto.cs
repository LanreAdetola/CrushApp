namespace CrushApp.Data.DTOs;

public class UserUpdateDto
{
    public string? Username { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty; // Optional

    public string Gender { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Interests { get; set; } = string.Empty;

    public string PreferredGender { get; set; } = string.Empty;
}
