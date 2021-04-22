using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core.Models
{
    public class Note
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public UserRights Mode { get; set; }

        public Note(string id, string name, UserRights mode)
        {
            Id = id;
            Name = name;
            Mode = mode;
        }
    }
}