using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Database.Mapping;

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.Property(o => o.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        
        builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(150).IsRequired();
        builder.Property(c => c.Email).HasColumnName("Email").HasMaxLength(150).IsRequired();
    }
}