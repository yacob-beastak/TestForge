using TestForge.Builders;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=== Valid User ===");
var user = UserBuilder.Create()
    .WithFirstName("Ján")
    .WithLastName("Novák")
    .WithEmail("jan.novak@example.com")
    .WithAge(28)
    .AsAdmin()
    .Build();

Console.WriteLine($"User: {user.FirstName} {user.LastName}, Email: {user.Email}, Age: {user.Age}, Admin: {user.IsAdmin}");

Console.WriteLine("\n=== Invalid User (throws on validate) ===");
try
{
    var invalidUser = UserBuilder.Create()
        .WithEmptyName()
        .WithInvalidEmail()
        .WithAgeBelow(0)
        .Build(validate: true); // throws
}
catch (Exception ex)
{
    Console.WriteLine($"[ERROR] {ex.Message}");
}

Console.WriteLine("\n=== Billing Address ===");
var address = AddressBuilder.Create()
    .WithStreet("Hlavná 5")
    .WithCity("Bratislava")
    .WithZip("81101")
    .WithCountry("Slovakia")
    .AsBilling()
    .Build();

Console.WriteLine($"Address: {address.Street}, {address.City}, {address.ZipCode}, {address.Country}, Billing: {address.IsBilling}");

Console.WriteLine("\n=== Invalid Address (throws on validate) ===");
try
{
    var badAddress = AddressBuilder.Create()
        .WithStreet("")
        .WithCity("")
        .Build(validate: true); // throws
}
catch (Exception ex)
{
    Console.WriteLine($"[ERROR] {ex.Message}");
}

Console.WriteLine("\n=== Order With Linked User ===");
var order = OrderBuilder.Create()
    .WithCustomer(user)
    .WithTotal(59.99m)
    .WithDate(DateTime.UtcNow.AddDays(-2))
    .AsPaid()
    .Build(validate: true);

Console.WriteLine($"Order: {order.TotalPrice:F2} €, Status: {order.Status}, Date: {order.CreatedAt}, Customer: {order.Customer.FirstName}");

Console.WriteLine("\n=== Random Address & Order ===");
var randomAddress = AddressBuilder.Random();
var randomOrder = OrderBuilder.Random();

Console.WriteLine($"Random Address: {randomAddress.Street}, {randomAddress.Country}");
Console.WriteLine($"Random Order: {randomOrder.TotalPrice:F2}€, Status: {randomOrder.Status}");


Console.WriteLine("\n=== Valid Product ===");
var product = ProductBuilder.Create()
    .WithName("All-Mountain Snowboard")
    .WithPrice(199.99m)
    .WithStock(25)
    .Build(validate: true);

Console.WriteLine($"Product: {product.Name}, Price: {product.Price:F2} €, Stock: {product.Stock}, Available: {product.IsAvailable}");

Console.WriteLine("\n=== Invalid Product (throws on validate) ===");
try
{
    var invalidProduct = ProductBuilder.Create()
        .WithName("")
        .WithPrice(-15)
        .WithStock(-2)
        .Build(validate: true);
}
catch (Exception ex)
{
    Console.WriteLine($"[ERROR] {ex.Message}");
}

Console.WriteLine("\n=== Random Product ===");
var randomProduct = ProductBuilder.Random();
Console.WriteLine($"Random Product: {randomProduct.Name}, Price: {randomProduct.Price:F2} €, Stock: {randomProduct.Stock}");
