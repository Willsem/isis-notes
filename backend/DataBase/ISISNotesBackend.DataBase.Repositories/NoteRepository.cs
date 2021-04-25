using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ISISNotesBackend.Core.Repositories;
using ISISNotesBackend.DataBase.NpgsqlContext;
using Microsoft.EntityFrameworkCore;
using DbModels = ISISNotesBackend.DataBase.Models;
using CoreModels = ISISNotesBackend.Core.Models;

namespace ISISNotesBackend.DataBase.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ISISNotesContext _dbContext;

        public NoteRepository(ISISNotesContext chatServiceContext)
        {
            _dbContext = chatServiceContext;
        }
        public IEnumerable<CoreModels.Note> GetUserNotes(Guid userId)
        {
            throw new NotImplementedException();
        }

        public CoreModels.Note CreateNote(Guid userId, string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CoreModels.NoteContent> GetNoteContent(Guid userId, Guid noteId)
        {
            throw new NotImplementedException();
        }

        public CoreModels.NoteWithContent ChangeNoteText(Guid userId, Guid noteId, CoreModels.NoteContent[] noteContent)
        {
            throw new NotImplementedException();
        }

        public CoreModels.NoteWithContent ChangeNoteName(Guid userId, Guid noteId, string name)
        {
            throw new NotImplementedException();
        }

        public CoreModels.Note DeleteNote(Guid userId, Guid noteId)
        {
            throw new NotImplementedException();        }

        public CoreModels.NoteFileContent AddFile(Guid userId, CoreModels.FileWithContent file)
        {
            throw new NotImplementedException();
        }

        public CoreModels.NoteFileContent GetFile(Guid userId, Guid fileId)
        {
            throw new NotImplementedException();
        }

        public CoreModels.NoteFileContent GetFileByName(string filename)
        {
            throw new NotImplementedException();
        }

        public CoreModels.NoteFileContent DeleteFile(Guid userId, Guid fileId)
        {
            throw new NotImplementedException();
        }
    }
}