using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechXpress_Models.Entities
{
    public class Product_image
    {
        [Key]
        public int id { get; set; } // Primary key

        [Required]
        public int product_id { get; set; } // Foreign key to product

        [Required]
        [StringLength(255)]
        public string image_url { get; set; } // URL or path to image

        public bool is_primary { get; set; } // Indicates if this is the primary image

        // Navigation property for product
       
        public virtual Product product { get; set; }
    }
}