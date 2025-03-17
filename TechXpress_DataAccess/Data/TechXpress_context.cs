using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechXpress_Models.Entities;

namespace TechXpress_DataAccess.Data
{
    public class TechXpress_context:IdentityDbContext<ApplicationUser>
    {
        public TechXpress_context(DbContextOptions<TechXpress_context> options):base(options) 
        {
        }
        
         public DbSet<Product> products {  get; set; }
         public DbSet<Category> categories { get; set; }
        
         public DbSet<Product_specs> product_specs { get; set; }

         public DbSet<Product_image> product_images{ get; set; }

         public DbSet<Sub_category> sub_categories{ get; set; }

         public DbSet<Brand> brands{ get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechXpress_context).Assembly);
         }
    }
}
