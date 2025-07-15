using CrushApp.Data.Models;

namespace CrushApp.Data.Services
{
    public class UserSessionService
    {
        public User? CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;

        public void SetUser(User user)
        {
            CurrentUser = user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
