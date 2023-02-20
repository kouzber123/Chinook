using Chinook.Models;
using ICustomerRepository.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Repositories
{
    public class CustomerGenreRepository
    {
        public string ConnectionString { get; set; } = string.Empty;

        public IEnumerable<CustomerGenre> GetCustomerTopGenre(int id)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "select top 1 WITH TIES c.FirstName, c.LastName, g.Name as most_popular, COUNT(g.Name) as total_genres " +
                "from Customer c " +
                "join Invoice i on c.CustomerId = i.CustomerId " +
                "join InvoiceLine il on i.InvoiceId = il.InvoiceId " +
                "join Track t on t.TrackId = il.TrackId " +
                "join Genre g on t.GenreId = g.GenreId " +
                "where c.CustomerId = @CustomerId " +
                "GROUP BY total, g.Name, c.FirstName, c.LastName " +
                "Order By total_genres DESC";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CustomerId", id);
            using var reader = command.ExecuteReader(); 

            //var result = new CustomerGenre();

            while (reader.Read())
            {
                yield return new CustomerGenre(
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetInt32(3)


                    );
            }

            
        }


    }
}
