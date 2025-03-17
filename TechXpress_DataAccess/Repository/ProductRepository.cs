using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechXpress_DataAccess.Data;
using TechXpress_DataAccess.UnitOfWork;
using TechXpress_Models.Entities;
using TechXpress_Models.IRepository;

namespace TechXpress_DataAccess.Repository
{
    public class ProductRepository : Iproduct
    {
    private readonly DbSet<Product> _dbSet;

    private readonly TechXpress_context _context;
    //private readonly Iunitofwork _uowManager;

    public ProductRepository(TechXpress_context context)
    {
        _context = context;

        _dbSet = _context.Set<Product>();
        
    }

        //public async Task<Product> FindAsync()
        public async Task Create(Product product)
        {
             await _dbSet.AddAsync(product);
            
        }

        public async Task Delete(Product product)
        {
             _dbSet.Remove(product);
        }

        public async Task<Product> Get(Expression<Func<Product, bool>> filter, bool tracked = false , params string[] includeProperties)
        {
            IQueryable<Product> query = _dbSet;

        // Apply tracking
        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        // Apply filtering
        if (filter != null)
        {
            query = query.Where(filter);
        }

        // Apply includes
        if (includeProperties != null && includeProperties.Length > 0)
        {
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty.Trim());
            }
        }

        return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>> filter  = null  ,bool tracked = false , params string[] includeProperties)
        {
             IQueryable<Product> query = _dbSet;

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
           
        

      
        public async Task Update( Product product)
        {
            _dbSet.Update(product);
        }
    }
}