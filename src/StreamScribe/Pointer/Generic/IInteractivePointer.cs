namespace StreamScribe.Pointer.Generic;

public interface IInteractivePointer
{
    /// <summary>
    ///     Current <see cref="IInteractivePointer" /> position.
    /// </summary>
    int Current { get; }

    /// <summary>
    ///     Start index.
    /// </summary>
    int Start { get; }

    /// <summary>
    ///     Stop index.
    /// </summary>
    int Stop { get; }

    /// <summary>
    ///     Advance the <see cref="Current" /> position of a <see cref="IInteractivePointer" /> by 1.
    /// </summary>
    void Advance();

    /// <summary>
    ///     Regress the <see cref="Current" /> position of a <see cref="IInteractivePointer" /> by 1.
    /// </summary>
    void Regress();

    /// <summary>
    ///     Change both <see cref="IInteractivePointer" /><see cref="Start" /> and
    ///     <see cref="Stop" /> boundaries.
    ///     <para>
    ///         <see cref="Start" /> boundary can not be higher than the <see cref="Stop" /> boundary.
    ///     </para>
    /// </summary>
    /// <param name="start">
    ///     Start boundary.
    /// </param>
    /// <param name="stop">
    ///     Stop boundary.
    /// </param>
    void SetBoundaries(int start, int stop);

    /// <summary>
    ///     Set the <see cref="Current" /> position of a <see cref="IInteractivePointer" /> by the
    ///     given <paramref name="offset" /> value.
    /// </summary>
    /// <param name="offset">
    ///     Negative or positive value of an <paramref name="offset" /> that will be added to the <see cref="Current" />.
    /// </param>
    void SetOffset(int offset);

    /// <summary>
    ///     Set the new position of a <see cref="Current" />.
    ///     <para>
    ///         <paramref name="position" /> has to be equal or higher than <see cref="Start" /> and
    ///         equal or lower than <see cref="Stop" />.
    ///     </para>
    /// </summary>
    /// <param name="position">
    ///     New value of a <see cref="Current" />.
    /// </param>
    void SetPosition(int position);

    /// <summary>
    ///     Change the start boundary of <see cref="IInteractivePointer" />.
    /// </summary>
    /// <param name="start">
    ///     <inheritdoc cref="SetBoundaries(int, int)" path="/param[@name='start']" />
    /// </param>
    void SetStartBoundary(int start);

    /// <summary>
    ///     Change the stop boundary of <see cref="IInteractivePointer" />.
    /// </summary>
    /// <param name="start">
    ///     <inheritdoc cref="SetBoundaries(int, int)" path="/param[@name='stop']" />
    /// </param>
    void SetStopBoundary(int stop);
}
