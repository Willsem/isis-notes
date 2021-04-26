namespace ISISNotesBackend.Core.Models
{
    public class FileWithContent
    {
        public NoteFileContent File { get; set; }
        public byte[] Content { get; set; }

        public FileWithContent(NoteFileContent file, byte[] content)
        {
            File = file;
            Content = content;
        }
    }
}