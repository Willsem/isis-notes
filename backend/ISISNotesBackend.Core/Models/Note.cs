using System;

namespace ISISNotesBackend.Core.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ChangingDate { get; set; }
        public TextNote TextNote { get; set; }

        public Note(Guid id, string header, DateTime creationDate,
            DateTime changingDate, TextNote textNote)
        {
            string exceptionMessage = "Wrong parameters: \n";
            
            if (creationDate > DateTime.Today)
            {
                exceptionMessage += $"'{nameof(creationDate)}': Date of creation can't be from future \n";
            }
            if (changingDate > DateTime.Today)
            {
                exceptionMessage += $"'{nameof(changingDate)}': Date of changes can't be from future \n";
            }
            if (changingDate < creationDate)
            {
                exceptionMessage += $"'{nameof(changingDate)}': Date of changes can't be less then date of creation \n";
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
            Header = header;
            CreationDate = creationDate;
            ChangingDate = changingDate;
            TextNote = textNote;
        }
    }
}