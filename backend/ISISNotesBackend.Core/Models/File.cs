using System;

namespace ISISNotesBackend.Core.Models
{
    public class File
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public FileType FileType { get; set; }
        public TextNote TextNote { get; set; }

        public File(Guid id, string filePath, FileType fileType, TextNote textNote)
        {
            string exceptionMessage = "Wrong parameters: \n";
            
            if (fileType == null)
            {
                exceptionMessage += $"'{nameof(fileType)}': Reference to FileType can't be null \n";
            }
            if (string.IsNullOrEmpty(filePath))
            {
                exceptionMessage += $"'{nameof(filePath)}': Path of file can't be null \n";
            }
            if (textNote == null)
            {
                exceptionMessage += $"'{nameof(textNote)}': Reference to TextNote can't be null \n";
            }

            if (exceptionMessage != "Wrong parameters: \n")
            {
                throw new ArgumentException(exceptionMessage);
            }
            
            Id = id;
            FilePath = filePath;
            FileType = fileType;
            TextNote = textNote;
        }
    }
}