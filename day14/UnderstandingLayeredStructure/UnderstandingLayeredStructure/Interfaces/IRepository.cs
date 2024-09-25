using UnderstandingLayeredStructure.Models;

namespace UnderstandingLayeredStructure.Interfaces
{
    public interface IRepository
    {
        public User Login(string email, string password);
        public List<User> GetAll();
    }
}
