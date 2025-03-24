using Bogus;
using TestForge.Models;

namespace TestForge.Fakers;

public static class OrderFaker
{
    public static Faker<Order> Create()
    {
        return new Faker<Order>()
            .RuleFor(o => o.Customer, f => UserFaker.Create().Generate())
            .RuleFor(o => o.CreatedAt, f => f.Date.Past(1)) // do 1 roka dozadu
            .RuleFor(o => o.TotalPrice, f => f.Finance.Amount(10, 500))
            .RuleFor(o => o.Status, f => f.PickRandom<OrderStatus>());
    }
}
