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
    /// Interaction logic for MembershipSales.xaml
    /// </summary>
    public partial class MembershipSales : Window
    {
        public MembershipSales()
        {
            InitializeComponent();
        }

        private void btnSubmitQuote_Click(object sender, RoutedEventArgs e)
        {
            //define variables to hold information from user input
            string strType, strPersonalTraining, srtLockerRental;
            //type combo

         


            //Personal Training Combo



            //Locker Rental Combo




            //take in user input, validate, store in variable

            //output into textboxes - rectangle is just a boarder
           

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }







        //navegation bar 


        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainmenuWindow = new MainMenu();
            mainmenuWindow.Show();
            this.Close();
        }

        private void btnMemberInformation_Click(object sender, RoutedEventArgs e)
        {
            MemberInformation memberinfoWindow = new MemberInformation();
            memberinfoWindow.Show();
            this.Close();
        }

        private void btnPricingManagement_Click(object sender, RoutedEventArgs e)
        {
            PricingManagement pricingmgmtWindow = new PricingManagement();
            pricingmgmtWindow.Show();
            this.Close();
        }

        private void btnProceed_Click(object sender, RoutedEventArgs e)
        {
            Membership_Signup membersignupWindow = new Membership_Signup();
            membersignupWindow.Show();
            this.Close();
        }
    }
}
