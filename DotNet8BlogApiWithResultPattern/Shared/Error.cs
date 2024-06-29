﻿namespace DotNet8BlogApiWithResultPattern.Shared;

public class Error
{
    public Error(string message)
    {
        Message = message;
    }
    public string Message { get; set; }
    public static Error None => new(string.Empty);
    public static implicit operator Error(string message) => new(message);
    public static implicit operator string(Error error) => error.Message;
}