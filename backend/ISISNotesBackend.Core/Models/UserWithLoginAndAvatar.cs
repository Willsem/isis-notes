namespace ISISNotesBackend.Core.Models
{
    public class UserWithLoginAndAvatar
    {
        public User User { get; set; }
        public Login Login { get; set; }
        public byte[] AvatarContent { get; set; }

        public UserWithLoginAndAvatar(User user, Login login, byte[] avatarContent)
        {
            User = user;
            Login = login;
            AvatarContent = avatarContent;
        }
    }
}