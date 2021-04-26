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
            var userNotes = _dbContext.UserNotes
                .Include(un => un.Note)
                    .ThenInclude(n => n.TextNote)
                .Include(un => un.User)
                    .ThenInclude(u => u.Passcode)
                .Include(un => un.User)
                    .ThenInclude(u => u.UserPhoto)
                .Where(n => n.UserId == userId)
                .OrderBy(un => un.Note.ChangingDate)
                .ToList();
            List<CoreModels.Note> coreNotes = new List<CoreModels.Note>();
            
            foreach (var userNote in userNotes)
            {
                coreNotes.Add(new CoreModels.Note(userNote.NoteId.ToString(), 
                    userNote.Note.Header,
                    userRightsToStr(userNote.Rights))
                  );
            }

            return coreNotes;
        }

        public CoreModels.Note CreateNote(Guid userId, string name)
        {
            var note = new DbModels.Note(name, DateTime.Now, DateTime.Now);
            var textNote = new DbModels.TextNote(note.Id, "");
            var user = _dbContext.Users
                .Include(u => u.Passcode)
                .Include(u => u.UserPhoto)
                .First(u => u.Id == userId);
            var userNote = new DbModels.UserNote(DbModels.Enums.UserRights.author, 
                userId, user, 
                note.Id, 
                note);
            
            _dbContext.Notes.Add(note);
            _dbContext.TextNotes.Add(textNote);
            _dbContext.UserNotes.Add(userNote);
            _dbContext.SaveChanges();
            
            return new CoreModels.Note(note.Id.ToString(), 
                note.Header, 
                "author");
        }

        public IEnumerable<CoreModels.INoteContent> GetNoteContent(Guid userId, Guid noteId)
        {
            var userNote = _dbContext.UserNotes
                .Include(un => un.Note)
                    .ThenInclude(n => n.TextNote)
                .Include(un => un.User)
                    .ThenInclude(u => u.Passcode)
                .Include(un => un.User)
                    .ThenInclude(u => u.UserPhoto)
                .First(un => un.UserId == userId && un.NoteId == noteId);

            var content = userNote.Note.TextNote.Text;
            
            Regex regexCode = new Regex(@"(?<code>```(.*?)```)|(?<code>`(.*?)`)", RegexOptions.Singleline);
            Regex regexFiles = new Regex(@"^(?<allstr>!\[(.*?)\]\((?<pathToFile>.*?)\))$", RegexOptions.Multiline);
            
            List<string> noCode = new List<string>(); 
            List<string> code = new List<string>();
            List<CoreModels.INoteContent> contents = new List<CoreModels.INoteContent>();
            
            int i = 0;
            foreach (Match m in regexCode.Matches(content))
            {
                code.Add(m.Groups["code"].Value);
                noCode.Add(content.Substring(i, m.Groups["code"].Index - i));
                i = m.Groups["code"].Index + m.Groups["code"].Length;
            }
            noCode.Add(content.Substring(i, content.Length - i));

            i = 0;
            while (i < noCode.Count)
            {
                int j = 0;
                foreach (Match m in regexFiles.Matches(noCode[i]))
                {
                    var dbFile = _dbContext.Files
                        .Include(f => f.FileType)
                        .First(f => f.FilePath == m.Groups["pathToFile"].Value);
                    var file = new CoreModels.NoteFileContent(noteId.ToString(),
                        "file",
                        dbFile.FilePath,
                        dbFile.FileType.Type,
                        dbFile.Id.ToString());
                    
                    contents.Add(file);
                    contents.Add(new CoreModels.NoteTextContent(noteId.ToString(), 
                        "text", 
                        noCode[i].Substring(j, m.Groups["allstr"].Index - j)));
                    j = m.Groups["allstr"].Index + m.Groups["allstr"].Length;
                }
                contents.Add(new CoreModels.NoteTextContent(noteId.ToString(), 
                    "text", 
                    noCode[i].Substring(j, noCode[i].Length - j)));

                if (i < code.Count)
                    contents.Add(new CoreModels.NoteTextContent(noteId.ToString(), 
                        "text", 
                        code[i]));
                i++;
            }

            return contents.ToArray();
        }

        public CoreModels.NoteAllContent ChangeNoteText(Guid userId, Guid noteId, CoreModels.INoteContent[] noteContent)
        {
            string dbContent = "";
            
            foreach (var content in noteContent)
            {
                if (content.Type == "text")
                {
                    var textContent = (CoreModels.NoteTextContent) content;
                    dbContent += textContent.Text;
                    Console.WriteLine(textContent.Text);
                }
                else if (content.Type == "file")
                {
                    var fileContent = (CoreModels.NoteFileContent) content;
                    dbContent += $"![{fileContent.FileId}]({fileContent.FileName})\n";
                }
            }

            var userNote = _dbContext.UserNotes
                .Include(un => un.Note)
                    .ThenInclude(n => n.TextNote)
                .Include(un => un.User)
                    .ThenInclude(u => u.Passcode)
                .Include(un => un.User)
                    .ThenInclude(u => u.UserPhoto)
                .First(un => un.UserId == userId && un.NoteId == noteId);

            userNote.Note.TextNote.Text = dbContent;
            _dbContext.Entry(userNote).State = EntityState.Modified;
            _dbContext.SaveChanges();
            
            return new CoreModels.NoteAllContent(new CoreModels.Note(noteId.ToString(), 
                userNote.Note.Header,
                userRightsToStr(userNote.Rights)), 
                noteContent);
        }

        public CoreModels.NoteAllContent ChangeNoteName(Guid userId, Guid noteId, string name)
        {
            var userNote = _dbContext.UserNotes
                .Include(un => un.Note)
                    .ThenInclude(n => n.TextNote)
                .Include(un => un.User)
                    .ThenInclude(u => u.Passcode)
                .Include(un => un.User)
                    .ThenInclude(u => u.UserPhoto)
                .First(un => un.UserId == userId && un.NoteId == noteId);

            userNote.Note.Header = name;
            _dbContext.Entry(userNote).State = EntityState.Modified;
            _dbContext.SaveChanges();
            
            return new CoreModels.NoteAllContent(new CoreModels.Note(noteId.ToString(), 
                    userNote.Note.Header,
                    userRightsToStr(userNote.Rights)), 
                GetNoteContent(userId, noteId) as CoreModels.INoteContent[]);
        }

        public CoreModels.Note DeleteNote(Guid userId, Guid noteId)
        {
            var userNote = _dbContext.UserNotes
                .Include(un => un.Note)
                    .ThenInclude(n => n.TextNote)
                .Include(un => un.User)
                    .ThenInclude(u => u.Passcode)
                .Include(un => un.User)
                    .ThenInclude(u => u.UserPhoto)
                .First(un => un.UserId == userId && un.NoteId == noteId);

            _dbContext.UserNotes.Remove(userNote);
            _dbContext.Notes.Remove(userNote.Note);
            _dbContext.SaveChanges();
            
            return new CoreModels.Note(userNote.NoteId.ToString(), 
                userNote.Note.Header,
                userRightsToStr(userNote.Rights));
        }

        public CoreModels.NoteFileContent AddFile(Guid userId, CoreModels.NoteFileContent file)
        {
            var typeFile = _dbContext.FileTypes
                .First(ft => ft.Type == file.FileType);

            if (typeFile == null)
            {
                typeFile = new DbModels.FileType(file.FileType);
                _dbContext.FileTypes.Add(typeFile);
            }

            var dbFile = new DbModels.File(file.FileName, 
                typeFile.Id, 
                typeFile, 
                Guid.Parse(file.NoteId));

            var textNote = _dbContext.TextNotes
                .Include(tn => tn.Note)
                .First(tn => tn.Id == Guid.Parse(file.NoteId));
            
            textNote.Text += $"![{file.FileId}]({file.FileName})\n";
            
            _dbContext.Entry(textNote).State = EntityState.Modified;
            _dbContext.Files.Add(dbFile);
            _dbContext.SaveChanges();
            
            return new CoreModels.NoteFileContent(dbFile.TextNoteId.ToString(),
                "file",
                dbFile.FilePath,
                dbFile.FileType.Type,
                dbFile.Id.ToString());
        }

        public CoreModels.NoteFileContent GetFile(Guid userId, Guid fileId)
        {
            DbModels.File file = _dbContext.Files
                .Include(f => f.FileType)
                .First(f => f.Id == fileId);
            
            return new CoreModels.NoteFileContent(file.TextNoteId.ToString(),
                "file",
                file.FilePath,
                file.FileType.Type,
                file.Id.ToString());
        }

        public CoreModels.NoteFileContent GetFileByName(string filename)
        {
            DbModels.File file = _dbContext.Files
                .Include(f => f.FileType)
                .First(f => f.FilePath == filename);
            
            return new CoreModels.NoteFileContent(file.TextNoteId.ToString(),
                "file",
                file.FilePath,
                file.FileType.Type,
                file.Id.ToString());
        }

        public CoreModels.NoteFileContent DeleteFile(Guid userId, Guid fileId)
        {
            DbModels.File file = _dbContext.Files
                .Include(f => f.FileType)
                .First(f => f.Id == fileId);

            _dbContext.Files.Remove(file);
            _dbContext.SaveChanges();
            
            return new CoreModels.NoteFileContent(file.TextNoteId.ToString(),
                "file",
                file.FilePath,
                file.FileType.Type,
                file.Id.ToString());
        }

        private string userRightsToStr(DbModels.Enums.UserRights userRights)
        {
            string rights;
            if (userRights.HasFlag(DbModels.Enums.UserRights.author))
                rights = "author";
            else if (userRights.HasFlag(DbModels.Enums.UserRights.write))
                rights = "write";
            else
                rights = "read";
            return rights;
        }
    }
}