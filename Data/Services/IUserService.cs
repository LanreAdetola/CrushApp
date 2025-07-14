using CrushApp.Data.DTOs;

namespace CrushApp.Data.Services;

public interface IUserService
{
    Task<UserReadDto?> GetUserByIdAsync(int id);
    Task<bool> UpdateUserAsync(int id, UserUpdateDto dto);

    // You can keep your Register method too
    Task<UserReadDto?> RegisterUserAsync(UserCreateDto dto);
}
