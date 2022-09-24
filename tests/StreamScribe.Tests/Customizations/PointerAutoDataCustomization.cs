using AutoFixture;

using StreamScribe.Pointer.Generic;

namespace StreamScribe.Tests.Customizations;

internal sealed class PointerAutoDataCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Register<IInteractivePointer>(() => new InteractivePointer(0, fixture.Create<int>() & int.MaxValue));
    }
}
