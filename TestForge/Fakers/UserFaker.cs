using Bogus;
using TestForge.Models;

namespace TestForge.Fakers;

public static class UserFaker
{
    public static Faker<User> Create()
    {
        return new Faker<User>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.Age, f => f.Random.Int(18, 65))
            .RuleFor(u => u.IsAdmin, f => false)
            .RuleFor(u => u.IsBlocked, f => false);
    }
}
