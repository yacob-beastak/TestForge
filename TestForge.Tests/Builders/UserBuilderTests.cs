using TestForge.Builders;
using Xunit;

namespace TestForge.Tests;

public class UserBuilderTests
{
    [Fact]
    public void ShouldBuildAdminUserWithCustomEmail()
    {
        // Arrange + Act
        var user = UserBuilder.Create()
            .WithEmail("admin@example.com")
            .AsAdmin()
            .Build();

        // Assert
        Assert.Equal("admin@example.com", user.Email);
        Assert.True(user.IsAdmin);
        Assert.False(user.IsBlocked); // default
    }

    [Fact]
    public void ShouldBuildBlockedUser()
    {
        var user = UserBuilder.Create()
            .AsBlocked()
            .Build();

        Assert.True(user.IsBlocked);
    }

    [Fact]
    public void ShouldGenerateRandomUser()
    {
        var user = UserBuilder.Random();

        Assert.False(string.IsNullOrWhiteSpace(user.FirstName));
        Assert.InRange(user.Age, 18, 65);
    }

    [Fact]
    public void ShouldBuildUserWithInvalidEmail()
    {
        var user = UserBuilder.Create()
            .WithInvalidEmail()
            .Build();

        Assert.DoesNotContain("@", user.Email);
    }

    [Fact]
    public void ShouldBuildUserWithAgeBelowLimit()
    {
        var user = UserBuilder.Create()
            .WithAgeBelow(18)
            .Build();

        Assert.True(user.Age < 18);
    }

    [Fact]
    public void ShouldBuildUserWithEmptyName()
    {
        var user = UserBuilder.Create()
            .WithEmptyName()
            .Build();

        Assert.True(string.IsNullOrWhiteSpace(user.FirstName));
        Assert.True(string.IsNullOrWhiteSpace(user.LastName));
    }



}
