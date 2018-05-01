using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
   public class Quote
    {
        public string Type { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string PersonalTraining { get; set; }
        public string LockerRental { get; set; }
        public string CostPerMonth { get; set; }
        public string Subtotal { get; set; }
        public string AdditionalFeaturesCost { get; set; }
        public string Total { get; set; }


        

        public Quote()
            {
            }

        public Quote(string type, string startDate, string endDate, string personalTraining, string lockerRental, string costPerMonth, string subtotal, string additionalFeaturesCost, string total)
        {
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
            PersonalTraining = personalTraining;
            LockerRental = lockerRental;
            CostPerMonth = costPerMonth;
            Subtotal = subtotal;
            AdditionalFeaturesCost = additionalFeaturesCost;
            Total = total;
        }

        public override string ToString()

        {
            string strOutput = "";

            strOutput += "Type: " + Type + Environment.NewLine;
            strOutput += "Start Date: " + StartDate + Environment.NewLine;
            strOutput += "End Date: " + EndDate + Environment.NewLine;
            strOutput += "Personal Training: " + PersonalTraining  + Environment.NewLine;
            strOutput += "Locker Rental: " + LockerRental + Environment.NewLine;
            strOutput += "Cost Per Month: " + CostPerMonth + Environment.NewLine;
            strOutput += "Subtotal: " + Subtotal + Environment.NewLine;
            strOutput += "Additional Features Cost: " + AdditionalFeaturesCost + Environment.NewLine;
            strOutput += "Total: " + Total + Environment.NewLine;

            return strOutput;

        }

    }
}
