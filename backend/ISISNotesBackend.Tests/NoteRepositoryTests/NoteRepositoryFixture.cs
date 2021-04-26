using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Moq;
using ISISNotesBackend.DataBase.NpgsqlContext;
using ISISNotesBackend.DataBase.Models;

namespace ISISNotesBackend.Tests.NoteRepositoryTests
{
    public class NoteRepositoryFixture : IDisposable
    {
        protected ISISNotesContext _context;
        
        protected Guid userId;

        protected Guid noteId;

        protected NoteRepositoryFixture()
        {
            userId = Guid.NewGuid();
            noteId = Guid.NewGuid();

            var data = new List<UserNote>
            {
                new UserNote(
                    noteId,
                    DataBase.Models.Enums.UserRights.Author,
                    userId,
                    new User(),
                    noteId,
                    new Note()
                ),
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserNote>>();
            mockSet.As<IQueryable<UserNote>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserNote>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserNote>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserNote>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ISISNotesContext>();
            mockContext.Setup(c => c.UserNotes)
                .Returns(mockSet.Object);
            _context = mockContext.Object;
        }

        public void Dispose() { }
    }
}
