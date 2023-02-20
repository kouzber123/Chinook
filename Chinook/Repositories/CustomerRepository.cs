using ICustomerRepository.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Repositories
{
    public class CustomerRepository
    {

        public string ConnectionString { get; set; } = string.Empty;

        public IEnumerable<Customer> GetAll()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer ORDER BY CustomerId OFFSET 14 ROWS FETCH NEXT 12 ROWS ONLY";
            using var command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new Customer(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetString(7),
                    reader.GetString(8),
                    reader.GetString(9),
                    reader.GetString(10),
                    reader.GetString(11),             
                    reader.GetInt32(12)
                   

                  
                    );
            }
        }

        public Customer GetById(int id) 
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT GuitarId, GuitarDescription, BrandId FROM Guitar WHERE GuitarId = @GuitarId";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@GuitarId", id);
            using var reader = command.ExecuteReader();

            var result = new Customer();

            while (reader.Read())
            {
                result = new Customer(
                    //reader.GetInt32(0),
                
                    );
            }

            return result;
        }


        public Customer GetByName(string name) 
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT * FROM Customer WHERE FirstName = @name";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", name);
            using var reader = command.ExecuteReader();

            //return result = new Customer();
            return new Customer();
            //while (reader.Read())
            //{
            //    result = new Customer(
            //        //reader.GetInt32(0),

            //        );
            //}
        }

        public void Update(Customer entity) { }
    }
}
