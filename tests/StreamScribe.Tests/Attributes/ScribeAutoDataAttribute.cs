using AutoFixture;
using AutoFixture.Xunit2;

using StreamScribe.Tests.Customizations;

namespace StreamScribe.Tests.Attributes;

internal sealed class ScribeAutoDataAttribute : AutoDataAttribute
{
    public ScribeAutoDataAttribute() : base(GetScribeAutoDataCustomization)
    {
    }

    private static IFixture GetScribeAutoDataCustomization()
    {
        var fixture = new Fixture()
            .Customize(new PointerAutoDataCustomization())
            .Customize(new StreamAutoDataCustomization());
        return fixture;
    }
}
