using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechXpress_Models.Entities;

namespace TechXpress_infrastructure.EntityMapping
{
    public class CategoryMapping:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.id);
        builder.Property(p => p.name).HasMaxLength(100).IsRequired();
        
        builder.Property(p => p.description).HasMaxLength(500);
        
       



        /* builder.HasData(new Product{id=1, name="Samsung ", description="Korean Leading Company" });
        builder.HasData(new Product{id=2, name="IPhone ", description="American Company"});
        builder.HasData(new Product{id=3, name="The Maer old phone", description="Not Even A Company"}); */

    }
}
}