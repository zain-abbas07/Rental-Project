using System.Windows;

namespace RentARoom
{
    public partial class DeleteRentalWindow : Window
    {
        private RoomRentalSystem roomRentalSystem;
        private Room selectedRoom;

        public DeleteRentalWindow(RoomRentalSystem roomRentalSystem, Room selectedRoom)
        {
            InitializeComponent();
            this.roomRentalSystem = roomRentalSystem;
            this.selectedRoom = selectedRoom;
            RoomDetailsTextBlock.Text = $"{selectedRoom.Description}";
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            roomRentalSystem.DeleteRoom(selectedRoom.RoomNumber);
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
