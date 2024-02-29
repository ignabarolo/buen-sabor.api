
namespace Application.Exceptions;

public class NotPermitted : UnauthorizedAccessException
{
    public NotPermitted(string message) : base(message) { }

    public NotPermitted(string message, Exception inner) : base(message, inner) { }
}
