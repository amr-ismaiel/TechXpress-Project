using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechXpress_Models.Entities;

namespace TechXpress_Models.IRepository
{
    public interface Ibrand
    {
        Task <IEnumerable<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null  ,bool tracked = false , params string[] includeProperties );
        Task<Brand> Get(Expression<Func<Brand , bool>>filter, string? includeProperties = null, bool tracked = false);

        Task<Brand> Create (Brand brand);

        Task<Brand> Update (int id , Brand brand);

        Task<Brand> Delete (int id);
    }
}