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
using PricingData;
using System.IO;
using Newtonsoft.Json;

// done - fill combo box from json file
// done - loop or query thru and find where type = individual 1 month to output the price and availability in boxes
//find what's listed in dropdown, change properties (price and availability), and researizlise (write over)

namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for PricingManagement.xaml
    /// </summary>
    public partial class PricingManagement : Window
    {
        List<Pricing> pricingList;
        List<string> typeList;
        Pricing selectedPricing;

        public PricingManagement()
        {

            InitializeComponent();
            pricingList = getdatasetfromfile();
            typeList = pricingList.Select(p => p.Type).ToList();
            //instantiate a list to hold lsit
            //set the source of the combobox and refresh

            cboType.ItemsSource = typeList;
            cboType.Items.Refresh();

        }

        public List<Pricing> getdatasetfromfile()
        {
            List<Pricing> pricing = new List<Pricing>();

            string strfilepath = @"../../Data/Pricing.json";
            try
            {
                // //use System.IO.File to read the entire data file
                string jsondata = File.ReadAllText(strfilepath);
                //serialize the json data to a list of customers
                pricing = JsonConvert.DeserializeObject<List<Pricing>>(jsondata);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pricing list" + ex.Message);
            }
            return pricing;
        }



        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {

            if (cboType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a membership type.");
                return;
            }

            string strType = cboType.Text;
            string strNewPrice = txtNewPrice.Text.Trim();

            selectedPricing = pricingList.First(p => p.Type == strType);
            
            txtNewPrice.Text = selectedPricing.Price;
            cboOffered.Text = selectedPricing.Availability;

        }




        private void btnSubmitChanges_Click(object sender, RoutedEventArgs e)
        {

            //declare variables
            string strNewPrice;
            double dblNewPrice;
            //validation

            if (!double.TryParse(txtNewPrice.Text, out dblNewPrice))
            {
                MessageBox.Show("Please enter a new price without a dollar sign.");
                return;
            }
            txtNewPrice.Text = dblNewPrice.ToString("C2");
            strNewPrice = txtNewPrice.Text.Trim();
            if (!strNewPrice.Contains("."))
            {
                MessageBox.Show("Please enter a price including the cents. Ex: 99.99");
                return;
            }


            if (cboOffered.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an offering type.");
                return;
            }
            selectedPricing.Price = txtNewPrice.Text.Trim();
            selectedPricing.Availability = cboOffered.Text;
            string strfilepath = @"../../Data/Pricing.json";

            try
            {
                //serialize the new list of membership types to json format
                string jsonData = JsonConvert.SerializeObject(pricingList);

                //use System.IO.File to write over the file with the json data
                System.IO.File.WriteAllText(strfilepath, jsonData);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updating membership type: " + ex.Message);
            }

            MessageBox.Show("Membership type added!" + Environment.NewLine + pricingList.ToString());
            
        }


    
        //navigation bar
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainmenuWindow = new MainMenu();
            mainmenuWindow.Show();
            this.Close();
        }

        private void btnMembershipSales_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales membersaleWindow = new MembershipSales();
            membersaleWindow.Show();
            this.Close();
        }

        private void btnMemberInformation_Click(object sender, RoutedEventArgs e)
        {
            MemberInformation memberinfoWindow = new MemberInformation();
            memberinfoWindow.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
