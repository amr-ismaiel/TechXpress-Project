using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechXpress_Models.Entities;
using TechXpress_Models.ViewModels;

namespace TechXpress_Services.Interfaces
{
           public interface IProductService
{
    // Existing methods...
    Task<Product> GetProduct(Expression<Func<Product, bool>> expression);
    Task<IEnumerable<Product>> GetProducts(Expression<Func<Product, bool>> filter=null);
    
    //Task<IEnumerable<Product>> GetProducts();
  
  //*************************** creat and update *******************************


    Task CreateProduct(ProductVM product);
    Task UpdateProduct(int id ,Product product);

    Task DeleteProduct(int id);

    //add methods for drop downs 

    Task<IEnumerable<SelectListItem>> GetCategoriesForDropdown();
    Task<IEnumerable<SelectListItem>> GetBrandsForDropdown();
}
    }
