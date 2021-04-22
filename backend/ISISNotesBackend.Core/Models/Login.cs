namespace ISISNotesBackend.Core.Models
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}