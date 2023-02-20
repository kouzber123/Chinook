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
            //var allCustomers =  customerRepository.GetCustomersWithLimit();
            //int Id, string Fname, string Lname, string Country, string PostalCode, string Phone,string Email

            Customer customer = new() { Fname  = "Tim", Lname = "Nguyen", Country = "Japan", Email = "Tight@Nuts.com", Phone = "+432345324", PostalCode="044211"};
            customerRepository.AddCustomer(customer);
     
           
           

            //foreach (var customer in allCustomers)
            //{
            //    Console.WriteLine(customer.Fname);
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