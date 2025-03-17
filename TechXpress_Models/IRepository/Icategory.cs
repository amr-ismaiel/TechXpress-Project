using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechXpress_Models.Entities;

namespace TechXpress_Models.IRepository
{
    public interface Icategory
    {
        Task <IEnumerable<Category>> GetAll();
        Task<Category> Get(Expression<Func<Category , bool>>filter, string? includeProperties = null, bool tracked = false);

        Task<Category> Create (Category category);

        Task<Category> Update (int id , Category category);

        Task<Category> Delete (int id);
    }
}