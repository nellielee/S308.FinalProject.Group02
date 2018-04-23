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
            //MainMenu mainmenuWindow = new MainMenu();
            //mainmenuWindow.Show();
            //this.Close();
            
            //create variables
            string strFirstName

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

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email.");
                return;
            }


            //Phone Number - required -- ADD

            //validate Credit Card Type - required - cbo


            //validate Credit Card Number - required
            //1. Declare a variables
            string strCardNum = txtCreditCardNumber.Text.Trim().Replace(" ", "");
            long lngOut;        
            bool bolValid = false;            int i;
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
            }            else
            {
                strCardType = "Unknown Card Type";
                MessageBox.Show("Not a Valid Card Number.");
                 return;
            }


            //5. Validate card number
            //ASK THIS SHOULD WORK
            //strCardNum = ReverseString(strCardNum);

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
                intCheckSum += intCheckDigit;            }
            if (intCheckSum % 10 == 0)
            {
                bolValid = true;
            }


            //6. Show the appropriate result          


           //valdate gender - required - cbo


           //validate age 



           //validate weight

           //validate fitness goal - cbo



                }
            }
}
