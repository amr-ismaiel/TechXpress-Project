using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechXpress_DataAccess.Data;
using TechXpress_DataAccess.Repository;
using TechXpress_Models.IRepository;

namespace TechXpress_DataAccess.UnitOfWork
{
    

    public class UnitOfWorkManager : Iunitofwork
    {

        private readonly TechXpress_context _context;
        private readonly Lazy<Iproduct> _product;
        private readonly Lazy<Isub_category> _sub_category;
        private readonly Lazy<Icategory> _category;
        private readonly Lazy<Ibrand> _brand;

        private  readonly Lazy<Iimage> _image;
        public UnitOfWorkManager(TechXpress_context context)
        {

            _context = context;

            _product = new Lazy<Iproduct>(() => new ProductRepository(_context));
            _sub_category = new Lazy<Isub_category>(() => new Sub_categoryRepository(_context));
            _category = new Lazy<Icategory>(() => new CategoryRepository(_context));
            _brand = new Lazy<Ibrand>(() => new BrandRepository(_context));
            _image = new Lazy<Iimage>(() => new ImageRepository(_context));

        }

        public Iproduct Products => _product.Value;

        public Ibrand Brands => _brand.Value;

        public Icategory Categories => _category.Value;

        public Isub_category Sub_Categories => _sub_category.Value;

        public Iimage Images => _image.Value;

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
         return await _context.SaveChangesAsync();
        }
    }
}