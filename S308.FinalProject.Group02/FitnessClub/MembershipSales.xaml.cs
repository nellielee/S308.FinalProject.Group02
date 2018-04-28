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
        public Quote MyQuote { get; set; }
        public MembershipSales()
        {
            InitializeComponent();
        }

        private void btnSubmitQuote_Click(object sender, RoutedEventArgs e)
        {
            //define variables to hold information from user input
            string strType, strPersonalTraining, strLockerRental;
            double dblPersonalTraining, dblLocker, dblMembership, dblNumberOfMonths, dblTotal, dblSubtotal, dblCostPerMonth, dblAdditionalFeatures;

            //type combo
            ComboBoxItem cbiSelectedType = (ComboBoxItem)cboType.SelectedItem;
            strType = cbiSelectedType.Content.ToString();

            //start date and date picker
            DateTime? datStartDate = dtpStartDate.SelectedDate;
            //validate start date is not null
            if (datStartDate == null)
            {
                MessageBox.Show("Please select a Start Date using the date picker.");
                return;
            }

            //Personal Training Combo
            ComboBoxItem cbiSelectedTraining = (ComboBoxItem)cboPtp.SelectedItem;
            strPersonalTraining = cbiSelectedTraining.Content.ToString();

            //Locker Rental Combo
            ComboBoxItem cbiSelectedRental = (ComboBoxItem)cboLocker.SelectedItem;
            strLockerRental = cbiSelectedRental.Content.ToString();


            //set number of months of membership to calcualte out additional costs
            switch (strType)
            {
                case "Individual 1 Month: $9.99":
                case "Two Person 1 Month: $14.99":
                case "Family 1 Month: $19.99":
                    dblNumberOfMonths = 1;
                    break;
                case "Individual 12 Month: $100.00":
                case "Two Person 12 Month: $150.00":
                case "Family 12 Month: $200.00":
                    dblNumberOfMonths = 12;
                    break;          
                default:
                    MessageBox.Show("Please select a membership type.");
                    break;
            }


            dblNumberOfMonths = 0;

            //set price if locker rental
            switch(strLockerRental)
            {
                case "Include":
                    dblLocker = 1;
                    break;
                default:
                    dblLocker = 0;
                    break;
            }


            //set price if personal training included
            switch (strPersonalTraining)
            {
                case "Include":
                    dblPersonalTraining = 5;
                    break;
                default:
                    dblPersonalTraining = 0;
                    break;
            }
              
            //Set the price of just the membership
            switch(strType)
            {
                case "Individual 1 Month: $9.99":
                    dblMembership = 9.99;
                    break;
                case "Two Person 1 Month: $14.99":
                    dblMembership = 14.99;
                    break;
                case "Family 1 Month: $19.99":
                    dblMembership = 19.99;
                    break;
                case "Individual 12 Month: $100.00":
                    dblMembership = 100.00;
                    break;
                case "Two Person 12 Month: $150.00":
                    dblMembership = 150.00;
                    break;
                case "Family 12 Month: $200.00":
                    dblMembership = 200.00;
                    break;
                default:
                    dblMembership = 0;
                    break;
            }

            //Calculate the End Date
            DateTime? datEndDate = datStartDate;

            switch (strType)
            {
                case "Individual 1 Month: $9.99":
                case "Two Person 1 Month: $14.99":
                case "Family 1 Month: $19.99":
                    datEndDate = datStartDate.Value.AddMonths(1);
                    break;
                case "Individual 12 Month: $100.00":
                case "Two Person 12 Month: $150.00":
                case "Family 12 Month: $200.00":
                    datEndDate = datStartDate.Value.AddMonths(12);
                    break;
            }

            //calculate total and subtotal and cost per month
            dblCostPerMonth = dblMembership / dblNumberOfMonths;
            dblSubtotal = dblMembership;
            dblAdditionalFeatures = dblLocker + dblPersonalTraining;
            dblTotal = dblSubtotal + dblAdditionalFeatures;
            
            //Date format to string
            string strStartDate = datStartDate.ToString(), strEndDate = datEndDate.ToString();
            //    String format of date includes hours
            //    might be because set as DateTime? not DateTime, but date wouldn't work as DateTIme
            //    was using Demo 16 for help
            //string strStartDate = "2017-04-04";
            //string strEndDate = "2019-04-04";

            MyQuote = new Quote(strType, strStartDate, strEndDate, strPersonalTraining, strLockerRental);
            //output into textboxes - rectangle is just a boarder --placeholder code
            lblPqType2.Content = strType;
            lblPqStartDate2.Content = strStartDate;
            lblPqEndDate2.Content = strEndDate;
            lblPqCostPerMonth2.Content = dblCostPerMonth.ToString();
            lblAdditionalFeatures2.Content = dblAdditionalFeatures.ToString();
            lblPqTotal2.Content = dblTotal.ToString();
            lblPqSubtotal1.Content = dblSubtotal.ToString();
           



        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
           
        }







        //navigation bar 


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
            Membership_Signup membersignupWindow = new Membership_Signup(MyQuote);
            membersignupWindow.Show();
            this.Close();
        }
    }
}
