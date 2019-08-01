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

namespace MD6
{
    class Program
    {
        static void Main(string[] args)
        {
            //convert a 3 letter month name to a number from 0 to 11
            Dictionary<String, int> MonthtoNum = new Dictionary<String, int>
            {
                {"Jan", 0},
                {"Feb", 1},
                {"Mar", 2},
                {"Apr", 3},
                {"May", 4},
                {"Jun", 5},
                {"Jul", 6},
                {"Aug", 7},
                {"Sep", 8},
                {"Oct", 9},
                {"Nov", 10},
                {"Dec", 11}
            };

            //create the data structure and temp customer
            Datastructure mainStructure = new Datastructure();
            Customer tempObj = new Customer();

            //#1
            //fill in the information. 
            tempObj.first_name = "Daniel";
            tempObj.last_name = "Beckerich";
            tempObj.zip_code = "12345";
            tempObj.prev_purchase = 4;
            tempObj.Bdate = new int[] {1, 2, 1990};
            //add them to the structure
            mainStructure.addCustomer(tempObj);

            //#2
            //fill in the information. 
            tempObj.first_name = "Jim";
            tempObj.last_name = "Halpert";
            tempObj.zip_code = "54321";
            tempObj.prev_purchase = 7;
            tempObj.Bdate = new int[] { 2, 6, 1982 };
            //add them to the structure
            mainStructure.addCustomer(tempObj);

            //#3
            //fill in the information. 
            tempObj.first_name = "Pam";
            tempObj.last_name = "Beesly";
            tempObj.zip_code = "43215";
            tempObj.prev_purchase = 9;
            tempObj.Bdate = new int[] { 7, 3, 1988 };
            //add them to the structure
            mainStructure.addCustomer(tempObj);

            //#4
            //fill in the information. 
            tempObj.first_name = "Dwight";
            tempObj.last_name = "Schrute";
            tempObj.zip_code = "32154";
            tempObj.prev_purchase = 4;
            tempObj.Bdate = new int[] { 2, 30, 1978 };
            //add them to the structure
            mainStructure.addCustomer(tempObj);

            //#5
            //fill in the information. 
            tempObj.first_name = "Michael";
            tempObj.last_name = "Scott";
            tempObj.zip_code = "21543";
            tempObj.prev_purchase = 5;
            tempObj.Bdate = new int[] { 7, 24, 1974 };
            //add them to the structure
            mainStructure.addCustomer(tempObj);
            
            //create some temp variables we will use to get and validate the information
            bool should_repeat = true;
            string raw;
            do
            {


                //get the users info
                Console.WriteLine("Enter your name in the format \"First_Name Last_Name\"");
                raw = Console.ReadLine();
                //split the string every ' '
                String[] Split_Temp;
                Split_Temp = raw.Split(' ');
                tempObj.first_name = Split_Temp[0];
                tempObj.last_name = Split_Temp[1];

                //get the DOB
                Console.WriteLine("Enter your DOB in the format MM/DD/YYYY");
                raw = Console.ReadLine();
                Split_Temp = raw.Split('/');
                tempObj.Bdate = new int[] { Int32.Parse(Split_Temp[0]), Int32.Parse(Split_Temp[1]), Int32.Parse(Split_Temp[2]) };

                //get the zip code
                Console.WriteLine("Enter the zip code");
                raw = Console.ReadLine();
                tempObj.zip_code = raw;

                //get the last subscription purchase
                Console.WriteLine("Please enter the previous month that you purchased a subscription");
                raw = Console.ReadLine();
                tempObj.prev_purchase = MonthtoNum[raw.Substring(0, 3)];

                //add the object.
                mainStructure.addCustomer(tempObj);

                Console.WriteLine("Would you like to add another? Y/N");

                raw = Console.ReadLine();
                if(raw == "Y") { should_repeat = true; }
                if (raw == "N") { should_repeat = false; }
                else { should_repeat = false; }

            } while (should_repeat);


            for (int i = 0; i < mainStructure.getCount(); i++)
            {
                Console.WriteLine(mainStructure.GetCustomer(i).first_name +" "+ mainStructure.GetCustomer(i).last_name);
            }
            //get the data and validate it.
            should_repeat = true;
            raw = "";
            
            //repeat until we get valid info from the user
            do
            {
                //get the raw text from the user
                Console.WriteLine("enter the name of a costumer to receive the customer code: ");
                raw = Console.ReadLine();

                //compare it against all names
                for (int i = 0; i < mainStructure.getCount() & should_repeat == true; i++)
                {
                    if (mainStructure.GetCustomer(i).first_name + " " + mainStructure.GetCustomer(i).last_name == raw)
                    {
                        //if we have a match, print the information.
                        Console.WriteLine("Name:{0}", mainStructure.GetCustomer(i).first_name + " " + mainStructure.GetCustomer(i).last_name);
                        Console.WriteLine("DoB:{0}", mainStructure.GetCustomer(i).getDOB());
                        Console.WriteLine("Zip:{0}", mainStructure.GetCustomer(i).zip_code);
                        Console.WriteLine("Month of purchase: {0}", mainStructure.GetCustomer(i).prev_purchase);
                        Console.WriteLine("CC: {0}", mainStructure.GetCustomer(i).get_CC());
                        should_repeat = false;
                    }
                    else should_repeat = true;
                }
            } while (should_repeat);


            Console.ReadLine();
        }
    }
}
