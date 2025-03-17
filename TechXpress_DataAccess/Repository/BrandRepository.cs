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
    public class BrandRepository : Ibrand
    {
        private readonly TechXpress_context _context;

        private readonly DbSet<Brand> _dbSet;
        public BrandRepository(TechXpress_context context)
        {
            _context = context;
            _dbSet = _context.Set<Brand>();
        }

        public Task<Brand> Create(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<Brand> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Brand> Get(Expression<Func<Brand, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null  ,bool tracked = false , params string[] includeProperties )
        {
              IQueryable<Brand> query = _dbSet;

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

        public Task<Brand> Update(int id, Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}