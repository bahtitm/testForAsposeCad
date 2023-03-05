namespace Shared
{
    public class DontSaveFileException : Exception
    {
        public DontSaveFileException()
           : base()
        {
        }
        public DontSaveFileException(string message)
            : base(message)
        {
        }
        public DontSaveFileException(string message, Exception innerException)
           : base(message, innerException)
        {
        }
        public string? FileName { get; set; }
        public string Path { get; set; }
        public DontSaveFileException(string name, string path)
            : base($"File \"{name}\" ) dont save. path:{path}")
        {
            FileName = name;
            Path = path;

        }
    }
}