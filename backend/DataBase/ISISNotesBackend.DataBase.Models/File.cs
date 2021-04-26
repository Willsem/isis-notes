using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISISNotesBackend.DataBase.Models
{
    public class File
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        
        [ForeignKey("FileType")]
        public Guid FileTypeId { get; set; }
        public FileType FileType { get; set; }
        
        [ForeignKey("TextNote")]
        public Guid TextNoteId { get; set; }

        public File()
        {
        }
        
        public File(Guid id, 
            string filePath,
            Guid fileTypeId,
            FileType fileType,
            Guid textNoteId)
        {
            Id = id;
            FilePath = filePath;
            FileTypeId = fileTypeId;
            FileType = fileType;
            TextNoteId = textNoteId;
        }
        
        public File(string filePath,
            Guid fileTypeId,
            FileType fileType,
            Guid textNoteId)
            : this(Guid.NewGuid(), filePath, fileTypeId, fileType, textNoteId)
        {
        }
    }
}