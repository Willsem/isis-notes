using System;

namespace ISISNotesBackend.Core.Models
{
    public class TextNote
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Note Note { get; set; }

        public TextNote(Guid id, string text, Note note)
        {
            string exceptionMessage = "Wrong parameters: \n";
            
            if (note == null)
            {
                exceptionMessage += $"'{nameof(note)}': Reference to Note can't be null \n";
            }
            if (text == null)
            {
                exceptionMessage += $"'{nameof(text)}': Text can't be null \n";
            }

            if (exceptionMessage != "Wrong parameters: \n")
            {
                throw new ArgumentException(exceptionMessage);
            }
            
            Id = id;
            Text = text;
            Note = note;
        }
    }
}