using System;
using System.Collections.Generic;

namespace ISISNotesBackend.Core.Models
{
    public class NoteWithContent
    {
        public Note Note { get; set; }
        public NoteTextContent[] TextContent { get; set; }
        public NoteFileContent[] FileContent { get; set; }

        public NoteWithContent(Note note, NoteTextContent[] textContent, NoteFileContent[] fileContent)
        {
            Console.WriteLine("bbbbb");
            Console.WriteLine(textContent);
            Note = note;
            TextContent = textContent;
            FileContent = fileContent;
        }
    }
}