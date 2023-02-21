using Chinook.Models;
using Microsoft.Data.SqlClient;

namespace Chinook.Repositories
{
    public class CustomerPerCountryRepository
    {
        public string ConnectionString { get; set; } = string.Empty;
        /// <summary>
        ///Get Customer countries by amount of customers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerCountry> TopCountriesByCustomerAmount()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "select c.Country, COUNT(*) AS total_customers from Customer c GROUP BY Country ORDER BY total_customers DESC";
            using var command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new CustomerCountry(
                    reader.GetString(0),
                    reader.GetInt32(1)
                    );
            }
        }

    }
}
