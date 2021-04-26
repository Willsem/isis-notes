namespace ISISNotesBackend.Core.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }

        public User(string id, string username, string email, string avatar)
        {
            Id = id;
            Username = username;
            Email = email;
            Avatar = avatar;
        }
    }
}