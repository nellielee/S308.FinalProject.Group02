using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingData
{
   public class Pricing
    {
        //Properties
        public string Type { get; set; }
        public string Price { get; set;  }
        public string Availability { get; set; }
    

        //Methods
        public Pricing()
        {
        }

        public Pricing(string type, string price, string availability)
        {
            Type = type;
            Price = price;
            Availability = availability;
 
        }


        public override string ToString()
        {
            string strOutput = "";

            strOutput += "Pricing List: " + Environment.NewLine;
            strOutput += "Type: " + Type + Environment.NewLine;
            strOutput += "Price: " + Price + Environment.NewLine;
            strOutput += "Availability: " + Availability + Environment.NewLine;
           return strOutput;
        }

    }
}