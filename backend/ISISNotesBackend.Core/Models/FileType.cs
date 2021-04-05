using System;

namespace ISISNotesBackend.Core.Models
{
    public class FileType
    {
        public Guid Id { get; set; }
        public string Type { get; set; }

        public FileType(Guid id, string type)
        {
            string exceptionMessage = "Wrong parameters: \n";
            
            if (string.IsNullOrEmpty(type))
            {
                exceptionMessage += $"'{nameof(type)}': Type of file can't be null \n";
            }

            if (exceptionMessage != "Wrong parameters: \n")
            {
                throw new ArgumentException(exceptionMessage);
            }
            
            Id = id;
            Type = type;
        }
    }
}