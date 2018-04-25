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
using Newtonsoft.Json;
using System.IO;




namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for Membership_Signup.xaml
    /// </summary>
    public partial class Membership_Signup : Window
    { 
        //instantiate a list for members
        List<Member> memberList;


    
        public Membership_Signup()
        {
            InitializeComponent();

            memberList = new List<Member>();
            //ImportMemberData();
        }

        private void ImportCustomerData()
        {
            //set up path to file
            string strFilePath = @"..\..\..\..\Members.json";

            //use System.IO.File to read the entire data file
            try
            {
                string jsonData = File.ReadAllText(strFilePath);

                //serialize the json data to a list of customers
                memberList = JsonConvert.DeserializeObject<List<Member>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }
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
            string strFilePath = @"..\..\..\..\Members.json";


            // do we need this here?
            //MainMenu mainmenuWindow = new MainMenu();
            //mainmenuWindow.Show();
            //this.Close();

            //create variables
            string strFirstName, strLastName, strCreditCardType, strCreditCardNumber, strPhone, strEmail, strGender, strPersonalFitnessGoal, strAge, strWeight;
            int intWeight, intPhone;
            byte bytAge;


            //validate first name - required 
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Please enter a First Name.");
                return;
            }
            strFirstName = txtFirstName.Text;

            //Validate Last Name - required
            if (txtLastName.Text == "")
            {
                MessageBox.Show("Please enter a Last Name.");
                return;
            }
            strLastName = txtLastName.Text;

            //Validate Email - criteria - required FINISH 
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please enter a valid email.");
                return;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email.");
                return;
            }
            strEmail = txtEmail.Text;

            //Phone Number - required
            if (!Int32.TryParse(txtPhone.Text.Trim(), out intPhone))
            {
                MessageBox.Show("Please enter a phone number as a string of numbers.");
                return;
            }

            strPhone = txtPhone.Text.Trim();

            if (strPhone.Length != 10)
            {
                MessageBox.Show("You must provide a 10 digit phone number.");
                return;
            }







            //validate Credit Card Number - required
            //1. Declare a variables
            string strCardNum = txtCreditCardNumber.Text.Trim().Replace(" ", "");
            long lngOut;
            bool bolValid = false;
            int i;
            int intCheckDigit;
            int intCheckSum = 0;
            string strCardType;

            //2. Make sure the text entered is numeric
            if (!Int64.TryParse(strCardNum, out lngOut))
            {
                MessageBox.Show("Credit card numbers contain only numbers.");
                return;
            }
            //3. Make sure there are 13, 15, 16 digits entered
            if (strCardNum.Length != 13 && strCardNum.Length != 15 && strCardNum.Length != 16)
            {
                MessageBox.Show("Credit card numbers must contain the correct number of digits.");
                return;
            }

            //4. Determine the card type from the prefix and set the card type variable
            if (strCardNum.StartsWith("34") || strCardNum.StartsWith("37"))
            {
                strCardType = "AMEX";
            }
            else if (strCardNum.StartsWith("6011"))
            {
                strCardType = "Discover";
            }
            else if (strCardNum.StartsWith("51") || strCardNum.StartsWith("52") || strCardNum.StartsWith("53") || strCardNum.StartsWith("54") || strCardNum.StartsWith("55"))
            {
                strCardType = "MasterCard";
            }
            else if (strCardNum.StartsWith("4"))
            {
                strCardType = "VISA";
            }
            else
            {
                strCardType = "Unknown Card Type";
                MessageBox.Show("Not a Valid Card Number.");
                return;
            }


            //5. Validate card number

            strCardNum = ReverseString(strCardNum);

            for (i = 0; i < strCardNum.Length; i++)
            {
                intCheckDigit = Convert.ToInt32(strCardNum.Substring(i, 1));

                if ((i + 1) % 2 == 0)
                {
                    intCheckDigit *= 2;

                    if (intCheckDigit > 9)
                    {
                        intCheckDigit -= 9;
                    }
                }
                intCheckSum += intCheckDigit;
            }

            if (intCheckSum % 10 == 0)
            {
                bolValid = true;
            }


            //6. Show the appropriate result   

            strCreditCardNumber = strCardNum;

            // validate Credit Card Type - required - cbo

            ComboBoxItem cbiSelectedItem = (ComboBoxItem)cboCardType.SelectedItem;
            strCreditCardType = cbiSelectedItem.Content.ToString();

            //do we even need a credit card type?


            //valdate gender - required - cbo

            ComboBoxItem cbiSelectedGender = (ComboBoxItem)cboGender.SelectedItem;
            strGender = cbiSelectedGender.Content.ToString();


            //validate age 
            if (!Byte.TryParse(txtAge.Text, out bytAge))
            {
                MessageBox.Show("Please enter a number for your age");
                return;
            }

            strAge = bytAge.ToString();

            //validate weight
            if (!Int32.TryParse(txtAge.Text, out intWeight))
            {
                MessageBox.Show("Please enter a number for your weight");
                return;
            }
            strWeight = intWeight.ToString();

            //validate fitness goal - cbo
            ComboBoxItem cbiSelectedFitnessGoal = (ComboBoxItem)cboFitnessGoal.SelectedItem;
            strPersonalFitnessGoal = cbiSelectedFitnessGoal.Content.ToString();

            //instantiate a new Member from the input and add it to the list
            Member memberNew = new Member(strFirstName, strLastName, strCreditCardType, strCreditCardNumber, strPhone, strEmail, strGender, strAge,strWeight,strPersonalFitnessGoal);
            memberList.Add(memberNew);

            //serialize the new list of members to json format
            try
            {
                string jsonData = JsonConvert.SerializeObject(memberList);
                // use System.IO.File to write over the file with the json data
                System.IO.File.WriteAllText(strFilePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in member creating process: " + ex.Message);
            }

            //output result of new member into result textbox as confirmation
            




        }
        public static string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
