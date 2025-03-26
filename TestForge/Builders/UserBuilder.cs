using TestForge.Models;
using TestForge.Fakers;

namespace TestForge.Builders;

public class UserBuilder
{
    private readonly User _user;

    private UserBuilder()
    {
        _user = UserFaker.Create().Generate();
    }

    public static UserBuilder Create()
    {
        return new UserBuilder();
    }

    public static User Random() => Create().Build();

    // ---------- WITH ----------
    public UserBuilder WithFirstName(string firstName)
    {
        _user.FirstName = firstName;
        return this;
    }

    public UserBuilder WithLastName(string lastName)
    {
        _user.LastName = lastName;
        return this;
    }

    public UserBuilder WithEmail(string email)
    {
        _user.Email = email;
        return this;
    }

    public UserBuilder WithAge(int age)
    {
        _user.Age = age;
        return this;
    }

    public UserBuilder WithInvalidEmail()
    {
        _user.Email = "invalid-email";
        return this;
    }

    public UserBuilder WithAgeBelow(int min)
    {
        _user.Age = min - 1;
        return this;
    }

    public UserBuilder WithEmptyName()
    {
        _user.FirstName = string.Empty;
        _user.LastName = string.Empty;
        return this;
    }

    // ---------- AS ----------
    public UserBuilder AsAdmin()
    {
        _user.IsAdmin = true;
        return this;
    }

    public UserBuilder AsBlocked()
    {
        _user.IsBlocked = true;
        return this;
    }

    // ---------- BUILD ----------
    public User Build(bool validate = false)
    {
        if (validate)
        {
            if (string.IsNullOrWhiteSpace(_user.FirstName))
                throw new InvalidOperationException("First name is required.");

            if (string.IsNullOrWhiteSpace(_user.Email) || !_user.Email.Contains("@"))
                throw new InvalidOperationException("Email must be valid.");

            if (_user.Age < 0)
                throw new InvalidOperationException("Age cannot be negative.");
        }

        return _user;
    }
}
