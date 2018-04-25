using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    public class Member
    {
        //properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditCardType { get; set; }
        public string CreditCardNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Weight { get; set; }
        public string PersonalFitnessGoal { get; set; }

        //methods
        public Member()
           {
           }

        public Member(string firstName, string lastName,string creditCardType, string creditCardNumber, string phone, string email, string gender, string age, string weight, string personalFitnessGoal)
        {
            FirstName = firstName;
            LastName = lastName;
            CreditCardType = creditCardType;
            CreditCardNumber = creditCardNumber;
            Phone = phone;
            Email = email;
            Gender = gender;
            Age = age;
            Weight = weight;
            PersonalFitnessGoal = personalFitnessGoal;
           
        }

        //overrride

        
            public override string ToString()

        {
            string strOutput = "";

            strOutput += "First Name: " +  FirstName + Environment.NewLine;
            strOutput += "Last Name: " + LastName + Environment.NewLine;
            strOutput += "Credit Card Type: " + CreditCardType + Environment.NewLine;
            strOutput += "Credit Card Number: " + CreditCardNumber + Environment.NewLine;
            strOutput += "Phone: " + Phone + Environment.NewLine;
            strOutput += "Email: " + Email + Environment.NewLine;
            strOutput += "Gender: " + Gender + Environment.NewLine;
            strOutput += "Age: " + Age + Environment.NewLine;
            strOutput += "Weight: " + Weight + Environment.NewLine;
            strOutput += "Personal Fitness Goal: " + PersonalFitnessGoal + Environment.NewLine;
            return strOutput;

        }

    }
    }
