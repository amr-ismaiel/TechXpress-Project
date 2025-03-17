using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechXpress_Models.Entities;

namespace TechXpress_Models.ViewModels
{
    public class ProductVM
    {
        public Product product { get; set; }
        public Product_image? product_images { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? category_list { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? brand_list { get; set; }

        public List<IFormFile>? images { get; set; }

        public int PrimaryImageIndex { get; set; }
    }
}
