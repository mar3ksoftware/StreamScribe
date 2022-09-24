using StreamScribe.Pointer.Exceptions;

using System.Runtime.CompilerServices;

#if DEBUG
[assembly: InternalsVisibleTo("StreamScribe.Tests")]
#endif

namespace StreamScribe.Pointer.Generic;

internal sealed class InteractivePointer : IInteractivePointer
{
    private const int _advanceValue = 1;
    private const int _regressValue = -1;

    internal InteractivePointer(int start, int stop)
    {
        Current = start;
        Start = start;
        Stop = stop;
    }

    public int Current { get; private set; }

    public int Start { get; private set; }

    public int Stop { get; private set; }

    public void Advance()
    {
        SetProjectedPointerValue(_advanceValue);
    }

    public void Regress()
    {
        SetProjectedPointerValue(_regressValue);
    }

    public void SetBoundaries(int start, int stop)
    {
        ValidateBoundariesOverflow(start, stop);
        Start = start;
        Stop = stop;
    }

    public void SetOffset(int offset)
    {
        SetProjectedPointerValue(offset);
    }

    public void SetPosition(int position)
    {
        SetProjectedPointerValue(position, true);
    }

    public void SetStartBoundary(int start)
    {
        ValidateBoundariesOverflow(start, Stop);
        Start = start;
    }

    public void SetStopBoundary(int stop)
    {
        ValidateBoundariesOverflow(Start, stop);
        Stop = stop;
    }

    private void SetProjectedPointerValue(int value, bool isAbsolute = false)
    {
        var projected = isAbsolute ? value : Current + value;
        ValidePointerOverflow(projected);
        Current = projected;
    }

    private void ValidateBoundariesOverflow(int start, int stop)
    {
        if (Current < start || stop < Current)
        {
            throw new PointerOverflowException($"Setting boundaries to range of {start}..{stop} will cause the value of {Current} to overflow.");
        }
    }

    private void ValidePointerOverflow(int projectedValue)
    {
        if (projectedValue < Start || projectedValue > Stop)
        {
            throw new PointerOverflowException($"Value of {Current} has to be contained within the range of {Start}..{Stop}.");
        }
    }
}
