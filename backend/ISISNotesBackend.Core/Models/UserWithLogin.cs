namespace ISISNotesBackend.Core.Models
{
    public class UserWithLogin
    {
        public User User { get; set; }
        public Login Login { get; set; }

        public UserWithLogin(User user, Login login)
        {
            User = user;
            Login = login;
        }
    }
}