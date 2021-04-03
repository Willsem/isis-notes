using System;
using System.Collections.Generic;

namespace ISISNotesBackend.DataBase.Models
{
    public class FileType
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        
        public ICollection<File> Files { get; set; }
        
        public FileType()
        {
        }
        
        public FileType(Guid id, 
            string type)
        {
            Id = id;
            Type = type;
        }
        
        public FileType(string type)
            : this(Guid.NewGuid(), type)
        {
        }
    }
}