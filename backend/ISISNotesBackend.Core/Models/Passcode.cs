using System;

namespace ISISNotesBackend.Core.Models
{
    public class Passcode
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        
        public User User { get; set; }

        public Passcode(Guid id, string password, User user)
        {
            string exceptionMessage = "Wrong parameters: \n";
            
            if (string.IsNullOrEmpty(password))
            {
                exceptionMessage += $"'{nameof(password)}': Password can't be null \n";
            }
            if (user == null)
            {
                exceptionMessage += $"'{nameof(user)}': Reference to User can't be null \n";
            }

            if (exceptionMessage != "Wrong parameters: \n")
            {
                throw new ArgumentException(exceptionMessage);
            }
            
            Id = id;
            Password = password;
            User = user;
        }
    }
}