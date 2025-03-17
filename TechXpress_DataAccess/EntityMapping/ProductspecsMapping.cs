using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechXpress_Models.Entities;

namespace TechXpress_infrastructure.EntityMapping
{
    public class ProductspecsMapping:IEntityTypeConfiguration<Product_specs>
    {
         public void Configure(EntityTypeBuilder<Product_specs> builder)
         {
                builder.HasKey(ps => ps.id);
                builder.Property(ps => ps.spec_name).HasMaxLength(100).IsRequired();
                builder.Property(ps => ps.spec_value).IsRequired();

                builder.HasOne(ps => ps.product)
                .WithMany(s => s.product_specs)
                .HasPrincipalKey(s => s.id)
                .HasForeignKey(ps => ps.product_id);
         }
    }
}