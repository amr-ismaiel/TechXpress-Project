using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechXpress_Models.Entities;

namespace TechXpress_infrastructure.EntityMapping
{
    public class BrandMapping:IEntityTypeConfiguration<Brand>
    {
         public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(x => x.id);
        builder.Property(p => p.brand_name).HasMaxLength(100).IsRequired();

        
    }
        
    }
}