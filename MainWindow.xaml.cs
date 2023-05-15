using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace OODExam_GraemeSmith_S00227303
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MovieData db = new MovieData();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query1 = from m in db.Movies
                         select m;

            lbxMovies.ItemsSource = query1;
        }

        private void lbxMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var query1 = from m in db.Movies
                         where m.Title == lbxMovies.SelectedItem.ToString()
                         select m.Description;

            tbxSynopsis.Text = query1.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Booking b1 = new Booking() { BookingDate = (DateTime)datePicker.SelectedDate, NumberOfTickets = int.Parse(tbxBookings.Text), Movie = (Movie)lbxMovies.SelectedItem };
            db.Bookings.Add(b1);
            db.SaveChanges();

        }
    }
}
