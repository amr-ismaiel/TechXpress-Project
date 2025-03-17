using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechXpress_Models.Entities;
using TechXpress_Models.IRepository;
using TechXpress_Services.Interfaces;

namespace TechXpress_Services.Implementations
{
    public class ImageService : IImageService
    {
         private readonly Iimage _imageRepository;

        public ImageService(Iimage imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<Product_image> GetImage(Expression<Func<Product_image, bool>> filter, bool tracked = true)
        {
            return await _imageRepository.Get(filter, tracked);
        }

        public async Task<IEnumerable<Product_image>> GetAllImages(Expression<Func<Product_image, bool>> filter = null, bool tracked = false)
        {
            return await _imageRepository.GetAll(filter, tracked);
        }

        public async Task AddImage(Product_image image)
        {
            await _imageRepository.Add(image);
        }

        public async Task UpdateImage(Product_image image)
        {
            await _imageRepository.Update(image);
        }

        public async Task DeleteImage(Product_image image)
        {
            await _imageRepository.Delete(image);
        }
    }
}