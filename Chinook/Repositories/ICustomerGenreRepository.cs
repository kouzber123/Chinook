using Chinook.Models;
using ICustomerRepository;

namespace Chinook.Repositories
{
    public interface ICustomerGenreRepository: ICruRepository<CustomerGenre, int>
    {
    }
}
