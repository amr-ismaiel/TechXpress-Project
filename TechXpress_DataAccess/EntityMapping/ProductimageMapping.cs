using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechXpress_Models.Entities;

namespace TechXpress_infrastructure.EntityMapping
{
    public class ProductimageMapping:IEntityTypeConfiguration<Product_image>
{
    public void Configure(EntityTypeBuilder<Product_image> builder)
    {
        builder.HasKey(i => i.id);
        builder.Property(i => i.image_url).IsRequired();

        builder.HasOne(p => p.product)
        .WithMany(i => i.images)
        .HasPrincipalKey(i => i.id)
        .HasForeignKey(p => p.product_id);
        
       



        

    }
}
}