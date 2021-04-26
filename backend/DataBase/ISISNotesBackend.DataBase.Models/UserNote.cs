using System;
using ISISNotesBackend.DataBase.Models.Enums;

namespace ISISNotesBackend.DataBase.Models
{
    public class UserNote
    {
        public Guid Id { get; set; }
        public UserRights Rights { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid NoteId { get; set; }
        public Note Note { get; set; }

        UserNote()
        {
        }

        public UserNote(Guid id, UserRights rights, Guid userId, User user, Guid noteId, Note note)
        {
            Id = id;
            Rights = rights;
            UserId = userId;
            User = user;
            NoteId = noteId;
            Note = note;
        }
        
        public UserNote(UserRights rights, Guid userId, User user, Guid noteId, Note note)
            :this(Guid.NewGuid(), rights, userId, user, noteId, note)
        {
        }
    }
}