using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core.Models
{
    public class NoteFileContent : NoteContent
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileId { get; set; }
        
        public NoteFileContent(string noteId, Type type, string fileName, string fileType, string fileId) 
            : base(noteId, type)
        {
            FileName = fileName;
            FileType = fileType;
            FileId = fileId;
        }
    }
}