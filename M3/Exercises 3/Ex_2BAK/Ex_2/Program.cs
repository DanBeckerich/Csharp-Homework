// ***********************************************************************
// Assembly         : Exercise 3 program 2
// Author           : Daniel Beckerich
// Created          : 11/7/2018
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 11/7/2018
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//declare the interface we will use for containers
interface IContainer
{

    List<Item> Contents { get; set; }

    void Add(Item newItem);
    int totalCount();
    int totalWeight(int startingWeight);
}

//create an abstract class for Items. every item should have these properties.
abstract class Item
{
    public int cost { get; set; }
    public  int weight { get; set; }
    public  string name{ get; set; }
}

//inventory definition 
class Inventory : IContainer
{
    public List<Item> Contents { get; set; }


    //define the constructor.
    public Inventory()
    {
        Contents = new List<Item>();
    }

    //place an item in the container
    public void Add(Item newItem)
    {
        Contents.Add(newItem);
    }

    //return the total amount of items
    public int totalCount()
    {
        return Contents.Count;
    }

    //get the total weight of all the items
    public int totalWeight(int startingWeight)
    {
     
        //for each item in the inventory
        foreach (Item x in Contents) {
            //if its a bag of holding, find its weight and add it to the total
            if (x is bagOfHolding)
            {
                startingWeight += ((bagOfHolding)x).totalWeight(0);
            }
            //else, just add the items weight to the total.
            else
            {
                startingWeight += x.weight;
            }
        }

        return startingWeight;
    }
}

//the BoH is pretty much the same as the inventory, but this can be added as an item.
class bagOfHolding : Item, IContainer
{
    public List<Item> Contents { get; set; }


    //define the constructors.
    public bagOfHolding()
    {
        Contents = new List<Item>();

    }

    public void Add(Item newItem)
    {
        Contents.Add(newItem);
    }

    public int totalCount()
    {
        int runningCount = 0;
        foreach (Item x in Contents)
        {
            if (x is bagOfHolding)
            {
                runningCount += ((bagOfHolding)x).totalCount();
            }
            else
            {
                runningCount++;
            }
        }
        return runningCount;
    }

    public int totalWeight(int startingWeight)
    {

        //for each item in the inventory
        foreach (Item x in Contents)
        {
            //if its a bag of holding, find its weight and add it to the total
            if (x is bagOfHolding)
            {
                startingWeight += ((bagOfHolding)x).totalWeight(0);
            }
            //else, just add the items weight to the total.
            else
            {
                startingWeight += x.weight;
            }
        }

        return startingWeight;
    }
}

//define some items
class Sword : Item
{
    public Sword()
    {
        cost = 20;
        weight = 5;
        int meleeDamage = 10;
         name = "Broadsword";
    }
}

class Potion : Item
{
    public Potion()
    {
        cost = 15;
        weight = 1;
       int healthBonus = 5;
        name = "Healing Potion";
    }
}
namespace Ex_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //create the main inventory.
            Inventory mainInventory = new Inventory();
            //add a sword and potion to it
            mainInventory.Add(new Sword());
            mainInventory.Add(new Potion());
            //print the weight
            Console.WriteLine("weight of the bag with a sword and potion: {0}", mainInventory.totalWeight(0));

            //create a bag of holding and put a sword in it.
            bagOfHolding newbag = new bagOfHolding();
            newbag.Add(new Sword());
            Console.WriteLine("weight of a bag of holding with a sword in it: {0}", newbag.totalWeight(0));

            //add the bag of holding to the main inventory.
            mainInventory.Add(newbag);
            Console.WriteLine("adding the bag of holding to the main inventory, the weight is: {0}", mainInventory.totalWeight(0));

        
            Console.ReadLine();
        }
    }
}
