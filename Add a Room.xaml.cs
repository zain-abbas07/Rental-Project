using System;
using System.Windows;

namespace RentARoom
{
    public partial class Add_a_Room : Window
    {
        private RoomRentalSystem roomRentalSystem;

        public Add_a_Room(RoomRentalSystem roomRentalSystem)
        {
            InitializeComponent();
            this.roomRentalSystem = roomRentalSystem;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int roomNumber = Convert.ToInt32(RoomNumberTextBox.Text);
            string description = DescriptionTextBox.Text;
            double pricePerNight = Convert.ToDouble(PricePerNightTextBox.Text);

            roomRentalSystem.AddRoom(roomNumber, description, pricePerNight);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
