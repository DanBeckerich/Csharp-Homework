// ***********************************************************************
// Assembly         : Customer code
// Author           : Daniel Beckerich
// Created          : 11-21-2018
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 11-21-2018
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//definition of a customer
namespace MD6
{
    class Customer
    {
       //variables for all the information
       //first and last name
        public string first_name { set; get; }
        public string last_name { set; get; }
        //array to hold to the date in the format m/d/y
        public int[] Bdate = new int[] {1,1,2000};

        //month of previous purchase
        public int prev_purchase;

        public string zip_code { set; get; }

        //this will return the customer code, if it hasn't been created yet, it will create it then return it.
       public string get_CC()
        {   //convert a number from 0-11 to the first 3 letters of a month.
            Dictionary<int, string> numToMonth = new Dictionary<int, string>
            {
                {0, "Jan"},
                {1, "Feb"},
                {2, "Mar"},
                {3, "Apr"},
                {4, "May"},
                {5, "Jun"},
                {6, "Jul"},
                {7, "Aug"},
                {8, "Sep"},
                {9, "Oct"},
                {10, "Nov"},
                {11, "Dec"}
            };

            string temp = "";
            string full_name = first_name + " " + last_name;

            temp += last_name;
            temp += Bdate[2];
            temp += full_name.Length;
            temp += numToMonth[prev_purchase];
            temp += zip_code.Substring(zip_code.Length - 2, 2);

            return temp;
            
        }
        
        public string getDOB()
        {
            return (Bdate[0]).ToString() + "/" + (Bdate[1]).ToString() + "/" + (Bdate[2]).ToString();
        }
    }
}
