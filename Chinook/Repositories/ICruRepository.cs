using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICustomerRepository
{
    /// <summary>
    /// Basic CRU Operation
    /// </summary>
    public interface ICruRepository<T, Id>
    {
        IEnumerable<T> GetAll();
        T GetById(Id id);
        void Add(T entity);
        void Update(T entity);
    }
}
