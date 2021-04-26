using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core.Models
{
    public interface INoteContent
    {
        public string NoteId { get; set; }
        public string Type { get; set; }
    }
}