namespace Ecommerce.Domain.Entities;

public class Customer : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
}
