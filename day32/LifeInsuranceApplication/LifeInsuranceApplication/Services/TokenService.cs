using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LifeInsuranceApplication.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey;



        public TokenService(IConfiguration configuration)
        {
            _secretKey = configuration["JWT:SecretKey"];
        }
        public virtual async Task<string> GenerateToken(UserTokenDTO user)
        {
            var _claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.GivenName, user.Username),
                  new Claim(ClaimTypes.Role,user.Role)

                };

            var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

            var _credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var _tokenDescriptor = new JwtSecurityToken(

                claims: _claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: _credentials
            );

            string _token = new JwtSecurityTokenHandler().WriteToken(_tokenDescriptor);
            return _token;
        }
    }
}
