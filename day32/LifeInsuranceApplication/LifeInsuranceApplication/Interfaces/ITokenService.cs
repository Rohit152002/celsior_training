using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Interface
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(UserTokenDTO user);
    }
}