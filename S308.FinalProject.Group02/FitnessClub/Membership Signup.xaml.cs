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
    /// Interaction logic for Membership_Signup.xaml
    /// </summary>
    public partial class Membership_Signup : Window
    {
        public Membership_Signup()
        {
            InitializeComponent();
        }
        //messagebox confirmation
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainmenuWindow = new MainMenu();
            mainmenuWindow.Show();
            this.Close();
        }

        private void btnCreateMember_Click(object sender, RoutedEventArgs e)
        {
            // do we need this here?
            MainMenu mainmenuWindow = new MainMenu();
            mainmenuWindow.Show();
            this.Close();

            //validate first name - required 
            if(txtFirstName.Text == "")
            {
                MessageBox.Show("Please enter a First Name.");
                return;
            }

            //Validate Last Name - required
            if (txtLastName.Text == "")
            {
                MessageBox.Show("Please enter a Last Name.");
                return;
            }

            //Validate Email - criteria - required FINISH 
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please enter a valid email.");
                return;
            }


            //Phone Number - required

            //validate Credit Card Type - required - cbo


            //validate Credit Card Number - required

            //valdate gender - required - cbo

            //validate age 

            //validate weight

            //validate fitness goal - cbo



        }
    }
}
