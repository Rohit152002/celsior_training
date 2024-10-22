using AutoMapper;
using EventBooking.Models;
using EventBooking.Models.DTO;

namespace EventBooking.Mapper
{
    public class UserProfile:Profile
    {
        public UserProfile() {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
