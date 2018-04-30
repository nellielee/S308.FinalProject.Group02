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
using System.IO;
using Newtonsoft.Json;

namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for MemberInformation.xaml
    /// </summary>
    public partial class MemberInformation : Window
    {
        public MemberInformation()
        {
            InitializeComponent();
        }

        //          navigation
        //Main Menu
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainmenuWindow = new MainMenu();
            mainmenuWindow.Show();
            this.Close();
        }
        //Membership Sales
        private void btnMembershipSales_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales membersaleWindow = new MembershipSales();
            membersaleWindow.Show();
            this.Close();
        }
        //Pricing Management
        private void btnPricingManagement_Click(object sender, RoutedEventArgs e)
        {
            PricingManagement pricingmgmtWindow = new PricingManagement();
            pricingmgmtWindow.Show();
            this.Close();
        }
        //Exit button
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //          Validation and Search
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //define variables
            string strLast, strEmail, strPhone;
            long lngPhone;
            strLast = txtLastName.Text.Trim();

            //Validation: Email format
            if(txtEmail.Text.Trim() == "")
            {
                strEmail = txtEmail.Text;
            }
            else if(!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                    MessageBox.Show("Please enter a valid email.");
                    return;
            }
            else
            {
                strEmail = txtEmail.Text;
            }

            //Validation: If not null, phone number input must be a number
            if (txtPhone.Text.Trim() == "")
            {
                strPhone = txtPhone.Text;
            }
            else
            {
                if (!long.TryParse(txtPhone.Text.Trim(), out lngPhone))
                {
                    MessageBox.Show("Please enter a valid 10 digit phone number without formatting. Example: 8349849820");
                    return;
                }
                else if (lngPhone < 1000000000 || lngPhone > 9999999999)
                {
                    MessageBox.Show("Please enter a phone number that is a valid 10 digits in length. Example: 8349849820");
                    return;
                }
                else
                {
                    strPhone = Convert.ToString(lngPhone);
                }
            }

            //Validation: All three inputs are blank
            if (string.IsNullOrEmpty(strLast) && string.IsNullOrEmpty(strEmail) && string.IsNullOrEmpty(strPhone))
            {
                MessageBox.Show("Must have something entered into at least one of the fields of either Last Name, Email, or Phone Number in order to search. Please enter something into at least one of the fields.");
                return;
            }


            //Search Query
            List<Member> memberList;






            //             output results, setup like from membership signup, all but calculations should be from Member.json
            //txtResults.Text = "Membership Type: " + strMembershipType + Environment.NewLine;
            //txtResults.Text += "Start Date: " + strStartDate + Environment.NewLine;
            //txtResults.Text += "End Date: " + strEndDate + Environment.NewLine;
            //??? cost per month, might need to calculate from membership sales window
            //??? subtotal, might need to calculate from membership sales window
            //??? additional features, I think cost from additional features but might need to calculate from membership sales window
            //??? total, might need to calculate from membership sales window
            //txtResults.Text += "First Name: " + strFirstName + Environment.NewLine;
            //txtResults.Text += "Last Name: " + strLastName + Environment.NewLine;
            //txtResults.Text += "Personal Training: " + strPersonalTraining + Environment.NewLine;
            //txtResults.Text += "Locker Rental: " + strLockerRental + Environment.NewLine;
            //txtResults.Text += "Phone: " + strPhone + Environment.NewLine;
            //txtResults.Text += "Email: " + strEmail + Environment.NewLine;
            //txtResults.Text += "Gender: " + strGender + Environment.NewLine;
            //txtResults.Text += "Age: " + strAge + Environment.NewLine;
            //txtResults.Text += "Weight: " + strWeight + Environment.NewLine;
            //txtResults.Text += "Personal Fitness Goal: " + strPersonalFitnessGoal + Environment.NewLine;
            //txtResults.Text += myQuote.ToString();
        }
    }
}
