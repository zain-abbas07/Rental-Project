using System.Windows;

namespace RentARoom
{
    public partial class EditRentalWindow : Window
    {
        private RoomRentalSystem roomRentalSystem;
        private Room roomToEdit;

        public EditRentalWindow(RoomRentalSystem roomRentalSystem, Room room)
        {
            InitializeComponent();
            this.roomRentalSystem = roomRentalSystem;
            this.roomToEdit = room;

            RoomNumberTextBox.Text = room.RoomNumber.ToString();
            DescriptionTextBox.Text = room.Description;
            PricePerNightTextBox.Text = room.PricePerNight.ToString();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(RoomNumberTextBox.Text, out int roomNumber) &&
                double.TryParse(PricePerNightTextBox.Text, out double pricePerNight))
            {
                string description = DescriptionTextBox.Text;
                roomRentalSystem.UpdateRoom(roomNumber, description, pricePerNight);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid data.");
            }
        }
    }
}
