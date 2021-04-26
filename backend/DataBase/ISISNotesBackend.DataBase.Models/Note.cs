using System;
using System.Collections.Generic;

namespace ISISNotesBackend.DataBase.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ChangingDate { get; set; }
        
        public TextNote TextNote { get; set; }
        public ICollection<UserNote> UserNotes { get; set; }

        public Note()
        {
        }
        
        public Note(Guid id, string header, DateTime creationDate, DateTime changingDate)
        {
            Id = id;
            Header = header;
            CreationDate = creationDate;
            ChangingDate = changingDate;
        }
        
        public Note(string header, DateTime creationDate, DateTime changingDate)
            : this(Guid.NewGuid(), header, creationDate, changingDate)
        {
        }
    }
}