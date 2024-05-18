using System.Windows;
using System.Windows.Controls;

namespace RentARoom
{
    public partial class RentalSystem : Window
    {
        private RoomRentalSystem roomRentalSystem;

        public RentalSystem()
        {
            InitializeComponent();
            roomRentalSystem = new RoomRentalSystem();
            DataContext = roomRentalSystem;
        }

        private void AddRentalButton_Click(object sender, RoutedEventArgs e)
        {
            Add_a_Room addRoomWindow = new Add_a_Room(roomRentalSystem);
            addRoomWindow.ShowDialog();
        }

        private void EditRentalButton_Click(object sender, RoutedEventArgs e)
        {
            if (RoomDataGrid.SelectedItem is Room selectedRoom)
            {
                EditRentalWindow editRentalWindow = new EditRentalWindow(roomRentalSystem, selectedRoom);
                editRentalWindow.ShowDialog();
            }
        }

        private void DeleteRentalButton_Click(object sender, RoutedEventArgs e)
        {
            if (RoomDataGrid.SelectedItem is Room selectedRoom)
            {
                DeleteRentalWindow deleteRentalWindow = new DeleteRentalWindow(roomRentalSystem, selectedRoom);
                deleteRentalWindow.ShowDialog();
            }
        }

        private void RentRoomButton_Click(object sender, RoutedEventArgs e)
        {
            if (RoomDataGrid.SelectedItem is Room selectedRoom)
            {
                RentRoomWindow rentRoomWindow = new RentRoomWindow(roomRentalSystem, selectedRoom);
                rentRoomWindow.ShowDialog();
            }
        }

        private void ReleaseRoomButton_Click(object sender, RoutedEventArgs e)
        {
            if (RoomDataGrid.SelectedItem is Room selectedRoom)
            {
                ReleaseRoomWindow releaseRoomWindow = new ReleaseRoomWindow(roomRentalSystem, selectedRoom);
                releaseRoomWindow.ShowDialog();
            }
        }
    }
}
