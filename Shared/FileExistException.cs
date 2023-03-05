namespace Shared
{
    public class FileExistException : Exception
    {
        public FileExistException()
           : base()
        {
        }
        public FileExistException(string message)
            : base(message)
        {
        }
        public FileExistException(string message, Exception innerException)
           : base(message, innerException)
        {
        }
        public string? FileName { get; set; }
        public string Chacksum { get; set; }
        public FileExistException(string name, string chacksum)
            : base($"File \"{name}\" ) was found.{chacksum} is chacksum")
        {
            FileName = name;
            Chacksum = chacksum;

        }
    }
}