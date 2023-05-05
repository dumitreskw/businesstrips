using System.Runtime.Serialization;

namespace BusinessTrips.Business.Exceptions;

public class EntityCreationFailedException<T> : Exception
{
    public IEnumerable<T> Errors { get; set; }

    public EntityCreationFailedException() { }

    public EntityCreationFailedException(string message) : base(message) { }

    public EntityCreationFailedException(string message, IEnumerable<T> errors) : base(message)
    {
        Errors = errors;
    }

    public EntityCreationFailedException(string message, Exception innerException)
        : base(message, innerException) { }

    protected EntityCreationFailedException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
