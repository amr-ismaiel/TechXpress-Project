using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechXpress_Models.Entities
{
    public class Product_specs
    {
        public int id { get; set; }

        public Product product{ get; set; }
        public int product_id { get; set; }
        public string spec_name { get; set; }

        public string spec_value { get; set; }
    }
}