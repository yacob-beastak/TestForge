# TestForge 🧪

**Fluent, scenario-oriented test data builders for .NET – powered by Bogus.**  
TestForge simplifies generating valid and invalid test objects for unit, integration, and UI tests with a clean, composable API.

---

##  Features

-  Fluent API for building test data objects
-  Scenario-based methods for edge cases (e.g. `WithNegativePrice()`)
-  Optional validation on `.Build(validate: true)`
-  Faker integration (via [Bogus](https://github.com/bchavez/Bogus))
-  Random or fully controlled object generation
-  Ready-to-use builders: `User`, `Order`, `Address`, `Product`
-  Easily extendable for your own domain models

---

##  Getting Started

Install via NuGet (coming soon):

```bash
dotnet add package TestForge
```

---

## 🔧 Basic Usage

```csharp
var user = UserBuilder.Create()
    .WithFirstName("John")
    .WithEmail("john@example.com")
    .AsAdmin()
    .Build();
```

Or generate a completely random, but valid object:

```csharp
var randomOrder = OrderBuilder.Random();
```

---

##  Validation

Optionally validate object state before use:

```csharp
var product = ProductBuilder.Create()
    .WithNegativePrice()
    .Build(validate: true); // throws InvalidOperationException
```

---

##  Available Builders

| Builder | Key Properties | Scenarios |
|--------|----------------|-----------|
| `UserBuilder` | Name, Email, Age, Admin | `WithInvalidEmail()`, `WithEmptyName()` |
| `OrderBuilder` | Customer, Total, Date | `WithFutureDate()`, `WithoutCustomer()` |
| `AddressBuilder` | Street, City, Country | `WithEmptyFields()`, `AsBilling()` |
| `ProductBuilder` | Name, Price, Stock | `WithNegativePrice()`, `WithOutOfStock()` |

---

##  Example Output

```csharp
var product = ProductBuilder.Create()
    .WithFreePrice()
    .WithOutOfStock()
    .Build();

Console.WriteLine($"{product.Name} | {product.Price:F2} € | Stock: {product.Stock}");
```

---

##  Roadmap

- [x] User, Order, Address, Product builders
- [x] Optional validation
- [x] Faker support
- [ ] CLI generator (e.g. `dotnet forge-gen`)
- [ ] JSON export helpers
- [ ] Source generator for builder scaffolding
- [ ] EF Core seed integration

---

##  Contributing

Pull requests and ideas are welcome!  
Please open an issue to discuss your suggestions.

---

##  License

This project is licensed under the MIT License.
