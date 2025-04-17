using Company1.Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company1.Ecommerce.Persistence.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder
            .Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(d => d.Description)
            .IsRequired()
            .HasMaxLength(200);
        builder
            .Property(d => d.Percentage)
            .HasPrecision(9, 2)
            .IsRequired();
    }
}
