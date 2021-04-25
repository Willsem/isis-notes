using ISISNotesBackend.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ISISNotesBackend.DataBase.NpgsqlContext
{
    public class ISISNotesContext : DbContext
    {
        public ISISNotesContext(DbContextOptions<ISISNotesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<File> Files { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Passcode> Passcodes { get; set; }
        public DbSet<TextNote> TextNotes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserNote> UserNotes { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<Session> Sessions { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}