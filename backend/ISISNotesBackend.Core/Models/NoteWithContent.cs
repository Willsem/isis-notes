namespace ISISNotesBackend.Core.Models
{
    public class NoteWithContent
    {
        public Note Note { get; set; }
        public NoteContent[] NoteContent { get; set; }

        public NoteWithContent(Note note, NoteContent[] noteContent)
        {
            Note = note;
            NoteContent = noteContent;
        }
    }
}