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

            var genreRepository = new CustomerGenreRepository { ConnectionString = GetConnectionString() };

            var topgenre = genreRepository.GetCustomerTopGenre(1);
            foreach (var genre in topgenre)
            {
                Console.WriteLine(genre.Genre, genre.GenreTotal);
            }

            var customerRepository = new CustomerRepository{ ConnectionString = GetConnectionString() };
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