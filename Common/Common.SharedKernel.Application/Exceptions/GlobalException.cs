using Common.SharedKernel.Domain;

namespace Common.SharedKernel.Application;

public sealed class GlobalException : Exception
{
    public GlobalException(string requestName, ErrorResponse? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

     public GlobalException(string requestName,  Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
    }

    public string RequestName { get; }
    public ErrorResponse? Error { get; }
}