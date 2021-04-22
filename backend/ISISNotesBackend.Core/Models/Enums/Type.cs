using System;

namespace ISISNotesBackend.Core.Models.Enums
{
    [Flags]
    public enum Type : int
    {
        None = 0,
        Text = 1,
        File = 2
    };
}