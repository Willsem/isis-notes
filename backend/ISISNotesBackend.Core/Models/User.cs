using System;

namespace ISISNotesBackend.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        
        public Passcode Passcode { get; set; }
        public UserPhoto UserPhoto { get; set; }

        public User(Guid id, string name, string email,
            DateTime registrationDate, Passcode passcode,
            UserPhoto userPhoto)
        {
            string exceptionMessage = "Wrong parameters: \n";
            
            if (string.IsNullOrEmpty(name))
            {
                exceptionMessage += $"'{nameof(name)}': Name of user can't be null \n";
            }
            if (string.IsNullOrEmpty(email))
            {
                exceptionMessage += $"'{nameof(email)}': Email of user can't be null \n";
            }
            if (registrationDate > DateTime.Today)
            {
                exceptionMessage += $"'{nameof(registrationDate)}': Date of registration can't be from future \n";
            }
            if (passcode == null)
            {
                exceptionMessage += $"'{nameof(passcode)}': Reference to Passcode can't be null \n";
            }
            if (userPhoto == null)
            {
                exceptionMessage += $"'{nameof(userPhoto)}': Reference to UserPhoto can't be null \n";
            }

            if (exceptionMessage != "Wrong parameters: \n")
            {
                throw new ArgumentException(exceptionMessage);
            }
            
            Id = id;
            Name = name;
            Email = email;
            RegistrationDate = registrationDate;
            Passcode = passcode;
            UserPhoto = userPhoto;
        }
    }
}