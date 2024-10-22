using Microsoft.EntityFrameworkCore;
using WebAPIWithDatabase.Contexts;
using WebAPIWithDatabase.Interfaces;
using WebAPIWithDatabase.Models;

namespace WebAPIWithDatabase.Repositories
{
    public class ImagesRepository : IRepository<int, Image>
    {
        private readonly ShoppingContext _context;
        public ImagesRepository(ShoppingContext context)
        {
            _context = context;
        }
        public async Task<Image> Add(Image entity)
        {
            try
            {
                _context.Images.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                //throw new CouldNotAddException("Customer");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Image> Delete(int key)
        {
            var image = await Get(key);
            if (image != null)
            {
                _context.Images.Remove(image);
                await _context.SaveChangesAsync();
                return image;
            }
            //throw new NotFoundException("Customer for delete");
            throw new Exception("delete");
        }

        public async Task<Image> Get(int key)
        {
            var image = _context.Images.FirstOrDefault(c => c.Id == key);
            return image;
        }

        public async Task<IEnumerable<Image>> GetAll()
        {
            var images= await _context.Images.ToListAsync();
            if (images.Count == 0)
            {
                //throw new CollectionEmptyException("Customers");
                throw new Exception("customers");
            }
            return images;
        }

        public async Task<Image> Update(int key, Image entity)
        {
            var image = await Get(key);
            if (image != null)
            {
                image.ImageUrl = entity.ImageUrl;
                await _context.SaveChangesAsync();
                return image;
            }
            //throw new NotFoundException("Customer for delete");
            throw new Exception("message");
        }


    }
}
