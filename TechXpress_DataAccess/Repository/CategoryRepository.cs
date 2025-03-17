using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechXpress_DataAccess.Data;
using TechXpress_Models.Entities;
using TechXpress_Models.IRepository;

namespace TechXpress_DataAccess.Repository
{
    public class CategoryRepository : Icategory
    {
        private readonly TechXpress_context _context;
        public CategoryRepository(TechXpress_context context)
        {
            _context = context;
        }

        public Task<Category> Create(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Get(Expression<Func<Category, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}