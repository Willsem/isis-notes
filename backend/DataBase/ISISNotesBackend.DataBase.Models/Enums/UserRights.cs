using System;

namespace ISISNotesBackend.DataBase.Models.Enums
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