using System;

namespace ISISNotesBackend.Core.Models
{
    public class UserPhoto
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        
        public User User { get; set; }

        public UserPhoto(Guid id, string image, User user)
        {
            string exceptionMessage = "Wrong parameters: \n";
            
            if (user == null)
            {
                exceptionMessage += $"'{nameof(user)}': Reference to User can't be null \n";
            }
            
            if (exceptionMessage != "Wrong parameters: \n")
            {
                throw new ArgumentException(exceptionMessage);
            }

            Id = id;
            Image = image;
            User = user;
        }
    }
}