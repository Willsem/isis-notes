using ISISNotesBackend.Core.Models;
using ISISNotesBackend.Core.Models.Enums;
using ISISNotesBackend.Core.Repositories;

namespace ISISNotesBackend.Core
{
    public class Facade : IFacade
    {
        private readonly INoteRepository _noteRepository;
        private readonly IUserNoteRepository _userNoteRepository;
        private readonly IUserRepository _userRepository;

        public Facade(INoteRepository noteRepository,
            IUserNoteRepository userNoteRepository,
            IUserRepository userRepository)
        {
            _noteRepository = noteRepository;
            _userNoteRepository = userNoteRepository;
            _userRepository = userRepository;
        }
            
        public Note[] GetUserNotes(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Note CreateNote(string userId, string name)
        {
            throw new System.NotImplementedException();
        }

        public NoteContent[] GetNoteContent(string userId, string noteId, string path)
        {
            throw new System.NotImplementedException();
        }

        public NoteWithContent ChangeNoteText(string userId, string noteId, NoteContent[] noteContent, string path)
        {
            throw new System.NotImplementedException();
        }

        public NoteWithContent ChangeNoteName(string userId, string noteId, string name)
        {
            throw new System.NotImplementedException();
        }

        public Note DeleteNote(string userId, string noteId)
        {
            throw new System.NotImplementedException();
        }

        public NoteFileContent AddFile(string userId, FileWithContent file, string path)
        {
            throw new System.NotImplementedException();
        }

        public byte[] GetFile(string userId, string fileId, string path)
        {
            throw new System.NotImplementedException();
        }

        public NoteFileContent DeleteFile(string userId, string fileId)
        {
            throw new System.NotImplementedException();
        }

        public User[] GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public User CreateUser(UserWithLogin userWithLogin)
        {
            throw new System.NotImplementedException();
        }

        public User ChangeUser(UserWithLoginAndAvatar userWithLoginAndAvatar, string path)
        {
            throw new System.NotImplementedException();
        }

        public User? EnterUser(string name, string password)
        {
            throw new System.NotImplementedException();
        }

        public NoteAccessRight CreateUserNote(string changeUserId, string userId, string noteId, UserRights userRights)
        {
            throw new System.NotImplementedException();
        }

        public NoteAccessRight ChangeUserNote(string changeUserId, string userId, string noteId, UserRights userRights)
        {
            throw new System.NotImplementedException();
        }

        public NoteAccessRight DeleteUserNote(string changeUserId, string userId, string noteId)
        {
            throw new System.NotImplementedException();
        }
    }
}