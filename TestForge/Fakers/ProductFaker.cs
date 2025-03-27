using Bogus;
using TestForge.Models;

namespace TestForge.Fakers;

public static class ProductFaker
{
    public static Faker<Product> Create()
    {
        return new Faker<Product>()
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => f.Random.Decimal(5, 200))
            .RuleFor(p => p.Stock, f => f.Random.Int(0, 100))
            .RuleFor(p => p.IsAvailable, (f, p) => p.Stock > 0);
    }
}
