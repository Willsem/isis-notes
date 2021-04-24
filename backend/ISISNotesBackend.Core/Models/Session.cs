using System;

namespace ISISNotesBackend.Core.Models
{
    public class Session
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public User User { get; set; }
        public DateTime Timestamp { get; set; }

        public Session(string id, string token, User user, DateTime timestamp)
        {
            Id = id;
            Token = token;
            User = user;
            Timestamp = timestamp;
        }
    }
}