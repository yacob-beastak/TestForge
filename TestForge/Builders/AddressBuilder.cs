using TestForge.Models;
using TestForge.Fakers;

namespace TestForge.Builders;

public class AddressBuilder
{
    private readonly Address _address;

    private AddressBuilder()
    {
        _address = AddressFaker.Create().Generate();
    }

    public static AddressBuilder Create() => new();
    public static Address Random() => Create().Build();

    // ---------- WITH ----------
    public AddressBuilder WithStreet(string street)
    {
        _address.Street = street;
        return this;
    }

    public AddressBuilder WithCity(string city)
    {
        _address.City = city;
        return this;
    }

    public AddressBuilder WithZip(string zip)
    {
        _address.ZipCode = zip;
        return this;
    }

    public AddressBuilder WithCountry(string country)
    {
        _address.Country = country;
        return this;
    }

    public AddressBuilder AsBilling()
    {
        _address.IsBilling = true;
        return this;
    }

    public AddressBuilder AsShipping()
    {
        _address.IsBilling = false;
        return this;
    }

    // ---------- BUILD ----------
    public Address Build(bool validate = false)
    {
        if (validate)
        {
            if (string.IsNullOrWhiteSpace(_address.Street))
                throw new InvalidOperationException("Street is required.");

            if (string.IsNullOrWhiteSpace(_address.City))
                throw new InvalidOperationException("City is required.");

            if (string.IsNullOrWhiteSpace(_address.ZipCode))
                throw new InvalidOperationException("Zip code is required.");

            if (string.IsNullOrWhiteSpace(_address.Country))
                throw new InvalidOperationException("Country is required.");
        }

        return _address;
    }
}
