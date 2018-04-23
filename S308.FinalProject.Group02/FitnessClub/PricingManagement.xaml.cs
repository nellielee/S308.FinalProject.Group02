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
//how do i append to a list, should i make them type in all of the corrections?
namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for PricingManagement.xaml
    /// </summary>
    public partial class PricingManagement : Window
    {
        List<Pricing> pricingList;
        public PricingManagement()
        {
         
                InitializeComponent();
                pricingList = getdatasetfromfile();
                //instantiate a list to hold lsit
                //set the source of the datagrid and refresh
                dtgResults.ItemsSource = pricingList;
                dtgResults.Items.Refresh();

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
                string strfilepath = @"../../Data/Pricing.json";

                //declare variables
                string strPrice;
                int intPrice;
                // string strCombo = ((ComboBoxItem)cboMembershipType.SelectedItem).Content.ToString();
               
                //validation
               
                if (!Int32.TryParse(txtPrice.Text, out intPrice))
                {
                    MessageBox.Show("Please enter a new price without formatting.");
                    return;
                }
                strPrice = txtPrice.Text.Trim();
                if (!strPrice.Contains("."))
                {
                    MessageBox.Show("Please enter a price including the cents. Ex: 99.99");
                    return;
                }

                if (cboType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a membership type.");
                    return;
                }
                if (cboOffered.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an offering type.");
                    return;
                }

                //instantiate a new type from the input and add it to the list
                Pricing pricingNew = new Pricing(txtType.Text.Trim(), txtPrice.Text.Trim(), txtAvailability.Text.Trim(),
                     cboType.Text, cboOffered.Text);

                pricingList.Add(pricingNew);

                try
                {
                    //serialize the new list of membership types to json format
                    string jsonData = JsonConvert.SerializeObject(pricingList);

                    //use System.IO.File to write over the file with the json data
                    System.IO.File.WriteAllText(strfilepath, jsonData);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in export process: " + ex.Message);
                }

                MessageBox.Show("Membership type added!" + Environment.NewLine + pricingNew.ToString());
            }

       

        private void btnSubmitChanges_Click(object sender, RoutedEventArgs e)
        {
            txtPrice.Text = "";
            cboOffered.SelectedIndex = -1;
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
