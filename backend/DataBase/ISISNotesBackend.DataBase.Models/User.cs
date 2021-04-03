using System;

namespace ISISNotesBackend.DataBase.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        
        public Passcode Passcode { get; set; }
        public UserPhoto UserPhoto { get; set; }
    }
}