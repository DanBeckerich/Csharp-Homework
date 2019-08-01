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
// <summary>This program is designed to implement and test fractions as objects.</summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Exercise2
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //declare all the fractions that we will use.
            Fraction fracOneHalf = new Fraction(1, 2);
            Fraction fracOneSeventh = new Fraction(1, 7);
            Fraction fracOneFith = new Fraction(1, 5);
            Fraction fracOneForth = new Fraction(1, 4);
            Fraction fracTwothirds = new Fraction(2, 3);
            Fraction FracFourFiths = new Fraction(4, 5);
            Fraction temp;

            //do the calculations in the instructions
            Console.WriteLine("{0} = {1}", fracOneHalf.ToString(), fracOneHalf.ToDecimal());
            Console.WriteLine("{0} + {1} = {2}", fracOneSeventh.ToString(), fracOneFith.ToString(), fracOneSeventh.Add(fracOneFith).ToString());
            Console.WriteLine("{0} * {1} * {2} = {3}", fracOneForth.ToString(), fracTwothirds.ToString(), FracFourFiths.ToString(), fracOneForth.Multiply(fracTwothirds).Multiply(FracFourFiths).ToString());

            Console.ReadLine();

        }
    }

}
