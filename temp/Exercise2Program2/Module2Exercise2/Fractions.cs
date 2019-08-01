// ***********************************************************************
// Assembly         : Module2Exercise1
// Author           : Daniel Beckerich
// Created          : 10-29-2018
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 10-29-2018
// ***********************************************************************
// <copyright file="Fractions.cs" company="">
//     Copyright © 2018
// </copyright>
// <summary>This is the implementation for fractions as objects.</summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Exercise2
{
    class Fraction
    {
        int Numerator;
        int Denominator;

        //constructor with two Parameters.
        public Fraction(int Num, int Den)
        {
            Numerator = Num;
            Denominator = Den;
        }
        //empty constructor.
        Fraction()
        {
            Numerator = 1;
            Denominator = 1;
        }

        int GreatestCommonDivisor(int a, int b)
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

        void Simplify()
        {
            int gcd = GreatestCommonDivisor(Numerator, Denominator);
            Numerator = Numerator / gcd;
            Denominator = Denominator / gcd;
        }

        public double ToDecimal()
        {
            return (double)Numerator / (double)Denominator;
        }

        public String ToString()
        {;
            return Numerator.ToString() + "/" + Denominator.ToString();
        }

        public Fraction Add(Fraction f)
        {
            int tempNumerator = this.Numerator * f.Denominator + f.Numerator * this.Denominator;
            int tempDenominator = this.Denominator * f.Denominator;
            Fraction result = new Fraction(tempNumerator, tempDenominator);
            result.Simplify();
            return result;
        }

        public Fraction Multiply(Fraction f)
        {

            Fraction result =  new Fraction(f.Numerator * this.Numerator, f.Denominator * this.Denominator);
            result.Simplify();
            return result;
        }

    }
}
