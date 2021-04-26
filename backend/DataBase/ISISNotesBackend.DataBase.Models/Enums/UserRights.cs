using System;

namespace ISISNotesBackend.DataBase.Models.Enums
{
    [Flags]
    public enum UserRights : int
    {
        none = 0,
        read = 1,
        write = 2,
        author = 4
    };
}