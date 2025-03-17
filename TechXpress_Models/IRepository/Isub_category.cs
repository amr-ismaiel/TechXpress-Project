using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechXpress_Models.Entities;

namespace TechXpress_Models.IRepository
{
    public interface Isub_category
    {

        Task <IEnumerable<Sub_category>> GetAll(Expression<Func<Sub_category, bool>> filter  = null  ,bool tracked = false , params string[] includeProperties);
        Task<Product> Get(Expression<Func<Sub_category , bool>>filter, string? includeProperties = null, bool tracked = false);

        Task<Product> Create (Sub_category product);

        Task<Product> Update (int id , Sub_category sub_category);

        Task<Product> Delete (int id);
        
    }
}