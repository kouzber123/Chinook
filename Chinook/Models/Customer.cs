using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICustomerRepository.Models
{
    public readonly record struct Customer(int Id, string Fname, string Lname, string Company, string Adress, string City, string State, string Country, string PostalCode, string Phone, string Fax, string Email, int SupportField)
    {
    }
}
