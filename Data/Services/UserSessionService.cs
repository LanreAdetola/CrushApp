using CrushApp.Data.DTOs;
using Microsoft.JSInterop;
using System.Text.Json;

namespace CrushApp.Data.Services
{
    public class UserSessionService
    {
        private readonly IJSRuntime _js;

        public UserReadDto? CurrentUser { get; private set; }
        public bool IsLoggedIn => CurrentUser != null;

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public UserSessionService(IJSRuntime js)
        {
            _js = js;
        }

        // Call this in App.razor or MainLayout to restore session on reload
        public async Task InitializeAsync()
        {
            var json = await _js.InvokeAsync<string>("localStorage.getItem", "loggedInUser");
            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    CurrentUser = JsonSerializer.Deserialize<UserReadDto>(json);
                    NotifyStateChanged();
                }
                catch
                {
                    await _js.InvokeVoidAsync("localStorage.removeItem", "loggedInUser");
                }
            }
        }

        public async Task LoginAsync(UserReadDto user)
        {
            CurrentUser = user;
            var json = JsonSerializer.Serialize(user);
            await _js.InvokeVoidAsync("localStorage.setItem", "loggedInUser", json);
            NotifyStateChanged();
        }

        public async Task LogoutAsync()
        {
            CurrentUser = null;
            await _js.InvokeVoidAsync("localStorage.removeItem", "loggedInUser");
            NotifyStateChanged();
        }

        // ✅ Optional compatibility for older code
        public void Login(UserReadDto user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        public void Logout()
        {
            CurrentUser = null;
            NotifyStateChanged();
        }
    }
}
