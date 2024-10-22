using EventBooking.Context;
using EventBooking.Interface;
using EventBooking.Models;
using Microsoft.EntityFrameworkCore;
namespace EventBooking.Repository
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly EventContext _context;

        public UserRepository(EventContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User entity)
        {
            try
            {
                _context.Users.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> Delete(int key)
        {
            try
            {
                var user = await Get(key);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
                throw new Exception("Delete error");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);   
            }
        }

        public async Task<User> Get(int key)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(c => c.UserId == key);
                return user;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users=await _context.Users.ToListAsync();
            if(users.Count == 0)
            {
                throw new Exception("There is no user");
            }
            return users;
        }

        public async Task<User> Update(int key, User entity)
        {
            var user = await Get(key);
            if (user != null)
            {
                user.UserName = entity.UserName;
                user.Email = entity.Email;
            
                await _context.SaveChangesAsync();
                return user;
            }
            //throw new NotFoundException("Customer for delete");
            throw new Exception("message");
        }
    }
}
