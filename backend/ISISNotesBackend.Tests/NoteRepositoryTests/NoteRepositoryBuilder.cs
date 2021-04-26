using ISISNotesBackend.DataBase.NpgsqlContext;
using ISISNotesBackend.DataBase.Repositories;

namespace ISISNotesBackend.Tests.NoteRepositoryTests
{
    public class NoteRepositoryBuilder
    {
        private ISISNotesContext _context;

        public NoteRepositoryBuilder() { }

        public void AddContext(ISISNotesContext context)
            => _context = context;

        public NoteRepository GetRepository()
            => new NoteRepository(_context);
    }
}
