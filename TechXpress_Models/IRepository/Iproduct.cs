using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechXpress_Models.Entities;

namespace TechXpress_Models.IRepository
{
    public interface Iproduct
    {
        //Task <IEnumerable<Product>> GetAll();
        Task <IEnumerable<Product>> GetAll(Expression<Func<Product, bool>> filter = null  ,bool tracked = false , params string[] includeProperties );

        Task<Product> Get(Expression<Func<Product , bool>>filter , bool tracked = false , params string[] includeProperties);

        Task Create (Product product);

        Task Update ( Product product);

        Task Delete (Product product);
    }
}