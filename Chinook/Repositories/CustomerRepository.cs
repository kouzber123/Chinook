using Chinook.Models;
using ICustomerRepository.Models;
using Microsoft.Data.SqlClient;

namespace Chinook.Repositories
{
    public class CustomerRepository
    {

        public string ConnectionString { get; set; } = string.Empty;

        /// <summary>
        /// Get all customers, filter by offset and limit
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomersWithLimit(int offset, int limit)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer ORDER BY CustomerId OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Offset", offset);
            command.Parameters.AddWithValue("@Limit", limit);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new Customer(
                    reader.GetInt32(0),
                    (reader.IsDBNull(1) == true) ? String.Empty : reader.GetString(1),
                    (reader.IsDBNull(2) == true) ? String.Empty : reader.GetString(2),
                    (reader.IsDBNull(3) == true) ? String.Empty : reader.GetString(3),
                    (reader.IsDBNull(4) == true) ? String.Empty : reader.GetString(4),
                    (reader.IsDBNull(5) == true) ? String.Empty : reader.GetString(5),
                    (reader.IsDBNull(6) == true) ? String.Empty : reader.GetString(6)


                    );
            }
        }
        /// <summary>
        /// get all customers with no limit 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetAllCustomers()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            using var command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new Customer(
                    reader.GetInt32(0),
                    (reader.IsDBNull(1) == true) ? String.Empty : reader.GetString(1),
                    (reader.IsDBNull(2) == true) ? String.Empty : reader.GetString(2),
                    (reader.IsDBNull(3) == true) ? String.Empty : reader.GetString(3),
                    (reader.IsDBNull(4) == true) ? String.Empty : reader.GetString(4),
                    (reader.IsDBNull(5) == true) ? String.Empty : reader.GetString(5),
                    (reader.IsDBNull(6) == true) ? String.Empty : reader.GetString(6)
                    );
            }
        }
    
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
                    ) ;
            }
        }    
  
        
        /// <summary>
        /// Get customer by id, parameter is int ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetById(int id) 
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = @CustomerId";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CustomerId", id);
            using var reader = command.ExecuteReader();

            var result = new Customer();

            while (reader.Read())
            {
                result = new Customer(
                    reader.GetInt32(0),
                    (reader.IsDBNull(1) == true) ? String.Empty : reader.GetString(1),
                    (reader.IsDBNull(2) == true) ? String.Empty : reader.GetString(2),
                    (reader.IsDBNull(3) == true) ? String.Empty : reader.GetString(3),
                    (reader.IsDBNull(4) == true) ? String.Empty : reader.GetString(4),
                    (reader.IsDBNull(5) == true) ? String.Empty : reader.GetString(5),
                    (reader.IsDBNull(6) == true) ? String.Empty : reader.GetString(6)
                    );
            }

            return result;
        }


        /// <summary>
        /// Get user by firstname and lastname string return with like operator matching customers
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
        public Customer GetByName(string fullname) 
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email  FROM Customer WHERE CONCAT(FirstName, ' ', LastName) like @Fullname";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Fullname", fullname);
            using var reader = command.ExecuteReader();
            var result = new Customer();

            while (reader.Read())
            {
                result = new Customer(
                    //reader.GetInt32(0),
                    reader.GetInt32(0),
                    (reader.IsDBNull(1) == true) ? String.Empty : reader.GetString(1),
                    (reader.IsDBNull(2) == true) ? String.Empty : reader.GetString(2),
                    (reader.IsDBNull(3) == true) ? String.Empty : reader.GetString(3),
                    (reader.IsDBNull(4) == true) ? String.Empty : reader.GetString(4),
                    (reader.IsDBNull(5) == true) ? String.Empty : reader.GetString(5),
                    (reader.IsDBNull(6) == true) ? String.Empty : reader.GetString(6)
                    );
            }

            return result;
        }

        /// <summary>
        /// Update Customer by matching customer object
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Customer entity) 
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email " +
                "WHERE CustomerId = @CustomerId";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", entity.Fname);
            command.Parameters.AddWithValue("@LastName", entity.Lname);
            command.Parameters.AddWithValue("@Country", entity.Country);
            command.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
            command.Parameters.AddWithValue("@Phone", entity.Phone);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.Parameters.AddWithValue("@CustomerId", entity.Id);

            command.ExecuteNonQuery();

        }

        /// <summary>
        /// Add customer to the database accept customer object as parameter
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(Customer customer)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            using SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", customer.Fname);
            command.Parameters.AddWithValue("@LastName", customer.Lname);
            command.Parameters.AddWithValue("@Country", customer.Country);
            command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
            command.Parameters.AddWithValue("@Phone", customer.Phone);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.ExecuteNonQuery();
        }

    }
}
