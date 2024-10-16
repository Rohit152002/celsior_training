using WebAPIWithDatabase.Models.DTO;
namespace WebAPIWithDatabase.Interfaces
{
    public interface ICustomerBasicServices
    {
     
            Task<int> CreateCustomer(CustomerDTO customer);
        
    }
}
