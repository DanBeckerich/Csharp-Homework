// ***********************************************************************
// Assembly         : ex7_2
// Author           : Daniel Beckerich
// Created          : 12-5-2018
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 12-5-2018
// ***********************************************************************
// Description: This program is designed to take a very large set of numbers and find the lowest and highest number. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Ex7_2
{

    class Program
    {
        static List<int> Nums = new List<int>();
        static object monitor = new object();
        static List<Result> ResultList = new List<Result>();

        static void Main(string[] args)
        {
            Random rng = new Random();
            int NumCount = 10000;
            int lowRNG = 0;
            int highRNG = 50000;
            int[] Threadlevels = { 2, 10, 100 };
            Stopwatch stopwatch = new Stopwatch();

            //populate the list.
            do
            {
                //get a new rng number
                int temp = rng.Next(lowRNG, highRNG);
                //if the number isnt already in the list, go ahead and add it.
                if (!Nums.Contains(temp))
                {
                    Nums.Add(temp);
                }
                //keep doing that until we have all the numbers we need.
            } while (Nums.Count < NumCount);

            //print the first 10 numbers.
            for (int i = 0; i < 10; i++)
            {
                Console.Write(Nums[i] + " ");
            }
            Console.Write(" ... ");

            //print the last 10 numbers;
            for (int z = Nums.Count - 10; z < Nums.Count; z++)
            {
                Console.Write(Nums[z] + " ");
            }
            Console.Write("\n");


            foreach (int currentThreadNumber in Threadlevels)
            {
                //create our new list of threads and results.
                List<Thread> ThreadList = new List<Thread>();
                ResultList = new List<Result>();

                int CellperThread = Nums.Count / currentThreadNumber;

                //add the new threads
                for (int i = 1; i < currentThreadNumber + 1; i++)
                {
                    //create the threads with a bit of magic.
                    int iBound = (CellperThread * i) - CellperThread;
                    int oBount = (CellperThread * i);

                    ThreadList.Add(new Thread(() => { getMinMax(iBound, oBount, Nums, ref ResultList); }));
                }

                //start the stopwatch and start the threads.
                stopwatch.Start();
                foreach (Thread current in ThreadList)
                {
                    current.Start();
                }

                //join each thread to insure we have all the data.
                foreach (Thread current in ThreadList)
                {
                    current.Join();
                }
                stopwatch.Stop();
                //create local min and local max numbers.
                int lmin = Nums[0];
                int lmax = Nums[0];

                //find the min/max for the results.
                foreach (Result current in ResultList)
                {
                    if (current.Min < lmin) { lmin = current.Min; }
                    if (current.Max > lmax) { lmax = current.Max; }
                }
                //stop the stop watch and print the results
               
                Console.WriteLine("Thread Count = " + ResultList.Count);
                Console.WriteLine("Min = " + lmin);
                Console.WriteLine("Max = " + lmax);
                Console.WriteLine("Elapsed time = " + stopwatch.Elapsed.ToString());
            }

            Console.ReadLine();
        }


        public static void getMinMax(int InnerBounds, int OuterBounds, List<int> Numlist,ref List<Result> ResultList)
        {
            //Console.WriteLine("InnerBounds = " + InnerBounds + ", OuterBounds = " + OuterBounds);

            int localMin = Numlist[0];
            int localMax = Numlist[0];
            //start at the inner bounds, iterate until we hit the outer bounds.
            for (int i = InnerBounds; i < OuterBounds; i++)
            {
                if (Numlist[i] <= localMin) localMin = Numlist[i];
                if (Numlist[i] >= localMax) localMax = Numlist[i];
            }
            Result temp = new Result(localMin, localMax);
            lock (ResultList)
            {
                ResultList.Add(temp);
            }


        }
    }
}
