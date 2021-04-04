using System;
using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core.Models
{
    public class UserNote
    {
        public Guid Id { get; set; }
        public UserRights Rights { get; set; }
        public User User { get; set; }
        public Note Note { get; set; }

        public UserNote(Guid id, UserRights rights,
            User user, Note note)
        {
            string exceptionMessage = "Wrong parameters: \n";
            
            if (!Enum.IsDefined(typeof(UserRights), rights))
            {
                exceptionMessage += $"'{nameof(rights)}': Incorrect value of rights ('{rights}') \n";
            }
            if (user == null)
            {
                exceptionMessage += $"'{nameof(user)}': Reference to User can't be null \n";
            }
            if (note == null)
            {
                exceptionMessage += $"'{nameof(note)}': Reference to Note can't be null \n";
            }

            if (exceptionMessage != "Wrong parameters: \n")
            {
                throw new ArgumentException(exceptionMessage);
            }
            
            Id = id;
            Rights = rights;
            User = user;
            Note = note;
        }
    }
}