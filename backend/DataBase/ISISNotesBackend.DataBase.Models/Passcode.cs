using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISISNotesBackend.DataBase.Models
{
    public class Passcode
    {
        [Key]
        [ForeignKey("User")]
        public Guid Id { get; set; }
        public string Password { get; set; }
        
        public User User { get; set; }
    }
}