using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechXpress_Models.Entities;

namespace TechXpress_Models.EntityMapping;

public class ProductMapping:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.id);
        builder.Property(p => p.name).HasMaxLength(100).IsRequired();
        
        builder.Property(p => p.description).HasMaxLength(500);
        
        builder.HasOne(p => p.category)
        .WithMany(c => c.products)
        .HasPrincipalKey(c => c.id)
        .HasForeignKey(p => p.category_id);

         builder.HasOne(p => p.brand)
        .WithMany(b => b.products)
        .HasPrincipalKey(b => b.id)
        .HasForeignKey(p => p.brand_id);



        /* builder.HasData(new Product{id=1, name="samsung s25 Ultra", description="Super Duper Mobile Phone",stock_quantity=20,category_id=1 });
        builder.HasData(new Product{id=2, name="IPhone 15 Pro Plus", description="Best Image Processing  Mobile Phone",stock_quantity=30,category_id=2});
        builder.HasData(new Product{id=3, name="The Maer analog old phone", description="My mobile phone",stock_quantity=0,category_id=3}); */

    }
}
