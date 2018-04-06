//Team 2 Jeff Kutz, Teri Principe, Nellie Lee
//photo credit - the odyssey online
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
using System.Windows.Shapes;

namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
        //imgCard.Source = new BitmapImage(new Uri(@"/Images/gym-2.jpg.jpeg", UriKind.Relative );
        //imgCard.Visibility = Visibility.Visible;
    }
}
