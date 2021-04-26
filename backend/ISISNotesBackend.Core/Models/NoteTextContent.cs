using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core.Models
{
    public class NoteTextContent : INoteContent
    {
        public string NoteId { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        
        public NoteTextContent(string noteId, string type, string text)
        {
            NoteId = noteId;
            Type = type;
            Text = text;
        }
    }
}