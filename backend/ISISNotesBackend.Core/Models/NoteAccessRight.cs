using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core.Models
{
    public class NoteAccessRight
    {
        public string NoteId { get; set; }
        public string UserId { get; set; }
        public UserRights Rights { get; set; }

        public NoteAccessRight(string noteId, string userId, UserRights rights)
        {
            NoteId = noteId;
            UserId = userId;
            Rights = rights;
        }
    }
}