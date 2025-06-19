using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entityconfigurations;

public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
{
    public void Configure(EntityTypeBuilder<Fuel> builder)
    {
        builder.ToTable("Fuels").HasKey("Id");
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Fuels_Name").IsUnique();
        builder.HasMany(b => b.Models).WithOne(m => m.Fuel).HasForeignKey(m => m.FuelId);

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
    }
}
