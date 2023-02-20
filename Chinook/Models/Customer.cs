using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICustomerRepository.Models
{
    public readonly record struct Customer(int Id, string Fname, string Lname, string Country, string PostalCode, string Phone,string Email)
    {
    }
}
