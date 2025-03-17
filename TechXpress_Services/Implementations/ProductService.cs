using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechXpress_Models.Entities;
using TechXpress_Models.IRepository;
using TechXpress_Models.ViewModels;

using TechXpress_Services.Interfaces;

namespace TechXpress_Services.Implementations
{
    public class ProductService : IProductService
    {
          private readonly Iunitofwork _unitOfWork;

          private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductService(Iunitofwork unitOfWork , IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    // Existing methods...

    public async Task<Product> GetProduct(Expression<Func<Product, bool>> expression)
    {
        return await _unitOfWork.Products.Get(expression);
    }

    public async Task<IEnumerable<Product>> GetProducts(Expression<Func<Product, bool>> filter=null)
    {
        return await _unitOfWork.Products.GetAll(
            filter: filter,
            includeProperties: "category , brand"
        );
    }
    /* public async Task<IEnumerable<Product>> GetProducts()
    {
        return await GetProducts(x => true); // Call the parameterized version with a default expression
    } */




    public async Task CreateProduct(ProductVM productVM)
    {

         var product = new Product
        {
            name = productVM.product.name,
            // Set other product properties
        };
         await _unitOfWork.Products.Create(product);
         await _unitOfWork.SaveAsync();

         //****************** start addind images ****************************

          string productFolder = Path.Combine(_webHostEnvironment.WebRootPath, "products", product.name);
          Directory.CreateDirectory(productFolder);

          if (!Directory.Exists(productFolder))
            {
                Directory.CreateDirectory(productFolder);
            }

        // Step 3: Save images and update the Images table
        for (int i = 0; i < productVM.images.Count; i++)
        {
            var image = productVM.images[i];
            string sanitizedFileName = SanitizeFileName(image.FileName);
        string imageName = $"{Path.GetFileNameWithoutExtension(sanitizedFileName)}_{DateTime.Now.Ticks}{Path.GetExtension(sanitizedFileName)}";
        string imagePath = Path.Combine(productFolder, imageName);

            // Save the image to the folder
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            // Create an Image entity
            var imageEntity = new Product_image
            {
                product_id = product.id,
                image_url = $"/products/{product.name}/{imageName}",
                is_primary = (i == productVM.PrimaryImageIndex) // Mark the primary image
            };

            // Add the image to the database
            await _unitOfWork.Images.Add(imageEntity);
        }

        // Step 4: Save changes to the database
        await _unitOfWork.SaveAsync();
    }


    
    public async Task UpdateProduct(int id , Product product)
    
    {
         var existingProduct = await _unitOfWork.Products.Get(p => p.id == id);
        if (existingProduct != null)
        {
            // Update the existing product's properties
            await _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveAsync();
        }
        else
        {
            throw new KeyNotFoundException($"Product with ID {id} not found.");
        }
    }








public async Task DeleteProduct(int id)
{
var product = await _unitOfWork.Products.Get(p => p.id == id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }

        await _unitOfWork.Products.Delete(product);
        await _unitOfWork.SaveAsync(); // Save changes to the database

}





public async Task<IEnumerable<SelectListItem>> GetCategoriesForDropdown()
    {
        var categories = await _unitOfWork.Sub_Categories.GetAll(); // Assuming you have a Category repository
        return categories.Select(c => new SelectListItem
        {
            Value = c.id.ToString(), // Use the category ID as the value
            Text = c.subcategory_name // Use the category name as the display text
        }).ToList();
    }

     public async Task<IEnumerable<SelectListItem>> GetBrandsForDropdown()
    {
        var brands = await _unitOfWork.Brands.GetAll(); // Assuming you have a Brand repository
        return brands.Select(b => new SelectListItem
        {
            Value = b.id.ToString(), // Use the brand ID as the value
            Text = b.brand_name // Use the brand name as the display text
        }).ToList();
    }

    // Helper method to sanitize filenames
private string SanitizeFileName(string fileName)
{
    // Replace invalid characters with underscores
    char[] invalidChars = Path.GetInvalidFileNameChars();
    return invalidChars.Aggregate(fileName, (current, c) => current.Replace(c.ToString(), "_"));
}

    }
}