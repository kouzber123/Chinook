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

            var addCustomer = new CustomerRepository{ ConnectionString = GetConnectionString() };
            Customer customer = new() { Fname = "tom", Lname = "dd", Country = "dd", Email = "dsdas", Phone = "dds", PostalCode = "dasdsasd" };
            addCustomer.AddCustomer(customer);



            var updateCustomer = new CustomerRepository{ ConnectionString = GetConnectionString() };
            Customer customerUpdated = new() { Fname = "tom", Lname = "BIIIMAAA", Country = "SUGMA", Email = "dsdasLLLL", Phone = "djj", PostalCode = "dasdsasd" };
             updateCustomer.Update(customerUpdated);

            var topSpender = new CustomerRepository{ ConnectionString = GetConnectionString() };
            var topSpenders = topSpender.TopSpendingCustomers();
            foreach (var topG in topSpenders)
            {
                Console.WriteLine(topG);
            }
            var topCountry = new CustomerRepository { ConnectionString = GetConnectionString() };
            var topCountries = topCountry.TopCountriesByCustomerAmount();
            foreach (var topG in topCountries)
            {
                Console.WriteLine(topG);
            }


            var getall = new CustomerRepository { ConnectionString = GetConnectionString() };
            var allCustomers = getall.TopSpendingCustomers();
            foreach (var topG in allCustomers)
            {
                Console.WriteLine(topG);
            }

            var getwithLimits = new CustomerRepository { ConnectionString = GetConnectionString() };
            var setLimits = getwithLimits.TopSpendingCustomers();
            foreach (var topG in setLimits)
            {
                Console.WriteLine(topG);
            }
            var getById = new CustomerRepository { ConnectionString = GetConnectionString() };
            var customerId =getById.GetById(1);
            Console.WriteLine(customerId);

            var getByName = new CustomerRepository { ConnectionString = GetConnectionString() };
            var customerName = getByName.GetById(1);
            Console.WriteLine(customerName);



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