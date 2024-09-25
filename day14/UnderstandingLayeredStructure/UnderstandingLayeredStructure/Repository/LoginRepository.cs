using Microsoft.AspNetCore.Server.IIS.Core;
using UnderstandingLayeredStructure.Interfaces;
using UnderstandingLayeredStructure.Models;

namespace UnderstandingLayeredStructure.Repository
{
    public class LoginRepository : IRepository
    {
        List<User> users = new List<User>()
        {
            new User() {Id =1 , Name="Rohit Laishram", Email="laishramrohit15@gmail.com", Password="intel123" },
            new User(){Id=2, Name="Thoibi", Email="thoibi@gmail.com", Password="intel123"}
        };
        public User Login(string email, string password)
        {
            if(users.Count == 0) throw new Exception("There is no users");

            User? user= users.FirstOrDefault(p=>p.Email == email && p.Password==password);

            if(user == null) throw new Exception("User not found");

            return user;
        }

        public List<User> GetAll()
        {
            return users;
        }
    }
}
