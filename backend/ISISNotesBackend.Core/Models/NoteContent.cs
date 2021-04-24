using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core.Models
{
    public class NoteContent
    {
        public string NoteId { get; set; }
        public Type Type { get; set; }
        
        public NoteContent(string noteId, Type type)
        {
            NoteId = noteId;
            Type = type;
        }
    }
}