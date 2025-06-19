using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entityconfigurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey("Id");
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.BrandId).HasColumnName("BrandId").IsRequired(); ;
        builder.Property(b => b.FuelId).HasColumnName("FuelId").IsRequired(); ;
        builder.Property(b => b.TransmissionId).HasColumnName("TransmissionId").IsRequired(); ;
        builder.Property(b => b.DailyPrice).HasColumnName("DailyPrice").IsRequired(); ;
        builder.Property(b => b.ImageUrl).HasColumnName("ImageUrl").IsRequired(); ;


        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Models_Name").IsUnique();

        builder.HasMany(b => b.Cars).WithOne(m => m.Model).HasForeignKey(m => m.ModelId);
        builder.HasOne(m => m.Brand).WithMany(b => b.Models).HasForeignKey(m => m.BrandId);
        builder.HasOne(m => m.Fuel).WithMany(f => f.Models).HasForeignKey(m => m.FuelId);
        builder.HasOne(m => m.Transmission).WithMany(t => t.Models).HasForeignKey(m => m.TransmissionId);

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
    }
}
