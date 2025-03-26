using TestForge.Builders;
using Xunit;

namespace TestForge.Tests;

public class AddressBuilderTests
{
    [Fact]
    public void ShouldBuildValidBillingAddress()
    {
        var address = AddressBuilder.Create()
            .WithCity("Bratislava")
            .AsBilling()
            .Build();

        Assert.Equal("Bratislava", address.City);
        Assert.True(address.IsBilling);
    }

    [Fact]
    public void Build_WithValidateTrue_ShouldThrowForEmptyStreet()
    {
        var builder = AddressBuilder.Create()
            .WithStreet("")
            .WithCity("Košice")
            .WithZip("04001")
            .WithCountry("Slovakia");

        var ex = Assert.Throws<InvalidOperationException>(() =>
            builder.Build(validate: true)
        );

        Assert.Contains("street", ex.Message.ToLower());
    }

    [Fact]
    public void ShouldBuildRandomAddress()
    {
        var address = AddressBuilder.Random();

        Assert.False(string.IsNullOrWhiteSpace(address.Street));
        Assert.False(string.IsNullOrWhiteSpace(address.City));
    }
}
