using System.Runtime.Serialization;

namespace StreamScribe.Stream.Exceptions;

[Serializable]
public sealed class ContextNullException : Exception
{
    internal ContextNullException()
    {
    }

    internal ContextNullException(string? message) : base(message)
    {
    }

    internal ContextNullException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    private ContextNullException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
