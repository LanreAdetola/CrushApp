using System.Net.Http.Json;
using CrushApp.Data.DTOs;

namespace CrushApp.Data.Services;

public class UserService : IUserService
{
    private readonly HttpClient _http;

    public UserService(HttpClient http)
    {
        _http = http;
    }

    public async Task<UserReadDto?> GetUserByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<UserReadDto>($"api/users/{id}");
    }

    public async Task<bool> UpdateUserAsync(int id, UserUpdateDto dto)
    {
        var response = await _http.PutAsJsonAsync($"api/users/{id}", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<UserReadDto?> RegisterUserAsync(UserCreateDto dto)
    {
        var response = await _http.PostAsJsonAsync("api/users", dto);
        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadFromJsonAsync<UserReadDto>();
    }
}
