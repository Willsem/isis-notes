using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core.Models
{
    public class NoteTextContent : NoteContent
    {
        public string Text { get; set; }
        
        public NoteTextContent(string noteId, Type type, string text) 
            : base(noteId, type)
        {
            Text = text;
        }
    }
}