using Chinook.Repositories;
using Microsoft.Data.SqlClient;

namespace ICustomerRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
           

            var customerRepository = new CustomerRepository{ ConnectionString = GetConnectionString() };

            var customerById = customerRepository.GetById(1);

            Console.WriteLine(customerById.Email);

            var customerByName = customerRepository.GetByName("Daan","Peeters");
            Console.WriteLine(customerByName.Email);


            var allCustomers =  customerRepository.GetAll();
            foreach (var customer in allCustomers)
            {
                Console.WriteLine(customer.Fname);
            }
    
            static string GetConnectionString()
            {
                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = "localhost\\SQLEXPRESS",
                    InitialCatalog = "Chinook",
                    IntegratedSecurity = true,
                    TrustServerCertificate = true
                };

                return builder.ConnectionString;
            }
        }
    }
}