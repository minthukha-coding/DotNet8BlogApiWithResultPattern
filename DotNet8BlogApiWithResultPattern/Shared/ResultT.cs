﻿namespace DotNet8BlogApiWithResultPattern.Shared;
public class Result<T> : Result
{
    public T? Data { get; }

    public Result(bool isSuccess,Error error,T? data) : base(isSuccess, error)
    {
        Data = data;    
    }
}