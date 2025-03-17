using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TechXpress.ViewModels;
using TechXpress_Models.Entities;
using TechXpress_DataAccess.Data;
using TechXpress_Models.IRepository;
using TechXpress_Services.Interfaces;
using TechXpress_Services.Implementations;


namespace TechXpress.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        
        private readonly ILogger<ProductController> _logger;
        
        private readonly IProductService _productservice;

        public ProductController(ILogger<ProductController> logger , IProductService productservice)
        {
            _logger = logger;
           
            _productservice = productservice;
        }
        
        public async Task<IActionResult> Index()
        {
            var products = await _productservice.GetProducts();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ProductVM productVM= new ProductVM()
            {

                
            category_list = await _productservice.GetCategoriesForDropdown(),
            brand_list = await _productservice.GetBrandsForDropdown()
        };
               /*  category_list = _repository..sub_categories.ToList().Select(c => new SelectListItem
                    {
                        Text = c.subcategory_name,
                        Value = c.id.ToString()

                    }
                ),

                brand_list = _context.brands.ToList().Select(c => new SelectListItem
                    {
                        Text = c.brand_name,
                        Value = c.id.ToString()

                    }
                ), */

            
            return View(productVM);
        } 
        [HttpPost]
        public IActionResult Create(Product product)
        {
            // _context.products.Add(product);

            return View();
        } 





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        
    }
}