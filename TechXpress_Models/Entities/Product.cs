using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TechXpress_Models.Entities;

public class Product
{
    public int id { get; set; }
   
    public string name { get; set; }
   
    public string description { get; set; }

    public int stock_quantity { get; set; }

    public Sub_category? category { get; set; }
   
    public int category_id { get; set; }
    
    [Required]
    [StringLength(100)]
    public Brand brand { get; set; } = null!;

    public int brand_id { get; set; }

    public DateTime createdDate { get; set; }

    public DateTime? updatedDate { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal price { get; set; }

    public bool is_active  { get; set; }
        
    public decimal rating  { get; set; } = 0.00m;

    [StringLength(50)]
    public string? SKU { get; set; } // Stock Keeping Unit
    [NotMapped]
    public IFormFileCollection? product_images { get; set; }
   
    public virtual ICollection<Product_image> images { get; set; } = new List<Product_image>();

    public virtual ICollection<Product_specs> product_specs { get; set; } = new HashSet<Product_specs>();

}
