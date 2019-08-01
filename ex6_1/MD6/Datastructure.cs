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
    class Datastructure
    {
        //create the list that holds all the customers
        List<Customer> mainList;
        
        //constructors
        public Datastructure(List<Customer> newList)
        {
            mainList = newList;
        }
        public Datastructure()
        {
            mainList = new List<Customer>();
        }

        //add customers
        public void addCustomer(Customer newCustomer)
        {
            //perform a shallow copy.
            Customer temp = new Customer();

            temp.first_name = newCustomer.first_name;
            temp.last_name = newCustomer.last_name;
            temp.zip_code = newCustomer.zip_code;
            temp.prev_purchase = newCustomer.prev_purchase;
            temp.Bdate = newCustomer.Bdate;
            temp.get_CC();

            mainList.Add(temp);
            temp = null;
        }

        //get the total number of customers in the data structure
        public int getCount()
        {
            return mainList.Count;
        }

        //get the customer at a given index
        public Customer GetCustomer(int index)
        {
            return mainList[index];
        }
    }
}
