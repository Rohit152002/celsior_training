using Microsoft.EntityFrameworkCore;
using WebAPIWithDatabase.Contexts;
using WebAPIWithDatabase.Interfaces;
using WebAPIWithDatabase.Models;

namespace WebAPIWithDatabase.Repositories
{
    public class ProductRepository : IRepository<int, Product>
    {
        private readonly ShoppingContext _context;
        public ProductRepository(ShoppingContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product entity)
        {
            try
            {
                _context.Products.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
    }

        public async Task<Product> Delete(int key)
        {
            var product = await Get(key); // Await the Get method
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync(); // Await SaveChangesAsync
                return product; // Return the deleted product
            }

            // Optionally, throw a more specific exception
            throw new Exception("Product not found for deletion");
        }


        public async Task<Product> Get(int key)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c=>c.Id == key);
            if (product == null)
            {
                throw new Exception("Product not available");
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            if(products.Count == 0)
            {
                throw new Exception("There is no product available");

            }
            return products;
        }

        public async Task<Product> Update(int key, Product entity)
        {

            var product = await Get(key);
            if (product != null)
            {
                product.Name = entity.Name;
               product.Price = entity.Price;
                product.Description = entity.Description;
                product.OrderDetails = entity.OrderDetails;
                product.Quantity = entity.Quantity;
                await _context.SaveChangesAsync();
                Console.WriteLine($"update product {product.Price} ");
                return product;
            }
            //throw new NotFoundException("Customer for delete");
            throw new Exception("Updated ");
        }
    }
}
