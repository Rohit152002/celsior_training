using WebAPIWithDatabase.Models.DTO;

namespace WebAPIWithDatabase.Interfaces
{
    public interface IUserService
    {
        public Task<LoginResponseDTO> Autheticate(LoginRequestDTO loginUser);
        public Task<LoginResponseDTO> Register(UserCreateDTO registerUser);
    }
}
