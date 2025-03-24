namespace TestForge.Models;

public enum OrderStatus
{
    New,
    Paid,
    Shipped,
    Cancelled
}

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public User Customer { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.New;
}
