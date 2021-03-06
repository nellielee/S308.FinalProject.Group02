﻿using System;
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
using PricingData;
using System.IO;
using Newtonsoft.Json;


namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for MembershipSales.xaml
    /// </summary>
    
    public partial class MembershipSales : Window
    {
        List<Pricing> pricingList;
       

        public Quote MyQuote { get; set; }


        public MembershipSales()
        {
            InitializeComponent();
            pricingList = new List<Pricing> ();
            getdatasetfromfile();

            foreach (var thing in pricingList)
            {
                if (thing.Availability == "Yes")
                {
                    cboType.Items.Add(thing.Type);
                }
                
            }
        }

        public void getdatasetfromfile()
        {
            List<Pricing> pricing = new List<Pricing>();

            string strfilepath = @"../../Data/Pricing.json";
            try
            {
                // //use System.IO.File to read the entire data file
                string jsondata = File.ReadAllText(strfilepath);
                //serialize the json data to a list of customers
                pricingList = JsonConvert.DeserializeObject<List<Pricing>>(jsondata);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pricing list" + ex.Message);
            }
            //return pricing;
        }

     

        private void btnSubmitQuote_Click(object sender, RoutedEventArgs e)
        {
            if (cboType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a membership type.");
                return;
            }
            //define variables to hold information from user input
            string strType, strPersonalTraining, strLockerRental;
            double dblPersonalTraining, dblLocker, dblMembership, dblNumberOfMonths, dblTotal, dblSubtotal, dblCostPerMonth, dblAdditionalFeatures;

            //type combo

            strType = cboType.Text;

            //start date and date picker
            DateTime? datStartDate = dtpStartDate.SelectedDate;
            //validate start date is not null
            if (datStartDate == null)
            {
                MessageBox.Show("Please select a Start Date using the date picker.");
                return;
            }
            //validate start date is not in the past
            
            if (datStartDate < (DateTime.Today))
            {
                MessageBox.Show("Please select a start date not in the past.");
                return;
            }
           
            //Personal Training Combo
            ComboBoxItem cbiSelectedTraining = (ComboBoxItem)cboPtp.SelectedItem;
            strPersonalTraining = cbiSelectedTraining.Content.ToString();

            //Locker Rental Combo
            ComboBoxItem cbiSelectedRental = (ComboBoxItem)cboLocker.SelectedItem;
            strLockerRental = cbiSelectedRental.Content.ToString();


            //set number of months of membership to calcualte out additional costs
           

            if(strType == "Individual 1 Month" || strType == "Two Person 1 Month"|| strType== "Family 1 Month")
            {
                dblNumberOfMonths = 1;
            }
            else
            {
                dblNumberOfMonths = 12;
            }

            

            //set price if locker rental
            switch(strLockerRental)
            {
                case "Include: $1.00 per month":
                    dblLocker = 1;
                    break;
                default:
                    dblLocker = 0;
                    break;
            }


            //set price if personal training included
            switch (strPersonalTraining)
            {
                case "Include: $5.00 per month":
                    dblPersonalTraining = 5;
                    break;
                default:
                    dblPersonalTraining = 0;
                    break;
            }
              
            //Set the price of just the membership
            switch(strType)
            {
                case "Individual 1 Month":
                    dblMembership = 9.99;
                    break;
                case "Two Person 1 Month":
                    dblMembership = 14.99;
                    break;
                case "Family 1 Month":
                    dblMembership = 19.99;
                    break;
                case "Individual 12 Month":
                    dblMembership = 100.00;
                    break;
                case "Two Person 12 Month":
                    dblMembership = 150.00;
                    break;
                case "Family 12 Month":
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
                case "Individual 1 Month":
                case "Two Person 1 Month":
                case "Family 1 Month":
                    datEndDate = datStartDate.Value.AddMonths(1);
                    break;
                case "Individual 12 Month":
                case "Two Person 12 Month":
                case "Family 12 Month":
                    datEndDate = datStartDate.Value.AddMonths(12);
                    break;
            }

            //calculate total and subtotal and cost per month
            dblCostPerMonth = dblMembership / dblNumberOfMonths;
            dblSubtotal = dblMembership;
            dblAdditionalFeatures = dblLocker + dblPersonalTraining;
            dblTotal = dblSubtotal + dblAdditionalFeatures;

            //turn doubles into string to pass over to next window
            string strCostPerMonth = dblCostPerMonth.ToString("C2");
            string strSubtotal = dblSubtotal.ToString("C2");
            string strAdditionalFeaturesCost = dblAdditionalFeatures.ToString("C2");
            string strTotal = dblTotal.ToString("C2");
    
            
            //Date format to string
            string strStartDate = datStartDate.ToString(), strEndDate = datEndDate.ToString();
          

            MyQuote = new Quote(strType, strStartDate, strEndDate, strPersonalTraining, strLockerRental, strCostPerMonth, strSubtotal, strAdditionalFeaturesCost, strTotal);
            //output into textboxes - rectangle is just a boarder --placeholder code
            lblPqType2.Content = strType;
            lblPqStartDate2.Content = strStartDate;
            lblPqEndDate2.Content = strEndDate;
            lblPqCostPerMonth2.Content = dblCostPerMonth.ToString("C2");
            lblAdditionalFeatures2.Content = dblAdditionalFeatures.ToString("C2");
            lblPqTotal2.Content = dblTotal.ToString("C2");
            lblPqSubtotal1.Content = dblSubtotal.ToString("C2");
           



        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
           
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

