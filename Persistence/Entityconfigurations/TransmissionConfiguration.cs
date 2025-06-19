using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entityconfigurations;

public class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
{
    public void Configure(EntityTypeBuilder<Transmission> builder)
    {
        builder.ToTable("Transmissions").HasKey("Id");
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Transmissions_Name").IsUnique();
        builder.HasMany(b => b.Models).WithOne(m => m.Transmission).HasForeignKey(m => m.TransmissionId);

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
    }
}
