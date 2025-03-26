using TestForge.Models;
using TestForge.Fakers;

namespace TestForge.Builders;

public class OrderBuilder
{
    private readonly Order _order;

    private OrderBuilder()
    {
        _order = OrderFaker.Create().Generate();
    }

    public static OrderBuilder Create() => new();
    public static Order Random() => Create().Build();

    // ---------- WITH ----------
    public OrderBuilder WithCustomer(User user)
    {
        _order.Customer = user;
        return this;
    }

    public OrderBuilder WithDate(DateTime date)
    {
        _order.CreatedAt = date;
        return this;
    }

    public OrderBuilder WithTotal(decimal amount)
    {
        _order.TotalPrice = amount;
        return this;
    }

    public OrderBuilder WithNegativeTotal()
    {
        _order.TotalPrice = -50;
        return this;
    }

    public OrderBuilder WithZeroTotal()
    {
        _order.TotalPrice = 0;
        return this;
    }

    public OrderBuilder WithFutureDate()
    {
        _order.CreatedAt = DateTime.UtcNow.AddDays(10);
        return this;
    }

    public OrderBuilder WithoutCustomer()
    {
        _order.Customer = null!;
        return this;
    }

    // ---------- AS ----------

    public OrderBuilder AsNew()
    {
        _order.Status = OrderStatus.New;
        return this;
    }


    public OrderBuilder AsPaid()
    {
        _order.Status = OrderStatus.Paid;
        return this;
    }

    public OrderBuilder AsShipped()
    {
        _order.Status = OrderStatus.Shipped;
        return this;
    }

    public OrderBuilder AsCancelled()
    {
        _order.Status = OrderStatus.Cancelled;
        return this;
    }

    // ---------- BUILD ----------
    public Order Build(bool validate = false)
    {
        if (validate)
        {
            if (_order.Customer == null)
                throw new InvalidOperationException("Order must have a customer.");

            if (_order.TotalPrice < 0)
                throw new InvalidOperationException("Total price cannot be negative.");

            if (_order.CreatedAt > DateTime.UtcNow)
                throw new InvalidOperationException("Order date cannot be in the future.");
        }

        return _order;
    }
}
