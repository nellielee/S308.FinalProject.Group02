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

        public Quote()
            {
            }

        public Quote(string type, string startDate, string endDate, string personalTraining, string lockerRental)
        {
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
            PersonalTraining = personalTraining;
            LockerRental = lockerRental;
        }

        public override string ToString()

        {
            string strOutput = "";

            strOutput += "Type: " + Type + Environment.NewLine;
            strOutput += "Start Date: " + StartDate + Environment.NewLine;
            strOutput += "End Date: " + EndDate + Environment.NewLine;
            strOutput += "Personal Training: " + PersonalTraining  + Environment.NewLine;
            strOutput += "Locker Rental: " + LockerRental + Environment.NewLine;


            return strOutput;

        }

    }
}
