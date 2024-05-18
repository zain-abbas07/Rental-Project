using MySqlConnector;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RentARoom
{
    public class RoomRentalSystem : INotifyPropertyChanged
    {
        private string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=rental;";
        private ObservableCollection<Room> allRooms;

        public ObservableCollection<Room> AllRooms
        {
            get { return allRooms; }
            set
            {
                allRooms = value;
                OnPropertyChanged("AllRooms");
            }
        }

        public RoomRentalSystem()
        {
            AllRooms = new ObservableCollection<Room>();
            LoadAllRooms();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadAllRooms()
        {
            AllRooms.Clear();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Rooms";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AllRooms.Add(new Room
                        {
                            RoomNumber = Convert.ToInt32(reader["RoomNumber"]),
                            Description = reader["Description"].ToString(),
                            PricePerNight = Convert.ToDouble(reader["PricePerNight"]),
                            IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                        });
                    }
                }
            }
        }

        public void AddRoom(int roomNumber, string description, double pricePerNight)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Rooms (RoomNumber, Description, PricePerNight, IsAvailable) VALUES (@RoomNumber, @Description, @PricePerNight, @IsAvailable)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@PricePerNight", pricePerNight);
                command.Parameters.AddWithValue("@IsAvailable", true);

                connection.Open();
                command.ExecuteNonQuery();
            }
            LoadAllRooms(); // Refresh the list of available rooms
        }

        public void UpdateRoom(int roomNumber, string description, double pricePerNight)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Rooms SET Description = @Description, PricePerNight = @PricePerNight WHERE RoomNumber = @RoomNumber";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@PricePerNight", pricePerNight);

                connection.Open();
                command.ExecuteNonQuery();
            }
            LoadAllRooms(); // Refresh the list of available rooms
        }

        public void DeleteRoom(int roomNumber)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Rooms WHERE RoomNumber = @RoomNumber";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomNumber", roomNumber);

                connection.Open();
                command.ExecuteNonQuery();
            }
            LoadAllRooms(); // Refresh the list of available rooms
        }

        public void RentRoom(int roomNumber)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Rooms SET IsAvailable = 0 WHERE RoomNumber = @RoomNumber AND IsAvailable = 1";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomNumber", roomNumber);

                connection.Open();
                command.ExecuteNonQuery();
            }
            LoadAllRooms(); // Refresh the list of available rooms
        }

        public void ReleaseRoom(int roomNumber)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Rooms SET IsAvailable = 1 WHERE RoomNumber = @RoomNumber AND IsAvailable = 0";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomNumber", roomNumber);

                connection.Open();
                command.ExecuteNonQuery();
            }
            LoadAllRooms(); // Refresh the list of available rooms
        }
    }

    public class Room
    {
        public int RoomNumber { get; set; }
        public string Description { get; set; }
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }
}
