using AutoMapper;
using EventBooking.Interface;
using EventBooking.Models;
using EventBooking.Models.DTO;
using EventBooking.Repository;
using System.Security.Cryptography;
using System.Text;

namespace EventBooking.Services
{
    public class UserService:IUserService
    {
        private readonly IRepository<int,User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<int, User> userRepository,IMapper mapper)
        {
            _userRepository=userRepository;
            _mapper=mapper;
        }

        public async Task<User> CreateNewUser(UserDTO user)
        {
            try
            {
                User newUser=_mapper.Map<User>(user);
                HMACSHA256 hmac = new HMACSHA256();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                newUser.Password = passwordHash;
                var userAdded = await _userRepository.Add(newUser);
                return userAdded;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _userRepository.GetAll();
        }
    }
}
