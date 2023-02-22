using Chinook.Repositories;
using ICustomerRepository.Models;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace ICustomerRepository
{
    public class Program
    {
        static void Main(string[] args)
        {

            var customerRepository = new CustomerRepository { ConnectionString = GetConnectionString() };
            var genreRepository = new CustomerGenreRepository { ConnectionString = GetConnectionString() };
            var topCountries = new CustomerPerCountryRepository { ConnectionString = GetConnectionString()};
            var topSpenders = new CustomerSpendingRepository { ConnectionString = GetConnectionString()};

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
            var customerName = customerRepository.GetByName("Daan Peeters");
            Console.WriteLine($"Customer by name {customerName}");

            //4
            var setLimits = customerRepository.GetCustomersWithLimit(55, 5);
            foreach (var consumer in setLimits)
            {
                Console.WriteLine(consumer);
            }

            //5
            Customer newCustomer = new() { Fname = "tom", Lname = "dubad", Country = "England", Email = "tomtom@tom.com", Phone = "04401203213", PostalCode = "0550" };
            customerRepository.AddCustomer(newCustomer);

            //6
            customerRepository.Update(new Customer(23, "John", "Gordon", "USA", "2113", "+ 1(617) 522 - 1333", "johnsupdated22@yahoo.com"));

            //7

            var topCountry = topCountries.TopCountriesByCustomerAmount();
            foreach (var consumer in topCountry)
            {
                Console.WriteLine(consumer);
            }

            //8

            var topSpender = topSpenders.TopSpendingCustomers();
            foreach (var consumer in topSpender)
            {
                Console.WriteLine(consumer);
            }

            //9
            var topGenre = genreRepository.GetCustomerTopGenre(1);
            foreach (var genre in topGenre)
            {
                Console.WriteLine($"{genre.Genre}, {genre.GenreTotal}");
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