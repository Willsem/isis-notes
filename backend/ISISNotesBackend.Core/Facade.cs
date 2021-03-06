using System;
using System.IO;
using System.Linq;
using ISISNotesBackend.Core.Models;
using ISISNotesBackend.Core.Models.Enums;
using ISISNotesBackend.Core.Repositories;

namespace ISISNotesBackend.Core
{
    /// <inheritdoc cref="IFacade"/>
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
            return _noteRepository.GetUserNotes(Guid.Parse(userId)).ToArray();
        }

        public Note CreateNote(string userId, string name)
        {
            try
            {
                return _noteRepository.CreateNote(Guid.Parse(userId), name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new Exception("Cannot create note.\n");
            }
        }

        public INoteContent[] GetNoteContent(string userId, string noteId)
        {
            if (_rightsRepository.CanUserReadNote(Guid.Parse(userId), Guid.Parse(noteId)))
                return _noteRepository.GetNoteContent(Guid.Parse(userId), Guid.Parse(noteId)) as INoteContent[];
            else
                throw new Exception("No access to read note.\n");
        }

        public NoteAllContent ChangeNoteText(string userId, string noteId, INoteContent[] noteContent)
        {
            if (_rightsRepository.CanUserEditNote(Guid.Parse(userId), Guid.Parse(noteId)))
            {
                Console.WriteLine("aaaa");
                return _noteRepository.ChangeNoteText(Guid.Parse(userId), Guid.Parse(noteId), noteContent);
            }
            else
                throw new Exception("No access to edit note.\n");
        }

        public NoteAllContent ChangeNoteName(string userId, string noteId, string name)
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
            Console.WriteLine(name);
            try
            {
                path = GetFilePath(path, file.File.FileType);
            }
            catch (Exception)
            {
                throw new Exception("Incorrect file type.\n");
            }

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
                dirInfo.Create();
            File.WriteAllBytes($"{path}/{name}", file.Content);

            file.File.FileName = name;
            return _noteRepository.AddFile(Guid.Parse(userId), file.File);
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
            try
            {
                return _userRepository.CreateUser(userWithLogin);
            }
            catch (Exception)
            {
                throw new Exception("Cannot create user.\n");
            }
        }

        public User ChangeUser(UserWithLoginAndAvatar userWithLoginAndAvatar, string path)
        {
            string name = "";
            if (userWithLoginAndAvatar.AvatarContent != null)
            {
                name = $"{userWithLoginAndAvatar.User.Username}" +
                              $".{userWithLoginAndAvatar.User.Avatar.Split('.').Last()}";
                path += "/avatars";

                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                    dirInfo.Create();
                File.WriteAllBytes($"{path}/{name}", userWithLoginAndAvatar.AvatarContent);
            }

            return _userRepository.ChangeUser(userWithLoginAndAvatar, $"{path}/{name}");
        }

        public Session CreateSession(string token, string userId)
        {
            return _userRepository.CreateSession(token, userId);
        }
        public Session DeleteSession(string id)
        {
            return _userRepository.DeleteSession(id);
        }

        public User? EnterUser(string name, string password)
        {
            return _userRepository.EnterUser(name, password);
        }

        public NoteAccessRight CreateUserNote(string changeUserId, string userId, string noteId, string userRights)
        {
            if (_rightsRepository.CanUserAddUsersToNote(Guid.Parse(userId), Guid.Parse(noteId)))
                return _userNoteRepository.CreateUserNote(Guid.Parse(changeUserId), Guid.Parse(userId), Guid.Parse(noteId), userRights);
            else
                throw new Exception("No access to add users to note.\n");
        }

        public NoteAccessRight ChangeUserNote(string changeUserId, string userId, string noteId, string userRights)
        {
            if (_rightsRepository.CanUserDeleteNote(Guid.Parse(userId), Guid.Parse(noteId)))
                return _userNoteRepository.ChangeUserNote(Guid.Parse(changeUserId), Guid.Parse(userId), Guid.Parse(noteId), userRights);
            else
                throw new Exception("No access to edit user rights to note.\n");
        }

        public NoteAccessRight DeleteUserNote(string changeUserId, string userId, string noteId)
        {
            if (_rightsRepository.CanUserDeleteNote(Guid.Parse(userId), Guid.Parse(noteId)))
                return _userNoteRepository.DeleteUserNote(Guid.Parse(changeUserId), Guid.Parse(userId), Guid.Parse(noteId));
            else
                throw new Exception("No access to delete user from note.\n");
        }

        public byte[] GetAvatar(string userId, string path)
        {
            var user = _userRepository.GetUser(userId);
            
            if (user.Avatar == null)
                throw new Exception("No avatar.\n");

            path += "/avatars";
            FileInfo fileInfo = new FileInfo($"{path}/{user.Avatar}");
            if (fileInfo.Exists) 
                return File.ReadAllBytes($"{path}/{user.Avatar}");
            else
                throw new Exception("No file");
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