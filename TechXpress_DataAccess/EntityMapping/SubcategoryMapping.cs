using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechXpress_Models.Entities;

namespace TechXpress_infrastructure.EntityMapping
{
    public class SubcategoryMapping:IEntityTypeConfiguration<Sub_category>
    {
         public void Configure(EntityTypeBuilder<Sub_category> builder)
    {
        builder.HasKey(x => x.id);
        builder.Property(p => p.subcategory_name).HasMaxLength(100).IsRequired();

        builder.HasOne(sc => sc.category)
                .WithMany(c => c.subcategories)
                .HasPrincipalKey(c => c.id)
                .HasForeignKey(sc => sc.category_id);

    }
        
    }
}