using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechXpress_Models.Entities;

namespace TechXpress_Services.Interfaces
{
    public interface IImageService
    {
        Task<Product_image> GetImage(Expression<Func<Product_image, bool>> filter, bool tracked = true);
        Task<IEnumerable<Product_image>> GetAllImages(Expression<Func<Product_image, bool>> filter = null, bool tracked = false);
        Task AddImage(Product_image image);
        Task UpdateImage(Product_image image);
        Task DeleteImage(Product_image image);
    }
}