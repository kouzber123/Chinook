using Chinook.Repositories;
using ICustomerRepository.Models;
using Microsoft.Data.SqlClient;

namespace ICustomerRepository
{
    public class Program
    {
        static void Main(string[] args)
        {

            var customerRepository = new CustomerRepository { ConnectionString = GetConnectionString() };
            var genreRepository = new CustomerGenreRepository { ConnectionString = GetConnectionString() };
            // 1
            var allCustomers = customerRepository.GetAllCustomers();
            foreach (var consumer in allCustomers)
            {
               Console.WriteLine(consumer);
            }

            //2
            var customerId = customerRepository.GetById(1);
            Console.WriteLine($"Customer by ID {customerId}");

            //3
            var customerName = customerRepository.GetByName("Daan", "Peeters");
            Console.WriteLine($"Customer by name {customerName}");

            //4
            var setLimits = customerRepository.GetCustomersWithLimit(55, 5);
            foreach (var consumer in setLimits)
            {
                Console.WriteLine(consumer);
            }

            //5
            Customer newCustomer = new() { Fname = "tom", Lname = "dd", Country = "dd", Email = "dsdas", Phone = "dds", PostalCode = "dasdsasd" };
            customerRepository.AddCustomer(newCustomer);

            //6
            customerRepository.Update(new Customer(23, "John", "Gordon", "USA", "2113", "+ 1(617) 522 - 1333", "johnsupdated22@yahoo.com"));
                       
            //7
            var topCountries = customerRepository.TopCountriesByCustomerAmount();
            foreach (var consumer in topCountries)
            {
                Console.WriteLine(consumer);
            }

            //8
            var topSpenders = customerRepository.TopSpendingCustomers();
            foreach (var consumer in topSpenders)
            {
                Console.WriteLine(consumer);
            }

            //9
            var topgenre = genreRepository.GetCustomerTopGenre(1);
            foreach (var genre in topgenre)
            {
                Console.WriteLine(genre.Genre, genre.GenreTotal);
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