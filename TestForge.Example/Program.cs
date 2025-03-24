using TestForge.Builders;

var order = OrderBuilder.Create()
    .AsPaid()
    .WithNegativeTotal()
    .WithFutureDate()
    .Build();

Console.WriteLine($"Order Total: {order.TotalPrice}");
Console.WriteLine($"Order Date: {order.CreatedAt}");
Console.WriteLine($"Order Status: {order.Status}");
Console.WriteLine($"Customer: {(order.Customer != null ? order.Customer.FirstName : "None")}");
