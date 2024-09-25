using UnderstandingLayeredStructure.Models;

namespace UnderstandingLayeredStructure.Interfaces
{
    public interface ILoginServices
    {
        public User LoginUser(string email, string password);
        public List<User> GetAllUser();
      
    }
}
