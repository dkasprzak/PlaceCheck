using System.Runtime.InteropServices.JavaScript;

namespace PlaceCheck.Application.Exceptions;

public class ErrorException : Exception
{
    public string Error { get; private set; }
    
    public ErrorException(string error)
    {
        Error = error;
    }
}
