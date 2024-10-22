using Microsoft.EntityFrameworkCore;
using WebAPIWithDatabase.Contexts;
using WebAPIWithDatabase.Interfaces;
using WebAPIWithDatabase.Models;

namespace WebAPIWithDatabase.Repositories
{
    public class UserRepository : IRepository<string, User>
    {
        private readonly ShoppingContext _context;
        private readonly ILogger<UserRepository> _logger;


        public UserRepository(ShoppingContext context,ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<User> Add(User entity)
        {
            try
            {
                _context.Users.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> Delete(string key)
        {
            var product = await Get(key); // Await the Get method
            if (product != null)
            {
                _context.Users.Remove(product);
                await _context.SaveChangesAsync(); // Await SaveChangesAsync
                return product; // Return the deleted product
            }

            // Optionally, throw a more specific exception
            throw new Exception("Users not found for deletion");
        }

        public async Task<User> Get(string key)
        {
            var product = await _context.Users.FirstOrDefaultAsync(c => c.Username == key);
            if (product == null)
            {
                throw new Exception("Users not available");
            }
            return product;
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(string key, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
