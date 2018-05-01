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
        List<Member> memberList;
        
        public MemberInformation()
        {
            InitializeComponent();
            getdatasetfromfile(); 
            //typeList = memberList.Select(p => p.Type).ToList();
            ////instantiate a list to hold lsit
            ////set the source of the combobox and refresh

            //txtLastName.DataContext = typeList;

            //txtEmail.DataContext = typeList;

            //txtPhone.DataContext = typeList;
        }
        private void getdatasetfromfile()
        {
            List<Member> lsbMembersFound = new List<Member>();

            string strfilepath = @"../../Data/Member.json";
            try
            {
                // //use System.IO.File to read the entire data file
                string jsondata = File.ReadAllText(strfilepath);
                //serialize the json data to a list of customers
                memberList = JsonConvert.DeserializeObject<List<Member>>(jsondata);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in member list" + ex.Message);
            }
            
        }




        //          Validation and Search
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            //define variables
            string strLast, strEmail, strPhone;
            long lngPhone;
            strLast = txtLastName.Text.Trim();


            //                               Validation
            //Validation: Email format
            if (txtEmail.Text.Trim() == "")
            {
                strEmail = txtEmail.Text;
            }
            else if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
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
            //                   End of Validation





            txtMemberInfo.Text = "";
            lsbMembersFound.Items.Clear();



            List<Member> membersFound = memberList.Where(m =>
            m.LastName.StartsWith(strLast) && m.Email.StartsWith(strEmail) && m.Phone.StartsWith(strPhone)).ToList();



            foreach(Member m in membersFound)
            {
                if(strLast == "")
                {

                }
                else
                {
                    if(!lsbMembersFound.Items.Contains(m.FirstName))
                    {
                        lsbMembersFound.Items.Add(m.FirstName);
                    }
                }
                if (strEmail == "")
                {

                }
                else
                {
                    if (!lsbMembersFound.Items.Contains(m.FirstName))
                    {
                        lsbMembersFound.Items.Add(m.FirstName);
                    }
                }
                if (strPhone == "")
                {

                }
                else
                {
                    if (!lsbMembersFound.Items.Contains(m.FirstName))
                    {
                        lsbMembersFound.Items.Add(m.FirstName);
                    }
                }
            }

            //List<Member> membersFound = memberList.Where(m => 
            //m.LastName.StartsWith(strLast) && m.Email == strEmail && m.Phone == strPhone).ToList();

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

        private void lsbMembersFound_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (lsbMembersFound.SelectedIndex > -1)
            {
                string strSelectedName = lsbMembersFound.SelectedItem.ToString();

                Member memberSelected = memberList.Where(m => m.FirstName == strSelectedName).FirstOrDefault();
                txtMemberInfo.Text = memberSelected.ToString();
            }
        }
    }
}
        //strOutput = "Type: " + type + Environment.NewLine;
        //strOutput += "Start Date: " + quote.StartDate + Environment.NewLine;
        //strOutput += "End Date: " + quote.EndDate + Environment.NewLine;
        //strOutput += "First Name: " +  firstName + Environment.NewLine;
        //strOutput += "Last Name: " + lastName + Environment.NewLine;
        //strOutput += "Personal Training: " + quote.PersonalTraining + Environment.NewLine;
        //strOutput += "Locker Rental: " + quote.LockerRental + Environment.NewLine;
        //strOutput += "Phone: " + phone + Environment.NewLine;
        //strOutput += "Email: " + email + Environment.NewLine;
        //strOutput += "Gender: " + gender + Environment.NewLine;
        //strOutput += "Age: " + age + Environment.NewLine;
        //strOutput += "Weight: " + weight + Environment.NewLine;
        //strOutput += "Personal Fitness Goal: " + personalFitnessGoal + Environment.NewLine;



  

