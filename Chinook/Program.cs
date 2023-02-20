using Chinook.Repositories;
using ICustomerRepository.Models;
using Microsoft.Data.SqlClient;

namespace ICustomerRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
           

            var customerRepository = new CustomerRepository{ ConnectionString = GetConnectionString() };
            Customer customer = new() { Fname = "tom", Lname = "dd", Country = "dd", Email = "dsdas", Phone = "dds", PostalCode = "dasdsasd" };
            customerRepository.AddCustomer(customer);

            //foreach (var topCountry in allCustomers)
            //{
            //    Console.WriteLine(topCountry);
            //}
    
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