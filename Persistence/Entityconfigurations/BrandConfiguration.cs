using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entityconfigurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands").HasKey("Id");
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Id).HasColumnName("Name").IsRequired();
            builder.Property(b => b.Id).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.Id).HasColumnName("UpdatedDate");
            builder.Property(b => b.Id).HasColumnName("DeletedDate");

            builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
        }
    }
}
