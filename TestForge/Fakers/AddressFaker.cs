using Bogus;
using TestForge.Models;

namespace TestForge.Fakers;

public static class AddressFaker
{
    public static Faker<Address> Create()
    {
        return new Faker<Address>()
            .RuleFor(a => a.Street, f => f.Address.StreetAddress())
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.ZipCode, f => f.Address.ZipCode())
            .RuleFor(a => a.Country, f => f.Address.Country())
            .RuleFor(a => a.IsBilling, f => f.Random.Bool());
    }
}
