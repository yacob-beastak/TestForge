using TestForge.Models;
using TestForge.Fakers;

namespace TestForge.Builders;

public class ProductBuilder
{
    private readonly Product _product;

    private ProductBuilder()
    {
        _product = ProductFaker.Create().Generate();
    }

    public static ProductBuilder Create() => new();
    public static Product Random() => Create().Build();

    // ---------- WITH ----------
    public ProductBuilder WithName(string name)
    {
        _product.Name = name;
        return this;
    }

    public ProductBuilder WithPrice(decimal price)
    {
        _product.Price = price;
        return this;
    }

    public ProductBuilder WithFreePrice()
    {
        _product.Price = 0;
        return this;
    }

    public ProductBuilder WithNegativePrice()
    {
        _product.Price = -1;
        return this;
    }

    public ProductBuilder WithEmptyName()
    {
        _product.Name = string.Empty;
        return this;
    }

    public ProductBuilder WithLongName()
    {
        _product.Name = new string('X', 300);
        return this;
    }

    public ProductBuilder WithStock(int stock)
    {
        _product.Stock = stock;
        _product.IsAvailable = stock > 0;
        return this;
    }

    public ProductBuilder WithOutOfStock()
    {
        _product.Stock = 0;
        _product.IsAvailable = false;
        return this;
    }

    // ---------- BUILD ----------
    public Product Build(bool validate = false)
    {
        if (validate)
        {
            if (string.IsNullOrWhiteSpace(_product.Name))
                throw new InvalidOperationException("Product name is required.");

            if (_product.Price < 0)
                throw new InvalidOperationException("Price cannot be negative.");

            if (_product.Stock < 0)
                throw new InvalidOperationException("Stock cannot be negative.");
        }

        return _product;
    }
}
