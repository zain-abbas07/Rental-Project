using System.Windows;

namespace RentARoom
{
    public partial class ReleaseRoomWindow : Window
    {
        private RoomRentalSystem roomRentalSystem;
        private Room selectedRoom;

        public ReleaseRoomWindow(RoomRentalSystem roomRentalSystem, Room selectedRoom)
        {
            InitializeComponent();
            this.roomRentalSystem = roomRentalSystem;
            this.selectedRoom = selectedRoom;
            RoomDetailsTextBlock.Text = $"{selectedRoom.Description}";
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            roomRentalSystem.ReleaseRoom(selectedRoom.RoomNumber);
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
