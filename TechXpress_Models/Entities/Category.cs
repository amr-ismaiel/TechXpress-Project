using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechXpress_Models.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public List<Product> products { get; set; }
        public List<Sub_category> subcategories { get; set; }
    }
}