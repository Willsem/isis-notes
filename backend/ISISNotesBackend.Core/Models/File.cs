using System;

namespace ISISNotesBackend.Core.Models
{
    public class File
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public FileType FileType { get; set; }

        public File(Guid id, string filePath, FileType fileType)
        {
            string exceptionMessage = "Wrong parameters: \n";
            
            if (fileType == null)
            {
                exceptionMessage += $"'{nameof(fileType)}': Type of file can't be null \n";
            }
            if (string.IsNullOrEmpty(filePath))
            {
                exceptionMessage += $"'{nameof(filePath)}': Path of file can't be null \n";
            }

            if (exceptionMessage != "Wrong parameters: \n")
            {
                throw new ArgumentException(exceptionMessage);
            }
            
            Id = id;
            FilePath = filePath;
            FileType = fileType;
        }
    }
}