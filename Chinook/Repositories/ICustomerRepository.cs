using ICustomerRepository.Models;

namespace ICustomerRepository
{
    public interface ICustomerRepository : ICruRepository<Customer,int>
    {
        string GetCustomerById(int id);
    }
}
