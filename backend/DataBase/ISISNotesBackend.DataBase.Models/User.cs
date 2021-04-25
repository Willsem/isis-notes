using System;
using System.Collections.Generic;

namespace ISISNotesBackend.DataBase.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        
        public Passcode Passcode { get; set; }
        public UserPhoto? UserPhoto { get; set; }
        
        public ICollection<UserNote> UserNotes { get; set; }
        public ICollection<Session> Sessions { get; set; }

        public User()
        {
        }

        public User(Guid id, 
            string name, 
            string email, 
            DateTime registrationDate)
        {
            Id = id;
            Name = name;
            Email = email;
            RegistrationDate = registrationDate;
        }
        
        public User(string name, 
            string email, 
            DateTime registrationDate)
            : this(Guid.NewGuid(), name, email, registrationDate)
        {
        }
    }
}