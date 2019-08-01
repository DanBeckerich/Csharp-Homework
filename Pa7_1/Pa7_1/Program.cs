// ***********************************************************************
// Assembly         : Pa7_1
// Author           : Daniel Beckerich
// Created          : 12-8-2018
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 12-8-2018
// ***********************************************************************
//
//  Description: this program is designed to find the number between 1 and n with the most number of divisors.
//               this task must be completed using K number of threads.
//               this will be based off Pa6_1. as they are essentially the same problem.
//
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Pa7_1
{
    class Program
    {
        static object monitor = new object();

        //set this to true to have it print the times to a file for graphing.
        static bool PRINTTOFILE = false;

        //switch to these settings for a bit of a stress test.
        //static int MAX = 2000000;
        //static int[] K = { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40 };

        static int[] K = { 1, 2, 5, 7, 10 };
        static int MAX = 200000;
        static void Main(string[] args)
        {
            foreach (int currentThreadNumber in K)
            {

                //each iteration make the variables anew.
                List<Result> ResultList = new List<Result>();
                Stopwatch stopwatch = new Stopwatch();
                List<Thread> ThreadList = new List<Thread>();

                //calculate how many cells a thread will handle.
                int CellperThread = MAX / currentThreadNumber;

                //add the new threads
                Console.WriteLine(currentThreadNumber);
                for (int i = 1; i < currentThreadNumber + 1; i++)
                {
                    //create the threads with a bit of magic.
                    int iBound = (CellperThread * i) - CellperThread;
                    int oBound = (CellperThread * i);

                    ThreadList.Add(new Thread(() => { DivisorsCount(iBound, oBound, ref ResultList); }));

                }

                stopwatch.Start();
                foreach (Thread current in ThreadList)
                {
                    //start all the threads
                    current.Start();
                }

                //join each thread to insure we have all the data.
                foreach (Thread current in ThreadList)
                {
                    current.Join();
                }

                //variables for the number, and the highest number of divisors.
                int highestNumDiv = 0;
                int highestNum = 0;
                foreach (Result current in ResultList)
                {
                    //find the number with the highest divisors
                    if (current.Divisors > highestNumDiv) highestNum = current.Num; highestNumDiv = getDivisorCount(highestNum);
                }
                stopwatch.Stop();

                //print some data.
                Console.WriteLine("Number Of threads: " + currentThreadNumber);
                Console.WriteLine("Largest possible Number: " + MAX);
                Console.WriteLine();
                Console.WriteLine("Number with the must divisors: " + highestNum);
                Console.WriteLine("Number of divisors: " + highestNumDiv);
                Console.WriteLine("Number of results: " + ResultList.Count);
                Console.WriteLine("Elapsed time: " + stopwatch.Elapsed.TotalSeconds.ToString());
                Console.WriteLine("Cell Per thread: " + CellperThread);
                Console.WriteLine("====================================");

                //this is for my own personal use. i decided to leave it in just because.
                //you can see the response time of my computer from 1 to 40 threads.
                //see here: https://docs.google.com/spreadsheets/d/1JlUK8m6QMDTuL1hmkE17XBbowqny5OCNzArHc2Hqk10/edit?usp=sharing
                if (PRINTTOFILE)
                {   //this will save to /bin/debug
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter("Data.txt", true))
                    {
                        file.WriteLine(stopwatch.Elapsed.TotalSeconds.ToString());
                    }
                }
            }

            Console.ReadLine();
        }

        private static void DivisorsCount(int iBound, int oBound, ref List<Result> resultList)
        {
            //find the max number of divisors in a range.
            int highestDivisorCount = 0;
            int NumWithHighestDivisor = 0;
            for (int i = iBound; i < oBound; i++)
            {
                if (getDivisorCount(i) > highestDivisorCount)
                {
                    NumWithHighestDivisor = i;
                    highestDivisorCount = getDivisorCount(i);
                }
                
            }
            //put a lock on the result list so we don't get any funny business. 
            lock (resultList)
            {
                resultList.Add(new Result(NumWithHighestDivisor, highestDivisorCount));
                       }

        }

        private static int getDivisorCount(int num)
        {
            int factors = 0;
            int max = (int)Math.Sqrt(num);  //round down
            for (int factor = 1; factor <= max; ++factor)
            { //test from 1 to the square root, or the int below it, inclusive.
                if (num % factor == 0)
                {
                    factors++;
                }
            }
            return factors;
        }
    }
}
