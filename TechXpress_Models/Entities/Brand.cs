using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechXpress_Models.Entities
{
    public class Brand
    {
        [Key]
        public int id { get; set; } // Primary key

        [Required]
        [StringLength(100)]
        public string brand_name { get; set; } // Brand name

        public string brandlogo_url { get; set; } // URL or path to brand logo

        // Navigation property for products
        public virtual ICollection<Product> products { get; set; } = new List<Product>();
    }
}