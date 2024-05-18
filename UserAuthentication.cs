using MySqlConnector;
using System;
using System.Security.Cryptography;
using System.Text;

namespace RentARoom
{
    public class UserAuthentication
    {
        private string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=rental;";

        public void Register(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("User registered successfully.");
        }

        public bool Login(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        Console.WriteLine("Login successful.");
                        return true;
                    }
                }
            }
            Console.WriteLine("Invalid username or password.");
            return false;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
