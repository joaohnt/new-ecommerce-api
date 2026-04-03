namespace Ecommerce.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}