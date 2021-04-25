using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ISISNotesBackend.DataBase.Models
{
    public class Session
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }

        public Session(Guid id, 
            Guid userId, 
            string token, 
            DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Token = token;
            CreatedAt = createdAt;
        }
        
        public Session(Guid userId, 
            string token, 
            DateTime createdAt) 
            : this(Guid.NewGuid(), userId, token, createdAt)
        {
        }
    }
}