using System;

namespace ISISNotesBackend.Core.Models.Enums
{
    [Flags]
    public enum UserRights : int
    {
        None = 0,
        Read = 1,
        Write = 2,
        Author = 4
    };
}