using TestForge.Builders;
using Xunit;

namespace TestForge.Tests;

public class ProductBuilderTests
{
    [Fact]
    public void ShouldBuildValidProduct()
    {
        var product = ProductBuilder.Create()
            .WithName("Snowboard")
            .WithPrice(149.99m)
            .WithStock(10)
            .Build();

        Assert.Equal("Snowboard", product.Name);
        Assert.True(product.IsAvailable);
    }


    [Fact]
    public void Build_WithValidateTrue_ShouldThrowForInvalidProduct()
    {
        var builder = ProductBuilder.Create()
            .WithName("")
            .WithPrice(-10)
            .WithStock(-5);

        var ex = Assert.Throws<InvalidOperationException>(() =>
            builder.Build(validate: true)
        );

        Assert.Contains("product name", ex.Message.ToLower());
    }

    [Fact]
    public void ShouldBuildRandomProduct()
    {
        var product = ProductBuilder.Random();

        Assert.False(string.IsNullOrWhiteSpace(product.Name));
        Assert.InRange(product.Price, 5, 200);
    }

    [Fact]
    public void ShouldBuildFreeProduct()
    {
        var product = ProductBuilder.Create()
            .WithFreePrice()
            .Build();

        Assert.Equal(0, product.Price);
    }

    [Fact]
    public void ShouldBuildOutOfStockProduct()
    {
        var product = ProductBuilder.Create()
            .WithOutOfStock()
            .Build();

        Assert.Equal(0, product.Stock);
        Assert.False(product.IsAvailable);
    }



    [Fact]
    public void ShouldThrowForNegativePrice_WhenValidated()
    {
        var builder = ProductBuilder.Create()
            .WithNegativePrice();

        Assert.Throws<InvalidOperationException>(() =>
            builder.Build(validate: true));
    }

    [Fact]
    public void ShouldBuildProductWithLongName()
    {
        var product = ProductBuilder.Create()
            .WithLongName()
            .Build();

        Assert.True(product.Name.Length >= 300);
    }

}