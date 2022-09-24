using System.Buffers.Binary;
using System.Runtime.InteropServices;
using System.Text;

namespace StreamScribe.Stream.Generic;

internal abstract class ReadWriteContext : ReadContext, IWriteContext
{
    protected ReadWriteContext(IEnumerable<byte> context) : base(context)
    {
    }

    public IWriteContext FillWith(byte value)
    {
        Pointer.SetPosition(Pointer.Start);
        while (Pointer.Current < Pointer.Stop)
        {
            InsertByte(value);
        }
        return this;
    }

    public IWriteContext WriteBytes(IEnumerable<byte> context)
    {
        var marshalContext = CollectionsMarshal.AsSpan(context.ToList());
        InsertBytes(marshalContext);
        return this;
    }

    public IWriteContext WriteBytes(Span<byte> context)
    {
        InsertBytes(context);
        return this;
    }

    public IWriteContext WriteDoubleBigEndian(double value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(double)];
        BinaryPrimitives.WriteDoubleBigEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteDoubleLittleEndian(double value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(double)];
        BinaryPrimitives.WriteDoubleLittleEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteInt16BigEndian(short value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(short)];
        BinaryPrimitives.WriteInt16BigEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteInt16LittleEndian(short value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(short)];
        BinaryPrimitives.WriteInt16LittleEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteInt32BigEndian(int value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(int)];
        BinaryPrimitives.WriteInt32BigEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteInt32LittleEndian(int value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(int)];
        BinaryPrimitives.WriteInt32LittleEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteInt64BigEndian(long value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(long)];
        BinaryPrimitives.WriteInt64BigEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteInt64LittleEndian(long value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(long)];
        BinaryPrimitives.WriteInt64LittleEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteInt8(sbyte value)
    {
        InsertSByte(value);
        return this;
    }

    public IWriteContext WriteSingleBigEndian(float value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(float)];
        BinaryPrimitives.WriteSingleBigEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteSingleLittleEndian(float value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(float)];
        BinaryPrimitives.WriteSingleLittleEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteStringBigEndian(ReadOnlySpan<char> context)
    {
        Span<byte> buffer = stackalloc byte[context.Length];
        Encoding.ASCII.GetBytes(context.ToArray()).CopyTo(buffer);
        if (BitConverter.IsLittleEndian) buffer.Reverse();
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteStringBigEndian(ReadOnlySpan<char> context, Encoding encoding)
    {
        Span<byte> buffer = stackalloc byte[context.Length];
        encoding.GetBytes(context.ToArray()).CopyTo(buffer);
        if (BitConverter.IsLittleEndian) buffer.Reverse();
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteStringBigEndian(int length, ReadOnlySpan<char> context)
    {
        Span<byte> buffer = stackalloc byte[length];
        FillBuffer(buffer);
        Encoding.ASCII.GetBytes(context.ToArray()).CopyTo(buffer);
        if (BitConverter.IsLittleEndian) buffer.Reverse();
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteStringBigEndian(int length, ReadOnlySpan<char> context, Encoding encoding)
    {
        Span<byte> buffer = stackalloc byte[length];
        FillBuffer(buffer);
        encoding.GetBytes(context.ToArray()).CopyTo(buffer);
        if (BitConverter.IsLittleEndian) buffer.Reverse();
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteStringLittleEndian(ReadOnlySpan<char> context)
    {
        Span<byte> buffer = stackalloc byte[context.Length];
        Encoding.ASCII.GetBytes(context.ToArray()).CopyTo(buffer);
        if (!BitConverter.IsLittleEndian) buffer.Reverse();
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteStringLittleEndian(ReadOnlySpan<char> context, Encoding encoding)
    {
        Span<byte> buffer = stackalloc byte[context.Length];
        encoding.GetBytes(context.ToArray()).CopyTo(buffer);
        if (!BitConverter.IsLittleEndian) buffer.Reverse();
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteStringLittleEndian(int length, ReadOnlySpan<char> context)
    {
        Span<byte> buffer = stackalloc byte[length];
        FillBuffer(buffer);
        Encoding.ASCII.GetBytes(context.ToArray()).CopyTo(buffer);
        if (!BitConverter.IsLittleEndian) buffer.Reverse();
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteStringLittleEndian(int length, ReadOnlySpan<char> context, Encoding encoding)
    {
        Span<byte> buffer = stackalloc byte[length];
        FillBuffer(buffer);
        encoding.GetBytes(context.ToArray()).CopyTo(buffer);
        if (!BitConverter.IsLittleEndian) buffer.Reverse();
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteUInt16BigEndian(ushort value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ushort)];
        BinaryPrimitives.WriteUInt16BigEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteUInt16LittleEndian(ushort value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ushort)];
        BinaryPrimitives.WriteUInt16LittleEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteUInt32BigEndian(uint value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(uint)];
        BinaryPrimitives.WriteUInt32BigEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteUInt32LittleEndian(uint value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(uint)];
        BinaryPrimitives.WriteUInt32LittleEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteUInt64BigEndian(ulong value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];
        BinaryPrimitives.WriteUInt64BigEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteUInt64LittleEndian(ulong value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];
        BinaryPrimitives.WriteUInt64LittleEndian(buffer, value);
        InsertBytes(buffer);
        return this;
    }

    public IWriteContext WriteUInt8(byte value)
    {
        InsertByte(value);
        return this;
    }

    private static void FillBuffer(Span<byte> buffer, byte value = 0x00)
    {
        buffer.Fill(value);
    }

    private void InsertByte(byte value)
    {
        if (Pointer.Current + 1 > Pointer.Stop)
        {
            Context.Add(value);
            Pointer.SetStopBoundary(Pointer.Stop + 1);
        }
        else
        {
            Context[Pointer.Current] = value;
        }
        Pointer.Advance();
    }

    private void InsertBytes(Span<byte> context)
    {
        for (var i = 0; i < context.Length; i++)
        {
            InsertByte(context[i]);
        }
    }

    private void InsertSByte(sbyte value)
    {
        if (Pointer.Current + 1 > Pointer.Stop)
        {
            Context.Add((byte)value);
            Pointer.SetStopBoundary(Pointer.Stop + 1);
        }
        else
        {
            Context[Pointer.Current] = (byte)value;
        }
        Pointer.Advance();
    }
}
