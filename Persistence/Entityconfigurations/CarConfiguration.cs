using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entityconfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey("Id");
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();

        builder.Property(p => p.ModelId).HasColumnName("ModelId").IsRequired();
        builder.Property(p => p.Kilometer).HasColumnName("Kilometer");
        builder.Property(p => p.CarState).HasColumnName("State");
        builder.Property(p => p.ModelYear).HasColumnName("ModelYear");
        builder.Property(p => p.Plate).HasColumnName("Plate");
        builder.Property(p => p.MinFindexScore).HasColumnName("MinFindeksCreditRate");


        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(p => p.Model);

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
    }
}