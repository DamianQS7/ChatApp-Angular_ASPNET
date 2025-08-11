using System;

namespace API.Shared;

public class Response<T>(bool isSuccess, T data, string? error, string? message)
{
    public bool IsSuccess { get; } = isSuccess;
    public T Data { get; } = data;
    public string? Error { get; } = error;
    public string? Message { get; set; } = message;

    public static Response<T> Success(T data, string? message = "")
        => new(true, data, null, message);

    public static Response<T> Failure(string error) => new(false, default!, error, null);
}
