using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using UnderstandingLayeredStructure.Interfaces;
using UnderstandingLayeredStructure.Models;

namespace UnderstandingLayeredStructure.Service
{
    public class LoginService : ILoginServices
    {
        private readonly IRepository _loginRepository;
            
    


        public LoginService(IRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }


        public User LoginUser(string email, string password)
        {
            User user = _loginRepository.Login(email, password);
            if (user == null)
                throw new Exception("Not found");
            
            return user;
        }

        public List<User> GetAllUser()
        {
            List <User> user = _loginRepository.GetAll();
            return user;
        }
    }
}
