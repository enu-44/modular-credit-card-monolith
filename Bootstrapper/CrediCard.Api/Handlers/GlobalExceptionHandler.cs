using Common.SharedKernel.Application;
using Common.SharedKernel.Domain;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CrediCard.Api;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not GlobalException) return false;
        ExceptionBase exceptionBase = exception.InnerException switch
        {
            ValidateException => buildException(exception.InnerException),
            EntityNotFoundException => buildException(exception.InnerException),
            _ => buildException(exception)
        };
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        var jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            Formatting = Formatting.Indented
        };
        await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(exceptionBase, jsonSettings));
        return true;
    }

    public ExceptionBase buildException(Exception exception){
        ExceptionBase exceptionBase = exception switch
        {
            ValidateException => new ExceptionBase
            {
                Key = ((ValidateException)exception).Error.Code,
                Message = exception.Message,
                Detail = ((ValidateException)exception).Error.ToString(),
            },
            EntityNotFoundException => new ExceptionBase
            {
                Key = "EntityNotFound",
                Message = exception.Message,
            },
            _ => new ExceptionBase
            {
                Key = "Unknow exception",
                Message = exception.Message
            }
        };
        return exceptionBase;
    }
}
