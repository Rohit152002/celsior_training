using WebAPIWithDatabase.Interfaces;
using WebAPIWithDatabase.Models.DTO;
using WebAPIWithDatabase.Models;
using AutoMapper;

namespace WebAPIWithDatabase.Services
{
    public class CustomerBasicServices:ICustomerBasicServices
    {
        private readonly IRepository<int, Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerBasicServices(IRepository<int, Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<int> CreateCustomer(CustomerDTO customer)
        {
            Customer newCustomer = _mapper.Map<Customer>(customer);
            //Customer newCustomer = MapCustomerDTOToCustomer(customer);
            newCustomer.Age = CalculateAgeFromDateTime(customer.DateOfBirth);
            var addedCustomer = await _customerRepository.Add(newCustomer);
            return addedCustomer.Id;
        }

        private Customer MapCustomerDTOToCustomer(CustomerDTO customer)
        {
            return new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                DateOfBirth = customer.DateOfBirth
            };
        }

        int CalculateAgeFromDateTime(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
