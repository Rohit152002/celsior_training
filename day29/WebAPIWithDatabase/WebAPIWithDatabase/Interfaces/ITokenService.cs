using WebAPIWithDatabase.Models.DTO;

namespace WebAPIWithDatabase.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(UserTokenDTO user);

    }
}
