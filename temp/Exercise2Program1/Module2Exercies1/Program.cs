// ***********************************************************************
// Assembly         : Module2Exercise1
// Author           : Daniel Beckerich
// Created          : 10-29-2018
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 10-29-2018
// ***********************************************************************
// <copyright file="Program.cs" company="">
//     Copyright © 2018
// </copyright>
// <summary>This program is designed to return the greatest common divisor.</summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Exercies1
{
    class Program
    {
        static int GreatestCommonDivisor(int a, int b)
        {
            //first, see if we have reached the GCD
            //if we have, return it.
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            //if not, execute the function again with the appropriate math.
            if (a > b)
                return GreatestCommonDivisor(a % b, b);
            else
                return GreatestCommonDivisor(a, b % a);
        }

        static void Main(string[] args)
        {
            //perform the calculations listed in the instructions and print them.
            Console.WriteLine("the Greatest Common Divisor of 164 and 410 is {0}", GreatestCommonDivisor(164, 410));
            Console.WriteLine("the Greatest Common Divisor of 87801 and 1469 is {0}", GreatestCommonDivisor(87801, 1469));

            Console.ReadLine();

        }
    }

}
