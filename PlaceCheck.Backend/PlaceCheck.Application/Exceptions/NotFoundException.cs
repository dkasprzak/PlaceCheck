﻿namespace PlaceCheck.Application.Exceptions;

public class NotFoundException : Exception
{
    public string Message { get; private set; }
    
    public NotFoundException(string message)
    {
        Message = message;
    }
}
