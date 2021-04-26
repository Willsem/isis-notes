using Xunit;
using ISISNotesBackend.DataBase.Repositories;

namespace ISISNotesBackend.Tests.NoteRepositoryTests
{
    public class NoteRepositoryTests : NoteRepositoryFixture
    {
        [Fact]
        public void CorrectTest()
        {
            var builder = new NoteRepositoryBuilder();
            builder.AddContext(_context);
            var repository = builder.GetRepository();
        }
    }
}
