using CrushApp.Data.DTOs;
using CrushApp.Data.Models;

namespace CrushApp.Data.Services
{
    public class UserSessionService
    {
        public UserReadDto? CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
        
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
