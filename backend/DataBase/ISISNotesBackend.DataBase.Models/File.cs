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

        public File()
        {
        }
        
        public File(Guid id, 
            string filePath,
            Guid fileTypeId,
            FileType fileType)
        {
            Id = id;
            FilePath = filePath;
            FileTypeId = fileTypeId;
            FileType = fileType;
        }
        
        public File(string filePath,
            Guid fileTypeId,
            FileType fileType)
            : this(Guid.NewGuid(), filePath, fileTypeId, fileType)
        {
        }
    }
}