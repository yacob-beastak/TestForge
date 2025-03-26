using TestForge.Builders;
using TestForge.Models;
using Xunit;

namespace TestForge.Tests;

public class OrderBuilderTests
{
    [Fact]
    public void ShouldBuildPaidOrderWithCustomTotal()
    {
        var order = OrderBuilder.Create()
            .AsPaid()
            .WithTotal(199.99m)
            .Build();

        Assert.Equal(OrderStatus.Paid, order.Status);
        Assert.Equal(199.99m, order.TotalPrice);
    }

    [Fact]
    public void ShouldAssignCustomUserToOrder()
    {
        var user = UserBuilder.Create()
            .WithFirstName("Martin")
            .Build();

        var order = OrderBuilder.Create()
            .WithCustomer(user)
            .Build();

        Assert.Equal("Martin", order.Customer.FirstName);
    }

    [Fact]
    public void ShouldGenerateRandomOrder()
    {
        var order = OrderBuilder.Random();

        Assert.NotNull(order.Customer);
        Assert.InRange(order.TotalPrice, 10, 500);
    }

    [Fact]
    public void ShouldBuildOrderWithNegativeTotal()
    {
        var order = OrderBuilder.Create()
            .WithNegativeTotal()
            .Build();

        Assert.True(order.TotalPrice < 0);
    }

    [Fact]
    public void ShouldBuildOrderWithZeroTotal()
    {
        var order = OrderBuilder.Create()
            .WithZeroTotal()
            .Build();

        Assert.Equal(0, order.TotalPrice);
    }

    [Fact]
    public void ShouldBuildOrderWithFutureDate()
    {
        var order = OrderBuilder.Create()
            .WithFutureDate()
            .Build();

        Assert.True(order.CreatedAt > DateTime.UtcNow);
    }

    [Fact]
    public void ShouldBuildOrderWithoutCustomer()
    {
        var order = OrderBuilder.Create()
            .WithoutCustomer()
            .Build();

        Assert.Null(order.Customer);
    }

    [Fact]
    public void Build_WithValidateTrue_ShouldThrowForInvalidOrder()
    {
        var builder = OrderBuilder.Create()
            .WithoutCustomer()
            .WithNegativeTotal()
            .WithFutureDate();

        var exception = Assert.Throws<InvalidOperationException>(() =>
            builder.Build(validate: true)
        );

        Assert.Contains("customer", exception.Message.ToLower()); // basic check
    }


}
