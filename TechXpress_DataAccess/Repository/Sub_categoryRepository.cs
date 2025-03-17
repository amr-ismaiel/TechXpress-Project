using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechXpress_DataAccess.Data;
using TechXpress_Models.Entities;
using TechXpress_Models.IRepository;

namespace TechXpress_DataAccess.Repository
{
    public class Sub_categoryRepository : Isub_category
    {
        private readonly TechXpress_context _context;

        private readonly DbSet<Sub_category> _dbSet;
        public Sub_categoryRepository(TechXpress_context context)
        {
            _context = context;
            _dbSet = _context.Set<Sub_category>();
        }

        public Task<Product> Create(Sub_category product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(Expression<Func<Sub_category, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Sub_category>> GetAll(Expression<Func<Sub_category, bool>> filter  = null  ,bool tracked = false , params string[] includeProperties)
        {
             IQueryable<Sub_category> query = _dbSet;

        // Apply tracking
        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        // Apply filtering
        if (filter != null)
        {
            query =  query.Where(filter);
        }

        // Apply includes
        if (includeProperties != null && includeProperties.Length > 0)
        {
            includeProperties = includeProperties[0].Split(',');
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty.Trim());
            }
         }

        return await query.ToListAsync();
        }

        public Task<Product> Update(int id, Sub_category sub_category)
        {
            throw new NotImplementedException();
        }
    }
}
