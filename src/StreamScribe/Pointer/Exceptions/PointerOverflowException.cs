using System.Runtime.Serialization;

namespace StreamScribe.Pointer.Exceptions;

[Serializable]
public sealed class PointerOverflowException : Exception
{
    internal PointerOverflowException()
    {
    }

    internal PointerOverflowException(string? message) : base(message)
    {
    }

    internal PointerOverflowException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    private PointerOverflowException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
