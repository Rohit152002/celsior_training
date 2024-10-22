using EventBooking.Models.DTO;
using EventBooking.Models;

namespace EventBooking.Interface
{
    public interface IUserService
    {
        public Task<User> CreateNewUser(UserDTO user);
        public  Task<IEnumerable<User>> GetAllUser();

    }
}
