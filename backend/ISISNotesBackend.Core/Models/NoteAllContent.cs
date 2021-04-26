namespace ISISNotesBackend.Core.Models
{
    public class NoteAllContent
    {
        public Note Note { get; set; }
        public INoteContent[] Content { get; set; }

        public NoteAllContent(Note note, INoteContent[] content)
        {
            Note = note;
            Content = content;
        }
    }
}