using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISISNotesBackend.DataBase.Models
{
    public class TextNote
    {
        [Key]
        [ForeignKey("Note")]
        public Guid Id { get; set; }
        public string Text { get; set; }
        
        public Note Note { get; set; }
        public ICollection<File> Files { get; set; }

        public TextNote()
        {
        }

        public TextNote(Guid id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}