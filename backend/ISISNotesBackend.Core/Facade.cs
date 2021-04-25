using System;
using System.IO;
using System.Linq;
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
        private readonly IRightsRepository _rightsRepository;

        public Facade(INoteRepository noteRepository,
            IUserNoteRepository userNoteRepository,
            IUserRepository userRepository,
            IRightsRepository rightsRepository)
        {
            _noteRepository = noteRepository;
            _userNoteRepository = userNoteRepository;
            _userRepository = userRepository;
            _rightsRepository = rightsRepository;
        }
            
        public Note[] GetUserNotes(string userId)
        {
            return _noteRepository.GetUserNotes(Guid.Parse(userId)) as Note[];
        }

        public Note CreateNote(string userId, string name)
        {
            return _noteRepository.CreateNote(Guid.Parse(userId), name);
        }

        public NoteContent[] GetNoteContent(string userId, string noteId, string path)
        {
            if (_rightsRepository.CanUserReadNote(Guid.Parse(userId), Guid.Parse(noteId)))
                return _noteRepository.GetNoteContent(Guid.Parse(userId), Guid.Parse(noteId)) as NoteContent[];
            else
                throw new Exception("No access to read note.\n");
        }

        public NoteWithContent ChangeNoteText(string userId, string noteId, NoteContent[] noteContent, string path)
        {
            if (_rightsRepository.CanUserEditNote(Guid.Parse(userId), Guid.Parse(noteId)))
                return _noteRepository.ChangeNoteText(Guid.Parse(userId), Guid.Parse(noteId), noteContent);
            else
                throw new Exception("No access to edit note.\n");
        }

        public NoteWithContent ChangeNoteName(string userId, string noteId, string name)
        {
            if (_rightsRepository.CanUserEditNote(Guid.Parse(userId), Guid.Parse(noteId)))
                return _noteRepository.ChangeNoteName(Guid.Parse(userId), Guid.Parse(noteId), name);
            else
                throw new Exception("No access to edit note.\n");
        }

        public Note DeleteNote(string userId, string noteId)
        {
            if (_rightsRepository.CanUserDeleteNote(Guid.Parse(userId), Guid.Parse(noteId)))
                return _noteRepository.DeleteNote(Guid.Parse(userId), Guid.Parse(noteId));
            else
                throw new Exception("No access to delete note.\n");
        }

        public NoteFileContent AddFile(string userId, FileWithContent file, string path)
        {
            string name = $"{userId}_" +
                          $"{DateTime.UtcNow:yyyy-MM-dd_h-mm-ss_tt}" +
                          $".{file.File.FileName.Split('.').Last()}";
            
            path = GetFilePath(path, file.File.FileType);

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
                dirInfo.Create();
            File.WriteAllBytes($"{path}/{name}", file.Content);

            file.File.FileName = name;
            return _noteRepository.AddFile(Guid.Parse(userId), file);
        }

        public byte[] GetFile(string userId, string fileId, string path)
        {
            NoteFileContent file = _noteRepository.GetFile(Guid.Parse(userId), Guid.Parse(fileId));

            path = GetFilePath(path, file.FileType);

            FileInfo fileInfo = new FileInfo($"{path}/{file.FileName}");
            if (fileInfo.Exists) 
                return File.ReadAllBytes($"{path}/{file.FileName}");
            else
                throw new Exception("No file");
        }

        public NoteFileContent DeleteFile(string userId, string fileId, string path)
        {
            NoteFileContent file = _noteRepository.DeleteFile(Guid.Parse(userId), Guid.Parse(fileId));

            path = GetFilePath(path, file.FileType);
            
            FileInfo fileInfo = new FileInfo($"{path}/{file.FileName}");
            if (fileInfo.Exists)
                File.Delete($"{path}/{file.FileName}");

            return file;
        }

        public User[] GetAllUsers()
        {
            return _userRepository.GetAllUsers() as User[];
        }

        public User CreateUser(UserWithLogin userWithLogin)
        {
            return _userRepository.CreateUser(userWithLogin);
        }

        public User ChangeUser(UserWithLoginAndAvatar userWithLoginAndAvatar, string path)
        {
            string name = $"{userWithLoginAndAvatar.User.Username}_" +
                   $".{userWithLoginAndAvatar.User.Avatar.Split('.').Last()}";
            path += "/avatars";
                
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
                dirInfo.Create();
            File.WriteAllBytes($"{path}/{name}", userWithLoginAndAvatar.AvatarContent);

            return _userRepository.ChangeUser(userWithLoginAndAvatar, $"{path}/{name}");
        }

        public User? EnterUser(string name, string password)
        {
            if (_rightsRepository.CorrectUsernameAndPassword(name, password))
                return _userRepository.GetUserByName(name);
            else
                return null;
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

        private string GetFilePath(string path, string type)
        {
            switch (type)
            {
                case "video":
                    path += "/videos";
                    break;
                case "audio":
                    path += "/audios";
                    break;
                case "image":
                    path += "/images";
                    break;
                case "document":
                    path += "/documents";
                    break;
                default:
                    throw new ArgumentException("Incorrect type of file");
            }

            return path;
        }
    }
}