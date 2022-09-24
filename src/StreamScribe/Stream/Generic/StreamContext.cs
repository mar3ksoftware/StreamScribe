using StreamScribe.Pointer.Generic;

using System.Collections;
using System.Runtime.InteropServices;

namespace StreamScribe.Stream.Generic;

internal abstract class StreamContext : IStreamContext
{
    private IList<byte>? _context;
    private bool _isDisposed;
    private IInteractivePointer? _pointer;

    protected StreamContext(IEnumerable<byte> context)
    {
        _isDisposed = false;
        _context = new List<byte>(context);
        _pointer = new InteractivePointer(0, _context.Count == 0 ? 0 : _context.Count - 1);
    }

    ~StreamContext()
    {
        Dispose(disposing: false);
    }

    protected IList<byte> Context => _context == null ? throw new NullReferenceException() : _context!;
    protected IInteractivePointer Pointer => _pointer == null ? throw new NullReferenceException() : _pointer!;
    public byte this[int index] => _context == null ? throw new NullReferenceException() : _context[index];

    public abstract object Clone();

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public bool Equals(IStreamContext? other)
    {
        if (_context == null || other == null) return false;

        Span<byte> source = CollectionsMarshal.AsSpan(this.ToList());
        Span<byte> reference = CollectionsMarshal.AsSpan(other!.ToList());

        if (source.Length != reference.Length) return false;

        for (var i = 0; i < source.Length; i++)
        {
            if (source[i] != reference[i]) return false;
        }

        return true;
    }

    public IEnumerator<byte> GetEnumerator()
    {
        if (_context == null)
            return Enumerable.Empty<byte>().GetEnumerator();
        return _context.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed) return;

        if (disposing)
        {
            _context = null;
            _pointer = null;
        }

        _isDisposed = true;
    }
}
