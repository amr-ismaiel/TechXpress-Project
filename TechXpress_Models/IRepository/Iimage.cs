using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechXpress_Models.Entities;

namespace TechXpress_Models.IRepository
{
    public interface Iimage
    {
   
        Task<Product_image> Get(Expression<Func<Product_image, bool>> filter, bool tracked = true);
        Task<IEnumerable<Product_image>> GetAll(Expression<Func<Product_image, bool>> filter = null, bool tracked = false);
        Task Add(Product_image image);
        Task Update(Product_image image);
        Task Delete(Product_image image);
    
        
    }
}