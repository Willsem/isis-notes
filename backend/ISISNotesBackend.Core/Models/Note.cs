using System;
using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core.Models
{
    public class Note
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Mode { get; set; }

        public Note(string id, string name, string mode)
        {
            Console.WriteLine("cccc");
            Id = id;
            Name = name;
            Mode = mode;
        }
    }
}