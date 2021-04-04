using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISISNotesBackend.DataBase.Models
{
    public class UserPhoto
    {
        [Key]
        [ForeignKey("User")]
        public Guid Id { get; set; }
        public string Image { get; set; }
        
        public User User { get; set; }

        public UserPhoto()
        {
        }
        
        public UserPhoto(Guid id, string image)
        {
            Id = id;
            Image = image;
        }
    }
}