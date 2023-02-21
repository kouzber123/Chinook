using Chinook.Models;
using Microsoft.Data.SqlClient;

namespace Chinook.Repositories
{
    public class CustomerSpendingRepository
    {
        public string ConnectionString { get; set; } = string.Empty;
        /// <summary>
        /// Get customers sorted by their spending
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerSpend> TopSpendingCustomers()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "select CustomerId, SUM(Total) as total_invoice from Invoice Group By CustomerId ORDER BY total_invoice DESC";
            using var command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new CustomerSpend(
                    reader.GetInt32(0),
                    reader.GetDecimal(1)
                    );
            }
        }


    }
}
