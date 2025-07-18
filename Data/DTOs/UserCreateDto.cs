using System.ComponentModel.DataAnnotations;

namespace CrushApp.Data.DTOs;

public class UserCreateDto
{   
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required, MinLength(6)]
    public string Password { get; set; } = string.Empty;
}
