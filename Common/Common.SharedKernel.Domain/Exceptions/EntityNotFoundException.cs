namespace Common.SharedKernel.Domain;
public class EntityNotFoundException(Type entityType, object? id, Exception? innerException) : Exception(CommonErrors.EntityNotFound(entityType, id).Description, innerException)
{
    public Type EntityType { get; set; } = entityType;
    public object? Id { get; set; } = id;
    public EntityNotFoundException(Type entityType) : this(entityType, null, null) { }
    public EntityNotFoundException(Type entityType, object id) : this(entityType, id, null) { }
}