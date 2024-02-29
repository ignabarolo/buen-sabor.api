
namespace Application.Exceptions;

public class FileException : FileNotFoundException
{

    public FileException(string fileName) : base(fileName)
    {
    }
}
