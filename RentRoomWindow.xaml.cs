using System.Windows;

namespace RentARoom
{
    public partial class RentRoomWindow : Window
    {
        private RoomRentalSystem roomRentalSystem;
        private Room selectedRoom;

        public RentRoomWindow(RoomRentalSystem roomRentalSystem, Room selectedRoom)
        {
            InitializeComponent();
            this.roomRentalSystem = roomRentalSystem;
            this.selectedRoom = selectedRoom;
            RoomDetailsTextBlock.Text = $"{selectedRoom.Description}";
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            roomRentalSystem.RentRoom(selectedRoom.RoomNumber);
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
