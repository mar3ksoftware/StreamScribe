using StreamScribe.Pointer.Exceptions;
using StreamScribe.Pointer.Generic;
using StreamScribe.Tests.Attributes;

namespace StreamScribe.Tests.Pointer;

public sealed class IInteractivePointerTests
{
    [Theory]
    [ScribeAutoData]
    public void Advance_Exception_Text(IInteractivePointer pointer)
    {
        var position = pointer.Stop;
        pointer.SetPosition(position);
        Assert.Throws<PointerOverflowException>(() => pointer.Advance());
    }

    [Theory]
    [ScribeAutoData]
    public void Advance_Test(IInteractivePointer pointer)
    {
        var current = pointer.Current;
        pointer.Advance();
        Assert.False(current == pointer.Current);
    }

    [Theory]
    [ScribeAutoData]
    public void Regress_Exception_Text(IInteractivePointer pointer)
    {
        Assert.Throws<PointerOverflowException>(() => pointer.Regress());
    }

    [Theory]
    [ScribeAutoData]
    public void Regress_Test(IInteractivePointer pointer)
    {
        var max = pointer.Stop;
        pointer.SetPosition(max);
        var current = pointer.Current;
        pointer.Regress();
        Assert.False(current == pointer.Current);
    }

    [Theory]
    [ScribeAutoData]
    public void SetBoundaries_Exception_Test(IInteractivePointer pointer, Random rng)
    {
        var start = rng.Next(pointer.Stop + 1, (pointer.Stop + 1) + rng.Next(100));
        var stop = rng.Next(start, start + rng.Next(100));
        Assert.Throws<PointerOverflowException>(() => pointer.SetBoundaries(start, stop));
    }

    [Theory]
    [ScribeAutoData]
    public void SetBoundaries_Test(IInteractivePointer pointer, Random rng)
    {
        var start = pointer.Current;
        var stop = rng.Next(pointer.Stop, pointer.Stop + rng.Next(200));
        pointer.SetBoundaries(start, stop);
        Assert.True(pointer.Start == start && pointer.Stop == stop);
    }

    [Theory]
    [ScribeAutoData]
    public void SetOffset_Exception_Test(IInteractivePointer pointer, Random rng)
    {
        var offset = rng.Next(pointer.Stop + 1, (pointer.Stop + 1) + rng.Next(100));
        Assert.Throws<PointerOverflowException>(() => pointer.SetOffset(offset));
    }

    [Theory]
    [ScribeAutoData]
    public void SetOffset_Test(IInteractivePointer pointer, Random rng)
    {
        var offset = rng.Next(0, pointer.Stop);
        pointer.SetOffset(offset);
        Assert.Equal(pointer.Current, offset);
    }

    [Theory]
    [ScribeAutoData]
    public void SetStartBoundary_Exception_Test(IInteractivePointer pointer, Random rng)
    {
        var start = rng.Next(pointer.Stop - pointer.Start);
        Assert.Throws<PointerOverflowException>(() => pointer.SetStartBoundary(start));
    }

    [Theory]
    [ScribeAutoData]
    public void SetStartBoundary_Test(IInteractivePointer pointer, Random rng)
    {
        var start = rng.Next(pointer.Stop - pointer.Start);
        pointer.SetPosition(start);
        pointer.SetStartBoundary(start);
        Assert.Equal(start, pointer.Current);
    }

    [Theory]
    [ScribeAutoData]
    public void SetStopBoundary_Exception_Test(IInteractivePointer pointer)
    {
        pointer.SetPosition(pointer.Stop);
        Assert.Throws<PointerOverflowException>(() => pointer.SetStopBoundary(pointer.Stop - 1));
    }

    [Theory]
    [ScribeAutoData]
    public void SetStopBoundary_Test(IInteractivePointer pointer, Random rng)
    {
        var stop = rng.Next(1000);
        pointer.SetStopBoundary(stop);
        Assert.Equal(stop, pointer.Stop);
    }
}
