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
    public class ImageRepository : Iimage
    {

          private readonly TechXpress_context _context;

        public ImageRepository(TechXpress_context context)
        {
            _context = context;
        }

        public async Task<Product_image> Get(Expression<Func<Product_image, bool>> filter, bool tracked = true)
        {
            IQueryable<Product_image> query = _context.product_images;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<Product_image>> GetAll(Expression<Func<Product_image, bool>> filter = null, bool tracked = false)
        {
            IQueryable<Product_image> query = _context.product_images;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task Add(Product_image image)
        {
            await _context.product_images.AddAsync(image);
        }

        public async Task Update(Product_image image)
        {
            _context.product_images.Update(image);
        }

        public async Task Delete(Product_image image)
        {
            _context.product_images.Remove(image);
        }
        
    }
}