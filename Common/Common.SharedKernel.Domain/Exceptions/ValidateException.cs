namespace Common.SharedKernel.Domain;

public class ValidateException(ErrorResponse error) : Exception(error.Description)
{
    public ErrorResponse Error { get; } = error;
}
