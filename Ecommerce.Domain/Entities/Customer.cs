namespace Ecommerce.Domain.Entities;

public class Customer : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    public Customer(string  name, string email)
    {
        Name = ValidateName(name);
        Email = ValidateEmail(email);
    }

    private static string ValidateEmail(string email)
    {
        if (email.Contains("@") && email.Contains("."))
            return email;
        throw new ArgumentException("Email inválido.");
    }

    private static string ValidateName(string name)
    {
        if(name.Length > 0)
            return name;
        throw new ArgumentException("O nome não pode ser vazio.");
    }
}
