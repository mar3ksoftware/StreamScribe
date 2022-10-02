using System.Runtime.Serialization;

namespace StreamScribe.Stream.Exceptions;

[Serializable]
public sealed class PointerNullException : Exception
{
    internal PointerNullException()
    {
    }

    internal PointerNullException(string? message) : base(message)
    {
    }

    internal PointerNullException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    private PointerNullException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
