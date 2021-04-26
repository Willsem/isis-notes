using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core.Models
{
    public class NoteFileContent : INoteContent
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileId { get; set; }
        public string NoteId { get; set; }
        public string Type { get; set; }
        
        public NoteFileContent(string noteId, string type, string fileName, string fileType, string fileId)
        {
            NoteId = noteId;
            Type = type;
            FileName = fileName;
            FileType = fileType;
            FileId = fileId;
        }
    }
}