//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;
//using PricingData;
//using System.IO;
//using Newtonsoft.Json;

//// done - fill combo box from json file
//// done - loop or query thru and find where type = individual 1 month to output the price and availability in boxes
////find what's listed in dropdown, change properties (price and availability), and researizlise (write over)
 
//namespace FitnessClub
//{
//    /// <summary>
//    /// Interaction logic for PricingManagement.xaml
//    /// </summary>
//    public partial class PricingManagement : Window
//    {
//        List<Pricing> pricingList;
//        public PricingManagement()
//        {

//            InitializeComponent();
//            pricingList = getdatasetfromfile();
//            //instantiate a list to hold lsit
//            //set the source of the combobox and refresh
//            cboType.ItemsSource = pricingList;
//            cboType.Items.Refresh();

//        }

//        public List<Pricing> getdatasetfromfile()
//        {
//            List<Pricing> pricing = new List<Pricing>();

//            string strfilepath = @"../../Data/Pricing.json";
//            try
//            {
//                // //use System.IO.File to read the entire data file
//                string jsondata = File.ReadAllText(strfilepath);
//                //serialize the json data to a list of customers
//                pricing = JsonConvert.DeserializeObject<List<Pricing>>(jsondata);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error in pricing list" + ex.Message);
//            }
//            return pricing;
//        }

       

//        private void btnSelect_Click(object sender, RoutedEventArgs e)
//        {
//            string strfilepath = @"../../Data/Pricing.json";

// //loop or query thru and find where type = individual 1 month to output the price and availability in boxes
//            List<Pricing> pricingSearch;
            
//            ComboBoxItem cbiType = (ComboBoxItem)cboType.SelectedItem;
//            string strType = cbiType.Content.ToString();
//            string strNewPrice = txtNewPrice.Text.Trim();

//            pricingSearch = pricingIndex.Where(p =>
//                p.type.StartsWith(strType)
//                (strType == "All" || p.types.Exists(t => t.type.name == strType))
//            ).ToList();

//            foreach (Pricing p in pricingSearch)
//            {
//                strNewPrice.Item.Add(p.Price);
//                cboOffered.SelectedItem.Equals(p.Availability);
//            }
//            txtNewPrice.Text = strNewPrice;

//            //declare variables
//            int intNewPrice;

//            //validation

//            if (!Int32.TryParse(txtNewPrice.Text, out intNewPrice))
//            {
//                MessageBox.Show("Please enter a new price without formatting.");
//                return;
//            }
//            strNewPrice = txtNewPrice.Text.Trim();
//            if (!strNewPrice.Contains("."))
//            {
//                MessageBox.Show("Please enter a price including the cents. Ex: 99.99");
//                return;
//            }

//            if (cboType.SelectedIndex == -1)
//            {
//                MessageBox.Show("Please select a membership type.");
//                return;
//            }
//            if (cboOffered.SelectedIndex == -1)
//            {
//                MessageBox.Show("Please select an offering type.");
//                return;
//            }

//            //instantiate a new type from the input and add it to the list
//            Pricing pricingNew = new Pricing(txtNewPrice.Text.Trim(), cboOffered.Text);
//            //edit new price
//            strNewPrice = txtNewPrice.ToString();
//            int index = pricingList.IndexOf(strPrice);
//            if (index != -1)
//                pricingList[index] = strNewPrice;
//            pricingList.Add(pricingNew);

//            //edit availability

//            try
//            {
//                //serialize the new list of membership types to json format
//                string jsonData = JsonConvert.SerializeObject(pricingList);

//                //use System.IO.File to write over the file with the json data
//                System.IO.File.WriteAllText(strfilepath, jsonData);


//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error in updating membership type: " + ex.Message);
//            }

//            MessageBox.Show("Membership type added!" + Environment.NewLine + pricingNew.ToString());
//        }
    
       

//        private void btnSubmitChanges_Click(object sender, RoutedEventArgs e)
//        {
//            txtNewPrice.Text = "";
//            cboOffered.SelectedIndex = -1;
//        }
    
    
 
//        //navigation bar
//        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
//        {
//            MainMenu mainmenuWindow = new MainMenu();
//            mainmenuWindow.Show();
//            this.Close();
//        }

//        private void btnMembershipSales_Click(object sender, RoutedEventArgs e)
//        {
//            MembershipSales membersaleWindow = new MembershipSales();
//            membersaleWindow.Show();
//            this.Close();
//        }

//        private void btnMemberInformation_Click(object sender, RoutedEventArgs e)
//        {
//            MemberInformation memberinfoWindow = new MemberInformation();
//            memberinfoWindow.Show();
//            this.Close();
//        }

//        private void btnExit_Click(object sender, RoutedEventArgs e)
//        {
//            this.Close();
//        }
//    }
//}
