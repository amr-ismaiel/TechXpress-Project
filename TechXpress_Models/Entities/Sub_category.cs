using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechXpress_Models.Entities
{
    public class Sub_category
    {
        [Key]
        public int id { get; set; } // Primary key

        [Required]
        [StringLength(100)]
        public string subcategory_name { get; set; } // Name of the subcategory

        [Required]

        // Navigation property for category
       // [ForeignKey("category_id")]
        public virtual Category category { get; set; }
        public int category_id { get; set; } // Foreign key to category

        // Navigation property for products
        public virtual ICollection<Product> products { get; set; } = new List<Product>();
    }
}